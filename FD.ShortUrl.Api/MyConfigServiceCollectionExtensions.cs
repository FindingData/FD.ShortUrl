using ConfigSample.Options;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MyConfigServiceCollectionExtensions
    {
        public static IServiceCollection AddConfig(
             this IServiceCollection services, IConfiguration config)
        {
            services.Configure<PositionOptions>(
                config.GetSection(PositionOptions.Position));
            services.Configure<ColorOptions>(
                config.GetSection(ColorOptions.Color));

            return services;
        }
    }


}

namespace ConfigSample.Options
{
    #region snippet
    public class PositionOptions
    {
        public const string Position = "Position";

        public string Title { get; set; }
        public string Name { get; set; }
    }
    #endregion
}

namespace ConfigSample.Options
{
    public class ColorOptions
    {
        public const string Color = "Color";

        public string Foreground { get; set; }
        public string Background { get; set; }
    }
}
