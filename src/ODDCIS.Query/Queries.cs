using VDS.RDF.Query;

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

        public string AllPredicatesOf
        {
            get
            {
                return CommonPrefixes + this.queryRetriever.GetQuery(nameof(AllPredicatesOf));
            }
        }

        public string AllObjectsOf
        {
            get
            {
                return CommonPrefixes + this.queryRetriever.GetQuery(nameof(AllObjectsOf));
            }
        }

        public string AllSubClassesOf
        {
            get
            {
                return CommonPrefixes + this.queryRetriever.GetQuery(nameof(AllSubClassesOf));
            }
        }

        public string Results
        {
            get
            {
                return CommonPrefixes + this.queryRetriever.GetQuery(nameof(Results));
            }
        }
    }
}
