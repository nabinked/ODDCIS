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
        private readonly SuggestionsQueryGenerator suggestionQueryGenerator;
        private readonly ISparqlDataset dataset;

        public Repository(
            Queries queries,
            SuggestionsQueryGenerator suggestionQueryGenerator,
            DatasetAccessor datasetAccessor)
        {
            this.queries = queries;
            this.suggestionQueryGenerator = suggestionQueryGenerator;
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

        public IList<RdfTerm> GetSuggestionList(IList<RdfTerm> precedentRdfTerms)
        {
            var query = suggestionQueryGenerator.SuggestionList(precedentRdfTerms);
            try
            {
                LeviathanQueryProcessor processor = new LeviathanQueryProcessor(this.dataset);
                var queryParser = new SparqlQueryParser();
                var resultSet = processor.ProcessQuery(queryParser.ParseFromString(query)) as SparqlResultSet;
                return resultSet.Results.Select(x => x.ToSuggestionList()).ToList();
            }
                catch (System.Exception)
            {
                throw;
            }
        }
    }
}
