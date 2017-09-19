using Microsoft.AspNetCore.Hosting;
using ODDCIS.Models;
using System.IO;

namespace ODDCIS.Query
{
    public class QueryRetriever
    {
        private readonly IHostingEnvironment env;
        private readonly Appsettings appsettings;
        private readonly string owlFile;

        private const string QueryFileExtension = "rq";

        public QueryRetriever(IHostingEnvironment env, Appsettings appsettings)
        {
            this.env = env;
            this.appsettings = appsettings;
            this.owlFile = Path.Combine(this.env.WebRootPath, this.appsettings.OwlFilePath);
        }

        public string GetQuery(string queryFileName)
        {
            var queryFilePath = GetQueryFilePath(queryFileName);
            if (!File.Exists(queryFilePath))
            {
                throw new QueryNotFoundException();
            }
            else
            {
                return File.ReadAllText(queryFilePath);
            }
        }

        private string GetQueryFilePath(string queryFileName)
        {
            return Path.Combine(this.env.WebRootPath, this.appsettings.QuerySettings.Folder, queryFileName + "." + QueryFileExtension);
        }
    }
}
