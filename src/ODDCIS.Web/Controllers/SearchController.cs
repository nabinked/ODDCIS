using Microsoft.AspNetCore.Mvc;
using ODDCIS.Data;
using ODDCIS.Models;

namespace ODDCIS.Web
{
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private readonly IRepository _repository;

        public SearchController(IRepository repository)
        {
            this._repository = repository;
        }
        // GET api/values
        [HttpGet("")]
        public SearchResultList Get(SearchQueryViewModel searchViewModel)
        {
            return this._repository.GetResult(searchViewModel.Query);
        }
    }
}
