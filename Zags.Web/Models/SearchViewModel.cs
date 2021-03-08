using System.Collections.Generic;

namespace Zags.Web.Models
{
    public class SearchViewModel
    {
        public SearchQuery Search { get; set; }
        public IEnumerable<Person> People { get; set; }
    }
}