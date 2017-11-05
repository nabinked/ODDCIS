using ODDCIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VDS.RDF;
using VDS.RDF.Query;

namespace ODDCIS.Query
{
    public class QueryHelper
    {
        private readonly Queries queries;
        public QueryHelper(Queries queries)
        {
            this.queries = queries;
        }
        public string GetQueryAllPredicates(IEnumerable<RdfNode> clases)
        {
            if (clases.ToList().Count > 0)
            {
                var query = queries.AllPredicatesOf;
                var classes = clases.Where(x => x.Type == RdfNodeType.Class).ToList();
                return query.Replace("@classTriplets", GetClassTriplets(classes));
            }
            return string.Empty;
        }

        public string GetQueryAllObjectsOf(Uri predicateUri)
        {
            var query = queries.AllObjectsOf;
            var parmeterizedString = new SparqlParameterizedString(query);
            parmeterizedString.SetUri("predicateUri", predicateUri);
            return parmeterizedString.ToSafeString();
        }

        public string GetQueryResults(IList<RdfNode> rdfNodes)
        {
            var query = queries.Results;
            return query.Replace("@triples", new ResultQueryMaker(rdfNodes).GetTriples());
        }

        public string GetQueryAllSubClassesOf(Uri superCLass)
        {
            var query = queries.AllSubClassesOf;
            var parmeterizedString = new SparqlParameterizedString(query);
            parmeterizedString.SetUri("superClass", superCLass);
            return parmeterizedString.ToSafeString();
        }

        public string GetSemanticQuery(IList<RdfNode> rdfNodes)
        {
            var query = string.Empty;
            foreach (var rdfNode in rdfNodes)
            {
                query += $"{rdfNode.Label} ";
            }

            return query;
        }

        #region Privates
        private string GetClassTriplets(IList<RdfNode> classes)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < classes.Count; i++)
            {
                sb.Append($" {{<{classes[i].Uri}> (rdfs:subClassOf|(owl:equivalentClass|^owl:equivalentClass))* ?super . ?item <{NamespaceMapper.RDFS}domain>  ?super .}} ");

                if (i != classes.Count - 1)
                {
                    sb.Append(" UNION ");
                }
            }
            return sb.ToString();
        }

        #endregion
    }
}
