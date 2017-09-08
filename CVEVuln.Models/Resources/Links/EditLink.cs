namespace CVEVuln.Models.Resources.Links
{
    public class EditLink : Link
    {
        public const string Relation = "edit";

        public EditLink(string href)
            : base(Relation, href)
        {
        }
    }
}
