using System;
using Microsoft.AspNetCore.Hosting;

using ODDCIS.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.Options;
using VDS.RDF;
using VDS.RDF.Query.Datasets;
using VDS.RDF.Query;
using VDS.RDF.Parsing;

namespace ODDCIS.Data
{
    public class Repository : IRepository
    {
        private string _owlFile;
        private Appsettings _appsettings;
        private readonly IHostingEnvironment _env;

        public Repository(IHostingEnvironment env, Appsettings appsettings)
        {
            _env = env;
            _appsettings = appsettings;
            _owlFile = Path.Combine(_env.WebRootPath, _appsettings.OwlFilePath);
        }
        public SearchResult GetResult(string searchQuery)
        {
            var queryFilePath = Path.Combine(_env.WebRootPath, _appsettings.QuerySettings.Folder, _appsettings.QuerySettings.Query1);
            if (File.Exists(queryFilePath))
            {
                string sparqlQuery = File.ReadAllText(queryFilePath);
                var g = new Graph();
                g.LoadFromFile(_owlFile,new TurtleParser());
                ISparqlDataset ds = new InMemoryDataset(g);
                LeviathanQueryProcessor processor = new LeviathanQueryProcessor(ds);
                var queryParser = new SparqlQueryParser();
                var results = processor.ProcessQuery(queryParser.ParseFromString(sparqlQuery));
                return new SearchResult
                {
                    Results = results
                };
            }
            return null;
        }
    }
}
