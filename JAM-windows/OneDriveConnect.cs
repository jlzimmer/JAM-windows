using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

// Reference: https://docs.microsoft.com/en-us/azure/active-directory/develop/tutorial-v2-windows-desktop

namespace JAM_windows
{
    class OneDriveConnect
    {
        readonly string graphAPIEndpoint = "https://graph.microsoft.com/v1.0/me";
        readonly string[] scopes = new string[] { };

        public async void EstablishConnection()
        {
            AuthenticationResult authentication = null;

            var app = App.PublicClientApp;
            var accounts = await app.GetAccountsAsync();

            try
            {
                authentication = await app.AcquireTokenSilentAsync(scopes, accounts.FirstOrDefault());
            }
            catch (MsalUiRequiredException e)
            {
                System.Diagnostics.Debug.WriteLine($"MsalUiRequiredException: {e.Message}");
                try
                {
                    authentication = await App.PublicClientApp.AcquireTokenAsync(scopes);
                }
                catch (MsalException ex)
                {
                    System.Diagnostics.Debug.WriteLine($"MsalUiRequiredException: {ex.Message}");
                    return;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"MsalUiRequiredException: {e.Message}");
                return;
            }

            if (authentication != null)
            {
                string result = await GetHttpContentWithToken(graphAPIEndpoint, authentication.AccessToken);
                DisplayTokenInfo(authentication);
                // Set sign-out button to visible?
            }
        }

        public async Task<string> GetHttpContentWithToken(string url, string token)
        {

        }

        private void DisplayTokenInfo(AuthenticationResult auth)
        {

        }
    }
}
