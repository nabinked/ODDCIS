using System.Collections.Generic;

namespace ODDCIS.Models
{
    public class SearchResultList
    {
        public string ExecutedSparqlQuery { get; set; }
        public string RequestedSemanticQuery { get; set; }
        public IList<SearchResult> Results { get; set; }
    }
}
