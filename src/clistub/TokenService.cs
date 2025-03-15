using clistub.Common;
using clistub.Interfaces;
using Microsoft.Identity.Client;
using static System.Formats.Asn1.AsnWriter;

namespace clistub
{
    /// <summary>
    /// Class used to get a Fabric API access token.
    /// </summary>
    internal class TokenService : ITokenService
    {
        /// <summary>
        /// Gets a Microsoft Fabric access token.
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <returns>Microsoft Fabric access token.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<string> GetTokenAsync(string tenantId, string clientId, string clientSecret)
        {
            // scopes
            // string[] scopes = new string[] { "https://api.fabric.microsoft.com/Workspace.ReadWrite.All https://api.fabric.microsoft.com/Item.ReadWrite.All" };
            string[] scopes = new string[] { "https://api.fabric.microsoft.com/.default" };
            string tenantSpecificAuthority = "https://login.microsoftonline.com/" + tenantId;

            // build confidential client application
            IConfidentialClientApplication confidentialClientApplication = ConfidentialClientApplicationBuilder.Create(clientId)
                  .WithClientSecret(clientSecret)
                  .WithAuthority(tenantSpecificAuthority)
            .Build();

            // wait for async completion
            var task = await confidentialClientApplication.AcquireTokenForClient(scopes).ExecuteAsync();

            return task.AccessToken;
        }
    }
}
