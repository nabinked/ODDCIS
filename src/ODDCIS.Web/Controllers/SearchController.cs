using Microsoft.AspNetCore.Mvc;
using ODDCIS.Data;
using ODDCIS.Models;
using System.Collections.Generic;
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
        public IList<RdfTerm> Suggestions(IList<RdfTerm> precedentRdfTerms)
        {
            return this.repository.GetSuggestionList(precedentRdfTerms);
        }
    }
}
