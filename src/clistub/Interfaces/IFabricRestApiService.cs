using Microsoft.Fabric.Api.Core.Models;

namespace clistub.Interfaces
{
    /// <summary>
    /// Interface used to wrap the FabricClient
    /// </summary>
    internal interface IFabricRestApiService
    {
        /// <summary>
        /// Gets the Fabric workspaces
        /// </summary>
        /// <returns>List of Workspace</returns>
        List<Workspace> GetWorkspaces();
    }
}
