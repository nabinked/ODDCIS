using System.Collections.Generic;

namespace ODDCIS.Models
{
    public class SearchResultList
    {
        public string ExecutedQuery { get; set; }
        public IList<SearchResult> Results { get; set; }
    }
}
