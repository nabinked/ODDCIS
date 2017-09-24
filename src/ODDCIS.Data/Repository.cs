using ODDCIS.Models;
using VDS.RDF.Query.Datasets;
using VDS.RDF.Query;
using VDS.RDF.Parsing;
using ODDCIS.Data.DataModelMappers;
using System.Collections.Generic;
using ODDCIS.Query;
using System.Linq;

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
        public SparqlResultSet GetResult(string searchQuery)
        {
            try
            {
                var query = queries.SearchKeyWord;
                if (!string.IsNullOrEmpty(query))
                {

                    LeviathanQueryProcessor processor = new LeviathanQueryProcessor(this.dataset);
                    var queryParser = new SparqlQueryParser();
                    var parmeterizedString = new SparqlParameterizedString(query);
                    parmeterizedString.SetLiteral("value", searchQuery);
                    return processor.ProcessQuery(queryParser.ParseFromString(parmeterizedString.ToString())) as SparqlResultSet;
                }
            }
            catch
            {
                throw;
            }
            return null;
        }

        public IList<RdfNode> GetAllClasses(IList<RdfNode> precedentRdfTerms)
        {
            try
            {
                var query = queryHelper.GetQueryAllPredicates(precedentRdfTerms);
                return ExecuteQuery(query).Results.Select(x => x.ToRdfNode()).ToList();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public IList<RdfNode> GetAllClasses()
        {
            try
            {
                var query = queries.AllClasses;
                return ExecuteQuery(query).Results.Select(x => x.ToRdfNode()).ToList();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public IList<RdfNode> GetAllPredicatesOf(IEnumerable<RdfNode> classes)
        {
            try
            {
                var query = queryHelper.GetQueryAllPredicates(classes);
                return ExecuteQuery(query).Results.Select(x => x.ToRdfNode()).ToList();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public IList<RdfNode> GetAllObjectsOf(RdfNode precedentTerm)
        {
            return null;
        }

        #region Privates
        private SparqlResultSet ExecuteQuery(string query)
        {
            LeviathanQueryProcessor processor = new LeviathanQueryProcessor(this.dataset);
            var queryParser = new SparqlQueryParser();
            return processor.ProcessQuery(queryParser.ParseFromString(query)) as SparqlResultSet;
        }
        #endregion
    }
}
