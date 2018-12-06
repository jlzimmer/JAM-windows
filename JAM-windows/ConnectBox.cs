using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using BoxOAuth.Models;
using Microsoft.Extensions.Options;
using Box.V2;
using Box.V2.Auth;
using Box.V2.Utility;
using Box.V2.Config;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.CSharp.RuntimeBinder;
using System.Web.Mvc;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Box.V2.Converter;
using Box.V2.Exceptions;
using Box.V2.Extensions;
using Box.V2.JWTAuth;
using Box.V2.Managers;
using Box.V2.Models;
using Box.V2.Plugins;
using Box.V2.Request;
using Box.V2.Services;

namespace JAM_windows
{
    class ConnectBox
    {
        const string BOX_AUTH_URL = "https://account.box.com/api/oauth2/authorize";
     //   private BoxAppSettings _boxSettings { get; set; }
        private BoxClient _boxClient { get; set; }
        private BoxConfig _boxConfig { get; set; }
        public OAuthSession BoxAuthenicatedSession { get; set; }
       // OAuthSession session = new OAuthSession();
        
          static BoxConfig config = new BoxConfig("1iymr4r3dlqpw44519tj7i5ycglmnzeq", "ujKUZqvE4SzHoNzs2JOUupxJemQWjW5m", new Uri("http://localhost:5000/route/return"));
        //  BoxClient client = new BoxClient(config);

        static string clientIdParam = $"client_id={config.ClientId}";
        static string redirectUrlParam = $"redirect_uri={BOX_AUTH_URL}";

        HttpClient web = new HttpClient();
        Uri webURL = new Uri ($"{BOX_AUTH_URL}?response_type=code&" + clientIdParam +"&" +config.RedirectUri);
        BoxClient client = new BoxClient(config);

        public void InitClient()
        {    
            // BoxClient client = new BoxClient(configuration);
            Console.WriteLine("Client Initiated");
           // web.BaseAddress = webURL;
            System.Diagnostics.Process.Start(webURL.ToString());
            //   OAuthSession boxSession;
            GetInfo();

        }
        public async void GetInfo()
        {
            //get auth code

            //client.Auth.AuthenticateAsync("needs auth code here");
            BoxFile file = new BoxFile();
          //  file = await client.FilesManager.GetInformationAsync(id: "1");
        }
    }

   
}
