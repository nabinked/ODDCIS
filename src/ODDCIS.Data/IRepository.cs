using ODDCIS.Models;
using System.Collections.Generic;
using VDS.RDF.Query;

namespace ODDCIS.Data
{
    public interface IRepository
    {
        SparqlResultSet GetResult(string query);
        IList<RdfNode> GetAllClasses();
        IList<RdfNode> GetAllPredicatesOf(IEnumerable<RdfNode> classes);
        IList<RdfNode> GetAllObjectsOf(RdfNode precedentTerm);
    }
}
