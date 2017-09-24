using System;
using Microsoft.AspNetCore.Mvc;
using VDS.RDF;

namespace ODDCIS.Models
{
    public class RdfNode
    {
        [FromQuery(Name = "uri")]
        public Uri Uri { get; set; }

        [FromQuery(Name = "label")]
        public string Label { get; set; }

        [FromQuery(Name = "comment")]
        public string Comment { get; set; }

        [FromQuery(Name = "nodeType")]
        public NodeType NodeType { get; set; }

        [FromQuery(Name = "predicateOf")]
        public Uri PredicateOf { get; set; }

        [FromQuery(Name = "objectOf")]
        public Uri ObjectOf { get; set; }
    }
}
