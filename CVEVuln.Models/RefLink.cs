using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVEVuln.Models
{
    public class RefLink : Link
    {
        public const string Relation = "ref";

        public RefLink(string href) : base(Relation, href)
        {
        }
    }
}
