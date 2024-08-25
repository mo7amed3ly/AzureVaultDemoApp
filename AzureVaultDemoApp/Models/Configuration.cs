namespace AzureVaultDemoApp.Models
{
    internal class AppConfiguration
    {
        public string TenantId { get; set; }
        public string ClientId { get; set; }
        public string Thumbprint { get; set; }
        public string VaultUri { get; set; }
        public string SecretName { get; set; }
    }
}
