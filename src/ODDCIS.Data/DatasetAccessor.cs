using Microsoft.AspNetCore.Hosting;
using ODDCIS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using VDS.RDF;
using VDS.RDF.Ontology;
using VDS.RDF.Parsing;
using VDS.RDF.Query.Datasets;
using ODDCIS.Common.Extensions;

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

        public IEnumerable<IGraph> Graphs
        {
            get
            {
                var graphs = new List<IGraph>();

                var graph = new OntologyGraph();
                graph.LoadFromFile(this.owlFile, new TurtleParser());
                graph.BaseUri = null;

                graphs.Add(graph);

                AddImports(graphs, graph);

                return graphs;
            }
        }


        public ISparqlDataset DataSet
        {
            get
            {
                ISparqlDataset ds = new InMemoryDataset(true);
                foreach (var graph in Graphs)
                {
                    graph.BaseUri = null;
                    ds.AddGraph(graph);
                }
                return ds;
            }
        }

        public void AddImports(IList<IGraph> graphs, IGraph ontologyGraph)
        {
            if (HasImport(ontologyGraph, out Triple triple))
            {
                var o = triple.Object as UriNode;

                IGraph import = new Graph();
                import.LoadFromUri(o.Uri);
                import.BaseUri = null;
                graphs.Add(import);

                AddImports(graphs, import);
            }
        }

        public bool HasImport(IGraph ontologyGraph, out Triple triple)
        {
            foreach (var trple in ontologyGraph.Triples)
            {
                var uri = trple.Predicate as UriNode;
                if (uri.Uri.EqualsFull(new Uri(NamespaceMapper.OWL + "imports")))
                {
                    triple = trple;
                    return true;
                }
            }
            triple = null;
            return false;
        }
    }
}
