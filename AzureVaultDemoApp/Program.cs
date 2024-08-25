using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;
using System.Security.Cryptography.X509Certificates;

namespace AzureVaultDemoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var appConfig = new ConfigReader().Read();
            X509Certificate2 certificate = new CertificateReader().GetCertificate(appConfig.Thumbprint);
            var client = new SecretClient(new System.Uri(appConfig.VaultUri), new ClientCertificateCredential(appConfig.TenantId, appConfig.ClientId, certificate));
            var secret = client.GetSecret(appConfig.SecretName);
            Console.WriteLine($"Now I know your birthdat. It is {secret.Value.Value}");
            Console.ReadKey();
        }
    }
}
