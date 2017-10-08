using ODDCIS.Common;
using ODDCIS.Common.Extensions;
using ODDCIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                Title = result.GetNode<LiteralNode>("t")?.Value,
                Excerpt = result.GetNode<LiteralNode>("e")?.Value,
                Url = result.GetNode<LiteralNode>("u")?.Value
            };
        }

        public static IEnumerable<SearchResult> ToSearchResult(this SparqlResultSet resultSet)
        {
            return resultSet.Results.Select(x => x.ToSearchResult());
        }

        public static RdfNode ToRdfNode(this SparqlResult result)
        {
            var node = new RdfNode()
            {
                Uri = result.GetNode<UriNode>("item")?.Uri,
                Comment = result.GetNode<ILiteralNode>("comment")?.Value,
                Label = result.GetNode<ILiteralNode>("label")?.Value,
                PredicateOf = result.GetNode<IUriNode>("predicateOf")?.Uri
            };
            return node;
        }

        public static IEnumerable<RdfNode> ToRdfNodes(this SparqlResultSet resultSet)
        {
            return resultSet.Results.Select(x => x.ToRdfNode());
        }
    }
}
