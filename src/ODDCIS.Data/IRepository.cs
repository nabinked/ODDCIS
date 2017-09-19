using ODDCIS.Models;
using System.Collections.Generic;
using VDS.RDF.Query;

namespace ODDCIS.Data
{
    public interface IRepository
    {
        SparqlResultSet GetResult(string query);
        IList<RdfTerm> GetSuggestionList(IList<RdfTerm> precedentsRdfTerms);
    }
}
