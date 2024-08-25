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
            X509Certificate2 certificate = GetCertificate(appConfig.Thumbprint);
            var client = new SecretClient(new System.Uri(appConfig.VaultUri), new ClientCertificateCredential(appConfig.TenantId, appConfig.ClientId, certificate));
            var secret = client.GetSecret(appConfig.SecretName);
        }

        private static X509Certificate2 GetCertificate(string thumbprint)
        {
            var store=new X509Store(StoreName.My, StoreLocation.CurrentUser);
            try
            {
                store.Open(OpenFlags.ReadOnly);
                var certificateCollection=store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint,false);
                if (certificateCollection == null || certificateCollection.Count==0) {
                    throw new Exception("Certificate is not installed");
                }
                return certificateCollection[0];
            }
            finally
            {

               store.Close();
            }
        }
    }
}
