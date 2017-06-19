using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVEVuln.Models
{
    public class SelfLink : Link
    {
        public const string Relation = "self";

        public SelfLink(string href, string title = null) : base(Relation, href, title)
        {
        }
    }
}
