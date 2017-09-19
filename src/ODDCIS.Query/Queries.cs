namespace ODDCIS.Query
{
    public class Queries
    {
        private readonly QueryRetriever queryRetriever;

        public Queries(QueryRetriever queryRetriever)
        {
            this.queryRetriever = queryRetriever;
        }
        public string AllClasses
        {
            get
            {
                return this.queryRetriever.GetQuery(nameof(AllClasses));
            }
        }

        public string SearchKeyWord
        {
            get
            {
                return this.queryRetriever.GetQuery(nameof(SearchKeyWord));
            }
        }
    }
}
