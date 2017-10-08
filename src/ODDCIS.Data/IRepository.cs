using ODDCIS.Models;
using System;
using System.Collections.Generic;
using VDS.RDF.Query;

namespace ODDCIS.Data
{
    public interface IRepository
    {
        SearchResultList GetResult(IList<RdfNode> rdfNodes);
        IEnumerable<RdfNode> GetAllSubjects();
        IEnumerable<RdfNode> GetAllPredicatesOf(IEnumerable<RdfNode> subjects);
        IEnumerable<RdfNode> GetAllObjectsOf(Uri predicate);
    }
}
