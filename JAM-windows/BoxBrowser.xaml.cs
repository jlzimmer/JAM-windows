using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace JAM_windows
{
    /// <summary>
    /// Interaction logic for BoxBrowser.xaml
    /// </summary>
    public partial class BoxBrowser : Window
    {
        JAM_windows.MainWindow mainWindowXaml;

        public BoxBrowser()
        {
            InitializeComponent();
        }

        private void BoxBrowser_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (BoxBrowserWindow.Source.ToString().Contains("?code"))
            {
                mainWindowXaml.boxCode = BoxBrowserWindow.Source.ToString().Replace("http://localhost:5000/route/return?code=","");
                mainWindowXaml.printURL();
            }
        }
        
        public void setURL(string url, JAM_windows.MainWindow window)
        {
            mainWindowXaml = window;
            BoxBrowserWindow.Navigate(url);
           
        }
    }
}
