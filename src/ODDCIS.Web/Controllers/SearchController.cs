using Microsoft.AspNetCore.Mvc;
using ODDCIS.Data;
using ODDCIS.Models;
using System.Collections.Generic;
using System.Linq;
using VDS.RDF;

namespace ODDCIS.Web
{
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private readonly IRepository repository;

        public SearchController(IRepository repository)
        {
            this.repository = repository;
        }
        // GET api/values
        [HttpGet("")]
        public SearchResultList Get(SearchQueryViewModel searchViewModel)
        {
            return null;
        }

        // GET api/values
        [HttpGet("suggestions")]
        public IList<RdfNode> Suggestions(List<RdfNode> precedentRdfTerms)
        {
            if (precedentRdfTerms.Count > 0)
            {
                var precedentTerm = precedentRdfTerms.FirstOrDefault();
                switch (precedentTerm.NodeType)
                {
                    case NodeType.Uri:
                        return this.repository.GetAllPredicatesOf(precedentRdfTerms.Where(x => x.NodeType == NodeType.Uri));
                    case NodeType.Literal:
                        return this.repository.GetAllObjectsOf(precedentTerm);
                    default:
                        return null;
                }
            }
            else
            {
                return this.repository.GetAllClasses();
            }
        }
    }
}
