using ODDCIS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ODDCIS.Query
{
    public class ResultQueryMaker
    {
        private IList<RdfNode> rdfNodes;

        public ResultQueryMaker(IList<RdfNode> rdfNodes)
        {
            this.rdfNodes = rdfNodes;
        }

        public string GetTriples()
        {
            if (this.rdfNodes == null && this.rdfNodes.Count < 1)
            {
                throw new Exception("No RdfNode Provided");
            }
            var query = string.Empty;
            foreach (var rdfnode in this.rdfNodes)
            {
                if (rdfnode.Type == RdfNodeType.Class)
                {
                    query += $"?webpage di:hasDefinitionOf <{rdfnode.Uri}> . ";
                }
            }
            return query;
        }
    }
}
