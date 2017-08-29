using Microsoft.AspNetCore.Hosting;
using ODDCIS.Models;
using System.IO;
using VDS.RDF;
using VDS.RDF.Query.Datasets;
using VDS.RDF.Query;
using VDS.RDF.Parsing;
using ODDCIS.Data.DataModelMappers;
using System.Collections.Generic;

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
        public SearchResultList GetResult(string searchQuery)
        {
            var queryFilePath = Path.Combine(_env.WebRootPath, _appsettings.QuerySettings.Folder, _appsettings.QuerySettings.Query1);
            if (File.Exists(queryFilePath))
            {
                string sparqlQuery = File.ReadAllText(queryFilePath);
                var g = new Graph();
                g.LoadFromFile(_owlFile, new TurtleParser());
                ISparqlDataset ds = new InMemoryDataset(g);
                LeviathanQueryProcessor processor = new LeviathanQueryProcessor(ds);
                var queryParser = new SparqlQueryParser();
                var parmeterizedString = new SparqlParameterizedString(sparqlQuery);
                parmeterizedString.SetLiteral("value", searchQuery);
                var resultSet = processor.ProcessQuery(queryParser.ParseFromString(parmeterizedString.ToString())) as SparqlResultSet;
                var resultList = new SearchResultList()
                {
                    Results = new List<SearchResult>()
                };
                foreach (var result in resultSet.Results)
                {
                    resultList.Results.Add(result.ToSearchResult());
                }
                return resultList;
            }
            return null;
        }
    }
}
