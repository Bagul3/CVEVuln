namespace CVEVuln.Models.Resources.Links
{
    public class SelfLink : Link
    {
        public const string Relation = "self";

        public SelfLink(string href) : base(Relation, href)
        {
        }
    }
}
