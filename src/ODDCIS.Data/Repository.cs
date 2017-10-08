using ODDCIS.Models;
using VDS.RDF.Query.Datasets;
using VDS.RDF.Query;
using VDS.RDF.Parsing;
using ODDCIS.Data.DataModelMappers;
using System.Collections.Generic;
using ODDCIS.Query;
using System.Linq;
using System;
using VDS.RDF.Ontology;

namespace ODDCIS.Data
{
    public class Repository : IRepository
    {
        private readonly Queries queries;
        private readonly QueryHelper queryHelper;
        private readonly ISparqlDataset dataset;

        public Repository(
            Queries queries,
            QueryHelper queryHelper,
            DatasetAccessor datasetAccessor)
        {
            this.queries = queries;
            this.queryHelper = queryHelper;
            this.dataset = datasetAccessor.DataSet;
        }

        public SearchResultList GetResult(IList<RdfNode> rdfNodes)
        {
            try
            {
                var query = this.queryHelper.GetQueryResults(rdfNodes);
                var searchResults = ExecuteQuery(query).ToSearchResult();
                return new SearchResultList()
                {
                    ExecutedQuery = query,
                    Results = searchResults.ToList()
                };
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<RdfNode> GetAllSubjects()
        {
            try
            {
                var query = this.queries.AllClasses;
                var nodes = ExecuteQuery(query).ToRdfNodes().ToList();
                SetRdfNodeType(nodes, RdfNodeType.Class);
                return nodes;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<RdfNode> GetAllPredicatesOf(IEnumerable<RdfNode> classes)
        {
            try
            {
                var query = this.queryHelper.GetQueryAllPredicates(classes);
                var nodes = ExecuteQuery(query).ToRdfNodes().ToList();
                SetRdfNodeType(nodes, RdfNodeType.Predicate);
                return nodes;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<RdfNode> GetAllObjectsOf(Uri predicate)
        {
            try
            {
                var query = this.queryHelper.GetQueryAllObjectsOf(predicate);
                var nodes = ExecuteQuery(query).ToRdfNodes().ToList();
                nodes.AddRange(GetSubClasses(nodes));
                SetRdfNodeType(nodes, RdfNodeType.Class);
                return nodes;
            }
            catch (Exception)
            {
                throw;
            }
        }



        #region Privates
        private IList<RdfNode> GetSubClasses(List<RdfNode> nodes)
        {
            var list = new List<RdfNode>();
            foreach (var node in nodes)
            {
                list.AddRange(GetSubClassNode(node));
            }
            return list;
        }
        private IEnumerable<RdfNode> GetSubClassNode(RdfNode node)
        {
            return ExecuteQuery(this.queryHelper.GetQueryAllSubClassesOf(node.Uri)).ToRdfNodes();

        }
        private SparqlResultSet ExecuteQuery(string query)
        {
            LeviathanQueryProcessor processor = new LeviathanQueryProcessor(this.dataset);
            var queryParser = new SparqlQueryParser();
            return processor.ProcessQuery(queryParser.ParseFromString(query)) as SparqlResultSet;
        }
        private void SetRdfNodeType(IList<RdfNode> nodes, RdfNodeType type)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                nodes[i].Type = type;
            }

        }

        #endregion
    }
}
