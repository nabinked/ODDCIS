using Microsoft.Extensions.DependencyInjection;

namespace ODDCIS.Data
{
    public static class ServiceCollectionExtension
    {
        public static void AddDataLayer(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<DatasetAccessor>();
        }

    }
}