namespace ODDCIS.Query
{
    public class Queries
    {
        private readonly QueryRetriever queryRetriever;

        public Queries(QueryRetriever queryRetriever)
        {
            this.queryRetriever = queryRetriever;
        }

        public string CommonPrefixes
        {
            get
            {
                return this.queryRetriever.GetQuery(nameof(CommonPrefixes));
            }
        }

        public string AllClasses
        {
            get
            {
                return CommonPrefixes + this.queryRetriever.GetQuery(nameof(AllClasses));
            }
        }

        public string SearchKeyWord
        {
            get
            {
                return CommonPrefixes + this.queryRetriever.GetQuery(nameof(SearchKeyWord));
            }
        }

        public string AllPropertiesOf
        {
            get
            {
                return CommonPrefixes + this.queryRetriever.GetQuery(nameof(AllPropertiesOf));
            }
        }
    }
}
