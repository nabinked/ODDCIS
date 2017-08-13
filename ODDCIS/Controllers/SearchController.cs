using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ODDCIS.Controllers
{
    [Route("[controller]")]
    public class SearchController : BaseController
    {
        [HttpGet("")]
        public IActionResult Search(SearchViewModel searchViewModel)
        {
            return Json(new { });
        }
    }
}
