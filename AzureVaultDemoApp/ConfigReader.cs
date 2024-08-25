using AzureVaultDemoApp.Models;
using System.Configuration;

namespace AzureVaultDemoApp
{
    internal class ConfigReader
    {
        public AppConfiguration Read()
        {
            var config = new AppConfiguration();
            config.Thumbprint = ConfigurationManager.AppSettings["thumbprint"];
            config.TenantId = ConfigurationManager.AppSettings["tenantId"];
            config.ClientId = ConfigurationManager.AppSettings["clientId"];
            config.VaultUri = ConfigurationManager.AppSettings["vaultUri"];
            config.SecretName = ConfigurationManager.AppSettings["secretName"];
            return config;
        }
    }
}
