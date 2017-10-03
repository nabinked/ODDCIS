using Microsoft.AspNetCore.Mvc;
using ODDCIS.Data;
using ODDCIS.Models;
using System.Collections.Generic;
using System.Linq;

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
        public IEnumerable<RdfNode> Suggestions(List<RdfNode> precedentRdfTerms)
        {
            var precedentTerm = precedentRdfTerms.LastOrDefault();
            var precedentSubjects = precedentRdfTerms.Where(x => x.Type == RdfNodeType.Class);
            switch (precedentTerm?.Type)
            {
                case RdfNodeType.Class:
                    return this.repository.GetAllPredicatesOf(precedentSubjects);
                case RdfNodeType.Predicate:
                    return this.repository.GetAllObjectsOf(precedentTerm.Uri);
                default:
                    return GetAllSubjects(precedentSubjects);
            }
        }

        private IEnumerable<RdfNode> GetAllSubjects(IEnumerable<RdfNode> precedentSubjects)
        {
            var filteredSubjects = new List<RdfNode>();
            var allsubjects = this.repository.GetAllSubjects();
            foreach (var subject in allsubjects)
            {
                if (allsubjects.Any(x => x.Uri != subject.Uri))
                {
                    filteredSubjects.Add(subject);
                }
            }
            return filteredSubjects;
        }

    }
}
