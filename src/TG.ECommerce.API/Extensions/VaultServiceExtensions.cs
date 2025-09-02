using TG.ECommerce.API.Services;

namespace TG.ECommerce.API.Extensions;

public static class VaultServiceExtensions
{
    public static IServiceCollection ConfigureFromVault<T>(this IServiceCollection services,
        IConfiguration configuration, string sectionName) where T : class, new()
    {
        services.Configure<T>(options =>
        {
            var vaultService = new VaultService(configuration);
            var settings = vaultService.GetSecret<T>(sectionName);

            // Properties'leri kopyala
            foreach (var prop in typeof(T).GetProperties())
            {
                if (prop.CanWrite)
                {
                    var value = prop.GetValue(settings);
                    prop.SetValue(options, value);
                }
            }
        });

        return services;
    }
}