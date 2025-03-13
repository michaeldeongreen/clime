using clistub.Interfaces;
using Microsoft.Fabric.Api;
using Microsoft.Fabric.Api.Core.Models;

namespace clistub
{
    /// <summary>
    /// Class used as a wrapper around the FabricClient
    /// </summary>
    internal class FabricRestApiService : IFabricRestApiService
    {
        // readonly variables
        private readonly FabricClient _fabricClient;
        private readonly string _accessToken;

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="accessToken"></param>
        public FabricRestApiService(string accessToken) 
        {
            string fabricRestApiBaseUrl = "https://api.fabric.microsoft.com/v1";
            _accessToken = accessToken;
            _fabricClient = new FabricClient(accessToken, new Uri(fabricRestApiBaseUrl));
        }

        /// <summary>
        /// Gets a list of Fabric Workspaces
        /// </summary>
        /// <returns>List of Fabric Workspaces</returns>
        public List<Workspace> GetWorkspaces()
        {
            var workspaces = _fabricClient.Core.Workspaces.ListWorkspaces().ToList();

            return workspaces;
        }
    }
}
