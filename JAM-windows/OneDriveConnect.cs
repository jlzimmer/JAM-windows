using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

// Reference: https://docs.microsoft.com/en-us/azure/active-directory/develop/tutorial-v2-windows-desktop

namespace JAM_windows
{
    class OneDriveConnect
    {
        readonly string graphProfileEndpoint = "https://graph.microsoft.com/v1.0/me";
        readonly string[] scopes = new string[] { "user.read", "files.readwrite.all" };
        AuthenticationResult authentication = null;

        public async Task<bool> EstablishConnection()
        {
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
                    return false;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"MsalUiRequiredException: {e.Message}");
                return false;
            }

            if (authentication == null)
            {
                return false;
            }

            return true;
        }

        public async Task<string> GetUserInfo()
        {
            string token = authentication.AccessToken;
            if (authentication == null || token == null)
            {
                bool result = await EstablishConnection();
                if (result == false)
                {
                    return null;
                }
            }

            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, graphProfileEndpoint);
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.SendAsync(request);
                var profile = await response.Content.ReadAsStringAsync();
                return profile;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
