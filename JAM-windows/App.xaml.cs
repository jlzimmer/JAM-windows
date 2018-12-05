using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Identity.Client;

namespace JAM_windows
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Azure Active Directory v2 client token for Microsoft Graph API integration
        private static string ClientId = "aa89f176-2d19-4a63-b3cc-df679b4599a9";
        public static PublicClientApplication PublicClientApp = new PublicClientApplication(ClientId);
    }
}
