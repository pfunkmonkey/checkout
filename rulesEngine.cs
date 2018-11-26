using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Checkout
{
    public class RulesEngine
    {
        private List<Rule> _rules;

        public RulesEngine(List<Rule> rules)
        {
            _rules = rules;
        }

        public decimal Apply(List<string> products)
        {
            decimal total = 0;
            foreach (var product in products.Distinct())
            {
                var productRule = _rules.Find(i => i.Item.SKU == product);

                var productCount = products.Where(i => i == product).Count();

                var numberOfGroupsEligibleForDiscount = productCount / productRule.Item.SpecialPrice.Count;

                if (numberOfGroupsEligibleForDiscount >= 1)
                {
                    total += productRule.Item.SpecialPrice.Price * numberOfGroupsEligibleForDiscount;
                    var numberOfItemsToChargeAtNormalPrice = productCount % productRule.Item.SpecialPrice.Count;
                    total += numberOfItemsToChargeAtNormalPrice * productRule.Item.Price;
                }
                else
                {
                    total += productRule.Item.Price * productCount;
                }
            }

            return total;
        }
    }
}