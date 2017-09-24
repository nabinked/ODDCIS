using VDS.RDF;
using VDS.RDF.Query;

namespace ODDCIS.Common.Extensions
{
    public static class SparqlResultExtensions
    {
        public static T GetNode<T>(this SparqlResult result, string variable) where T : class
        {
            if (result.TryGetValue(variable, out INode subNode))
            {
                return (subNode as T);
            }
            return default(T);
        }
    }
}
