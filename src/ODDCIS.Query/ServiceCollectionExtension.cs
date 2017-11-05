using Microsoft.Extensions.DependencyInjection;

namespace ODDCIS.Query
{
    public static class ServiceCollectionExtension
    {
        public static void AddQueries(this IServiceCollection services)
        {
            services.AddScoped<QueryRetriever>();
            services.AddScoped<Queries>();
            services.AddScoped<QueryHelper>();
        }

    }
}