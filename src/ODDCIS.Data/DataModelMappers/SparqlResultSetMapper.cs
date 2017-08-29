using ODDCIS.Models;
using VDS.RDF.Query;

namespace ODDCIS.Data.DataModelMappers
{
    public static class SparqlResultSetMapper
    {
        public static SearchResult ToSearchResult(this SparqlResult result)
        {
            return new SearchResult()
            {
                Title = result.Value("title").ToString(),
                Excerpt = result.Value("excerpt").ToString(),
                Url = result.Value("url").ToString()
            };
        }

    }
}
