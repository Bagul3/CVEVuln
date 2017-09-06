using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVEVuln.Extensions
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    public class MapAttribute : Attribute
    {
        public MapAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
