using clistub.Interfaces;
using clistub.Common;

namespace clistub
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // args = new string[] { "-name", "Michael", "-age", "68" };

            // get environment variables
            string tenantId = Environment.GetEnvironmentVariable("SERVICE_PRINCIPAL_AUTH_TENANT_ID").NullToString();
            string clientId = Environment.GetEnvironmentVariable("SERVICE_PRINCIPAL_AUTH_CLIENT_ID").NullToString();
            string clientSecret = Environment.GetEnvironmentVariable("SERVICE_PRINCIPAL_AUTH_CLIENT_SECRET").NullToString();


            // output parameters
            string paramOutput = @$"Paramters: -name: {args[1]}  -age is {args[3]}";
            Console.WriteLine(paramOutput);

            try
            {
                // call token service
                ITokenService tokenService = new TokenService();
                var accessToken = await tokenService.GetTokenAsync(tenantId, clientId, clientSecret);
                // get workspaces
                IFabricRestApiService fabricRestApiService = new FabricRestApiService(accessToken);
                var workspaces = fabricRestApiService.GetWorkspaces();

                // loop and print out workspace names
                foreach (var workspace in workspaces)
                {
                    Console.WriteLine($"Workspace: {workspace.DisplayName} WorkspaceId: ({workspace.Id})");
                }

            }
            catch (Exception ex)
            {
                // print error
                Console.WriteLine(ex.ToString());
            }
        }
    }
}