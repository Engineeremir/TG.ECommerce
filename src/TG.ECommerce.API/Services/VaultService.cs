using System.Text.Json;
using VaultSharp;
using VaultSharp.V1.AuthMethods;
using VaultSharp.V1.AuthMethods.Token;

namespace TG.ECommerce.API.Services;

public class VaultService
{
    private readonly IVaultClient vaultClient;
    private readonly string secretPath;

    public VaultService(IConfiguration configuration)
    {
        IAuthMethodInfo authMethod = new TokenAuthMethodInfo(configuration["Vault:Token"]);
        var vaultClientSettings = new VaultClientSettings(configuration["Vault:Url"], authMethod);
        vaultClient = new VaultClient(vaultClientSettings);
        secretPath = configuration["Vault:Path"]!;
    }

    public T GetSecret<T>(string sectionName) where T : new()
    {
        try
        {
            var secret = vaultClient.V1.Secrets.KeyValue.V2
                .ReadSecretAsync(secretPath, mountPoint: "secret")
                .GetAwaiter().GetResult();

            if (secret.Data.Data.TryGetValue(sectionName, out var sectionData))
            {
                if (sectionData is JsonElement jsonElement)
                {
                    return JsonSerializer.Deserialize<T>(jsonElement.GetRawText());
                }
                else
                {
                    // Object olarak geliyorsa JSON'a çevirip deserialize et
                    var json = JsonSerializer.Serialize(sectionData);
                    return JsonSerializer.Deserialize<T>(json);
                }
            }

            throw new Exception($"Section '{sectionName}' not found in Vault secrets");
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to get secret section '{sectionName}': {ex.Message}", ex);
        }
    }

    public string GetSecretValue(string sectionName, string key)
    {
        try
        {
            var secret = vaultClient.V1.Secrets.KeyValue.V2
                .ReadSecretAsync(secretPath, mountPoint: "secret")
                .GetAwaiter().GetResult();

            if (secret.Data.Data.TryGetValue(sectionName, out var sectionData))
            {
                if (sectionData is JsonElement jsonElement && jsonElement.ValueKind == JsonValueKind.Object)
                {
                    if (jsonElement.TryGetProperty(key, out var property))
                    {
                        return property.GetString() ?? string.Empty;
                    }
                }
            }

            throw new Exception($"Key '{key}' not found in section '{sectionName}'");
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to get secret value '{sectionName}.{key}': {ex.Message}", ex);
        }
    }
}
