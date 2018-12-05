using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BoxOAuth.Models;
using Microsoft.Extensions.Options;
using Box.V2;
using Box.V2.Auth;
using Box.V2.Utility;
using Box.V2.Config;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


namespace JAM_windows
{
    class ConnectBox
    {
        const string BOX_AUTH_URL = "https://account.box.com/api/oauth2/authorize";
        private BoxAppSettings _boxSettings { get; set; }
        private BoxClient _boxClient { get; set; }
        private BoxConfig _boxConfig { get; set; }
        public OAuthSession BoxAuthenicatedSession { get; set; }
    }
}
