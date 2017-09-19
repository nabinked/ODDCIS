using ODDCIS.Models;
using System;
using System.Collections.Generic;
using VDS.RDF;
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

        public static RdfTerm ToSuggestionList(this SparqlResult result)
        {
            Uri uri = default(Uri);
            string comment = string.Empty, label = string.Empty;
            if (result.TryGetValue("subject", out INode subNode))
            {
                uri = (subNode as IUriNode).Uri;
            }

            if (result.TryGetValue("comment", out INode commentNode))
            {
                comment = (commentNode as ILiteralNode).Value;
            }

            if (result.TryGetValue("label", out INode labelNode))
            {
                label = (labelNode as ILiteralNode).Value;
            }

            return new RdfTerm()
            {
                Uri = uri,
                Comment = comment,
                Label = label
            };
        }

    }
}
