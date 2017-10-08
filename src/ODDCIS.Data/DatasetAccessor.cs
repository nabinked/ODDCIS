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
            if (HasImports(ontologyGraph, out var triples))
            {
                foreach (var triple in triples)
                {
                    var o = triple.Object as UriNode;
                    IGraph import = LoadImport(o.Uri);
                    graphs.Add(import);
                    AddImports(graphs, import);

                }
            }
        }

        public IGraph LoadImport(Uri uri)
        {
            var import = new Graph();
            if (uri.IsFile)
            {
                FileLoader.Load(import, uri.ToString());
            }
            else
            {
                try
                {
                    UriLoader.Load(import, uri);
                }
                catch
                {

                }
            }
            import.BaseUri = null;
            return import;
        }

        public bool HasImports(IGraph ontologyGraph, out IList<Triple> triples)
        {
            triples = new List<Triple>();
            foreach (var trple in ontologyGraph.Triples)
            {
                var uri = trple.Predicate as UriNode;
                if (uri.Uri.EqualsFull(new Uri(NamespaceMapper.OWL + "imports")))
                {
                    triples.Add(trple);
                }
            }
            return triples.Count > 0;
        }
    }
}
