using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace GraphApiTest
{
    public class IdentitiyHelper
    {
        private const string ClientId = "d2a27b56-7b80-4053-8257-59346e5f2d2d";
        public static PublicClientApplication IdentityClientApp = new PublicClientApplication(ClientId);
        public static string[] Scopes = { "User.Read", "Files.ReadWrite" };

        public static DateTimeOffset Expiration;
        public static string TokenForUser;

        //private static readonly string Authority = string.Format(CultureInfo.InvariantCulture,
        //    "https://login.microsoftonline.com/{0}", "inboxlv.onmicrosoft.com");

        private const string GraphApiEndpoint = "https://graph.microsoft.com/v1.0/me";
        //private static readonly string graphResourceId = "https://graph.windows.net/";
        //private readonly AuthenticationContext _authContext;
        //private readonly Uri _redirectUri = new Uri("http://ojars-api-demo");

        public IdentitiyHelper()
        {
            //_authContext = new AuthenticationContext(Authority, false);
        }

        public string UserEmail { get; private set; }
        public string UserName { get; private set; }

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

            if (authResult != null)
            {
                Console.WriteLine(authResult.AccessToken);
                return authResult.AccessToken;
                //ResultText.Text = await GetHttpContentWithToken(_graphAPIEndpoint, authResult.AccessToken);
                //DisplayBasicTokenInfo(authResult);
                //this.SignOutButton.Visibility = Visibility.Visible;
            }

            return string.Empty;
        }

        //public async Task<string> GetTokenForUserAsync()
        //{
        //    try
        //    {
        //        //var credentials = new ClientCredential(clientId, );
        //        var result =
        //            await _authContext.AcquireTokenAsync(graphResourceId, clientId, _redirectUri, new PlatformParameters(PromptBehavior.Never));

        //        return result.AccessToken;
        //    }
        //    catch (Exception ex)
        //    {
        //    }

        //    return string.Empty;
        //}
        //        else if (TokenForUser == null || Expiration <= DateTimeOffset.UtcNow.AddMinutes(5))
        //        }
        //            // save user ID in local storage
        //                await IdentityClientApp.AcquireTokenSilentAsync(Scopes, IdentityClientApp.Users.First());
        //            authResult =
        //        {
        //        if (IdentityClientApp.Users.Any())
        //        AuthenticationResult authResult = null;
        //    {

        //    try
        //    //await IdentityClientApp.AcquireTokenSilentAsync(Scopes, IdentityClientApp.Users.First());
        //{

        //public async Task<string> GetTokenForUserAsync()
        //        {
        //            authResult = await IdentityClientApp.AcquireTokenAsync(Scopes);
        //            Expiration = authResult.ExpiresOn;
        //        }

        //        TokenForUser = authResult?.AccessToken;
        //        UserEmail = authResult?.User.DisplayableId;
        //        UserName = authResult?.User.Name;
        //        return authResult?.AccessToken;
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex.Message);
        //    }

        //    return string.Empty;
        //}


        ///// <summary>
        ///// Signs the user out of the service.
        ///// </summary>
        //public static void SignOut()
        //{
        //    foreach (var user in IdentityClientApp.Users)
        //    {
        //        IdentityClientApp.Remove(user);
        //    }
        //}
    }
}