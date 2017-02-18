using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Features
{
    public static class FeatureExtensions
    {
        public static IMvcBuilder AddFeatures(this IMvcBuilder builder, IConfiguration configuration)
        {
            builder.Services.AddTransient<IFeatureService>(provider => new FeatureService(configuration));
            builder.AddMvcOptions(options => options.Filters.Add(typeof(FeatureFilter)));
            return builder;
        }
    }
}
