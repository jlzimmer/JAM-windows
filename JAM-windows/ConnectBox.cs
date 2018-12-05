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
        
          static BoxConfig config = new BoxConfig("1iymr4r3dlqpw44519tj7i5ycglmnzeq", "ujKUZqvE4SzHoNzs2JOUupxJemQWjW5m", new Uri("ttp://localhost:5000/route/return"));
        //  BoxClient client = new BoxClient(config);

        static string clientIdParam = $"client_id={config.ClientId}";
        static string redirectUrlParam = $"redirect_uri={BOX_AUTH_URL}";

        HttpClient web = new HttpClient();
        Uri webURL = new Uri ($"{BOX_AUTH_URL}?response_type=code&" + clientIdParam);
       
        public void InitClient()
        {
            BoxClient client = new BoxClient(config);
            // BoxClient client = new BoxClient(configuration);
            Console.WriteLine("Client Initiated");
            web.BaseAddress = webURL;
            System.Diagnostics.Process.Start(webURL.ToString());
            
        }
    }

   
}
