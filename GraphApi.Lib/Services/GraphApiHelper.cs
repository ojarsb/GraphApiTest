using System.Net.Http.Headers;
using GraphApi.Core.Identity;
using Microsoft.Graph;

namespace GraphApi.Core.Services
{
    public class GraphApiHelper
    {
        private static GraphServiceClient _graphClient;

        private readonly IdentitiyHelper _identitiyHelper;

        public GraphApiHelper()
        {
            _identitiyHelper = new IdentitiyHelper();
        }

        // Get an authenticated Microsoft Graph Service client.
        public GraphServiceClient GetAuthenticatedClient()
        {
            _graphClient = new GraphServiceClient(
                new DelegateAuthenticationProvider(
                    async requestMessage =>
                    {
                        var accessToken = await _identitiyHelper.GetToken();

                        // Append the access token to the request.
                        requestMessage.Headers.Authorization =
                            new AuthenticationHeaderValue("bearer", accessToken);
                    }));
            return _graphClient;
        }

        public static void SignOutClient()
        {
            _graphClient = null;
        }
    }
}