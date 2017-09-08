namespace CVEVuln.Models.Resources.Links
{
    public class RefLink : Link
    {
        public const string Relation = "ref";

        public RefLink(string href) : base(Relation, href)
        {
        }
    }
}
