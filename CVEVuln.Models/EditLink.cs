using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVEVuln.Models
{
    public class EditLink : Link
    {
        public const string Relation = "edit";

        public EditLink(string href, string title = null)
            : base(Relation, href, title)
        {
        }
    }
}
