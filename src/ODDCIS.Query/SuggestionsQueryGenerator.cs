using ODDCIS.Models;
using System.Collections.Generic;

namespace ODDCIS.Query
{
    public class SuggestionsQueryGenerator
    {
        private readonly Queries queries;

        public SuggestionsQueryGenerator(Queries queries)
        {
            this.queries = queries;
        }

        public string SuggestionList(IList<RdfTerm> precedentTerms)
        {
            if (precedentTerms.Count > 0)
            {
                return queries.AllClasses;
            }
            else
            {
                return queries.AllClasses;
            }
        }
    }
}
