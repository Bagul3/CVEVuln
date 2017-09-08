namespace CVEVuln.Models.Resources.Links
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
