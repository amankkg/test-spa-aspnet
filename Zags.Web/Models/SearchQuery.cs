namespace Zags.Web.Models
{
    public class SearchQuery
    {
        public string Keyword { get; set; }
        public PersonOrderBy OrderBy { get; set; } = PersonOrderBy.PIN;
    }
}