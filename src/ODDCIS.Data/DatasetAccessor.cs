using Microsoft.AspNetCore.Hosting;
using ODDCIS.Models;
using System.IO;
using VDS.RDF;
using VDS.RDF.Parsing;
using VDS.RDF.Query.Datasets;

namespace ODDCIS.Data
{
    public class DatasetAccessor
    {
        private IHostingEnvironment env;
        private readonly Appsettings appsettings;
        private readonly string owlFile;

        public DatasetAccessor(IHostingEnvironment env, Appsettings appsettings)
        {
            this.env = env;
            this.appsettings = appsettings;
            this.owlFile = Path.Combine(this.env.WebRootPath, this.appsettings.OwlFilePath);
        }

        public ISparqlDataset DataSet
        {
            get
            {
                var g = new Graph();
                g.LoadFromFile(owlFile, new TurtleParser());
                ISparqlDataset ds = new InMemoryDataset(g);
                return ds;
            }
        }
    }
}
