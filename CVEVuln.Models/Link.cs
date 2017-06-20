using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVEVuln.Models
{
    public abstract class Link
    {
        public string Rel { get; }
        public string Href { get; }

        protected Link(string relation, string href)
        {
            Rel = relation;
            Href = href;
        }
    }
}
