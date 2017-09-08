using System.Collections.Generic;
using Newtonsoft.Json;
using WebGrease.Css.Extensions;
namespace CVEVuln.Models.Resources.Links
{
    public abstract class LinkResource
    {
        private readonly List<Link> _links = new List<Link>();

        [JsonProperty(Order = 100)]
        public IEnumerable<Link> Links => _links;

        public void AddLink(Link link)
        {
            _links.Add(link);
        }

        public void AddLinks(params Link[] links)
        {
            links.ForEach(AddLink);
        }
    }
}
