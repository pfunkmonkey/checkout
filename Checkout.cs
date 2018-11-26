using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Checkout
{
    public class Checkout
    {
        private List<string> products = new List<string>();

        private RulesEngine _rulesEngine;
        public Checkout(List<Rule> rules)
        {
            _rulesEngine = new RulesEngine(rules);
        }

        public decimal Total()
        {
            var total = _rulesEngine.Apply(products);

            return total;
        }

        public void Scan(string product)
        {
            products.Add(product);
        }
    }
}
