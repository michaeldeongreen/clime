namespace clistub.Interfaces
{
    internal interface ITokenService
    {
        /// <summary>
        /// Gets a Microsoft Fabric access token.
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <returns>Microsoft Fabric access token.</returns>
        Task<string> GetTokenAsync(string tenantId, string clientId, string clientSecret);
    }
}
