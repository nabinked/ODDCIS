using System;
using Microsoft.AspNetCore.Hosting;

using ODDCIS.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ODDCIS.Data
{
    public class Repository : IRepository
    {
        public Repository(IConfiguration configuration, IHostingEnvironment env)
        {
            var owlFile = Path.Combine(env.WebRootPath, configuration.GetSection("OwlFilePath").Value);
        }
        public SearchResult GetResult(string query)
        {
            return null;
        }
    }
}
