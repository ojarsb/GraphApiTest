using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace GraphApi.Core.Identity
{
    public class IdentitiyHelper
    {
        //private const string ClientId = "13b53fe0-4b6b-4675-8aaf-3b4d97d2d145"; //ojarob@inbox.lv
        private const string ClientId = "1c189eb6-db13-4d3a-9393-04c577fb9e2c"; //ojarob@oobb.on
        private static readonly PublicClientApplication IdentityClientApp = new PublicClientApplication(ClientId);
        private static readonly string[] Scopes = { "User.Read", "DeviceManagementApps.Read.All", "DeviceManagementApps.ReadWrite.All" };
        public static DateTimeOffset Expiration;
        public static string TokenForUser;

        public async Task<string> GetToken()
        {
            AuthenticationResult authResult = null;

            try
            {
                authResult =
                    await IdentityClientApp.AcquireTokenSilentAsync(Scopes, IdentityClientApp.Users.FirstOrDefault());
            }
            catch (MsalUiRequiredException ex)
            {
                // A MsalUiRequiredException happened on AcquireTokenSilentAsync. This indicates you need to call AcquireTokenAsync to acquire a token
                System.Diagnostics.Debug.WriteLine($"MsalUiRequiredException: {ex.Message}");

                try
                {
                    authResult = await IdentityClientApp.AcquireTokenAsync(Scopes);
                }
                catch (MsalException msalex)
                {
                    Console.WriteLine($"Error Acquiring Token:{System.Environment.NewLine}{msalex}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Acquiring Token Silently:{System.Environment.NewLine}{ex}");
                return string.Empty;
            }

            return authResult == null ? string.Empty : authResult.AccessToken;

            //Console.WriteLine(authResult.AccessToken);
        }
    }
}