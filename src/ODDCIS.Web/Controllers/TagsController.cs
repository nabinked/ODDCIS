using Microsoft.AspNetCore.Mvc;
using ODDCIS.Models;
using System.Collections.Generic;

namespace ODDCIS.Web.Controllers
{
    [Route("api/[controller]")]
    public class TagsController : Controller
    {
        [HttpGet("parse")]
        public List<RdfNode> Parse(List<RdfNode> rdfNodes)
        {
            return rdfNodes;
        }
    }
}
