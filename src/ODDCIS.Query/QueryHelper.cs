using ODDCIS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VDS.RDF;

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
                var query = queries.AllPropertiesOf;
                var classes = clases.Where(x => x.NodeType == NodeType.Uri).ToList();
                return query.Replace("@classTriplets", GetClassTriplets(classes));
            }
            return string.Empty;
        }

        #region Privates
        private string GetClassTriplets(IList<RdfNode> classes)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < classes.Count; i++)
            {
                sb.Append($" {{?subject <{NamespaceMapper.RDFS}domain> <{classes[i].Uri}> .}} ");
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
