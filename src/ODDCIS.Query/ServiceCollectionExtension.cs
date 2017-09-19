using Microsoft.Extensions.DependencyInjection;

namespace ODDCIS.Query
{
    public static class ServiceCollectionExtension
    {
        public static void AddQueries(this IServiceCollection services)
        {
            services.AddSingleton<QueryRetriever>();
            services.AddSingleton<Queries>();
            services.AddSingleton<SuggestionsQueryGenerator>();

        }

    }
}