using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebGrease.Css.Extensions;

namespace CVEVuln.Models
{
    public abstract class Resource
    {
        private List<Link> links = new List<Link>();

        [JsonProperty(Order = 100)]
        public IEnumerable<Link> Links { get { return links; } }

        public void AddLink(Link link)
        {
            links.Add(link);
        }

        public void AddLinks(params Link[] links)
        {
            links.ForEach(link => AddLink(link));
        }
    }
}
