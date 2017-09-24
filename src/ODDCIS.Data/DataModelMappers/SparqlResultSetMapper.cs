using ODDCIS.Common.Extensions;
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

        public static RdfNode ToRdfNode(this SparqlResult result)
        {
            return new RdfNode()
            {
                Uri = result.GetNode<UriNode>("subject")?.Uri,
                NodeType = result.GetNode<UriNode>("type").NodeType,
                Comment = result.GetNode<ILiteralNode>("comment")?.Value,
                Label = result.GetNode<ILiteralNode>("label")?.Value,
                
            };
        }
    }
}
