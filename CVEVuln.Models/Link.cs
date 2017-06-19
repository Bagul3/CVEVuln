using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVEVuln.Models
{
    public abstract class Link
    {
        public string Rel { get; private set; }
        public string Href { get; private set; }
        public string Title { get; private set; }

        public Link(string relation, string href, string title = null)
        {
            String.IsNullOrEmpty(relation);
            String.IsNullOrEmpty(href);

            Rel = relation;
            Href = href;
            Title = title;
        }
    }
}
