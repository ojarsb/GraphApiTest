using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.Graph;

namespace GraphApiTest
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
                        string accessToken = await _identitiyHelper.GetToken();

                        // Append the access token to the request.
                        requestMessage.Headers.Authorization =
                            new AuthenticationHeaderValue("bearer", accessToken);

                        // Get event times in the current time zone.
                        //requestMessage.Headers.Add("Prefer",
                        //    "outlook.timezone=\"" + TimeZoneInfo.Local.Id + "\"");

                        // This header has been added to identify our sample in the Microsoft Graph service. If extracting this code for your project please remove.
                        //requestMessage.Headers.Add("SampleID", "aspnet-snippets-sample");
                    }));
            return _graphClient;
        }
        
        public static void SignOutClient()
        {
            _graphClient = null;
        }
    }
}
