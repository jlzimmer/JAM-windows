using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Diagnostics;
using System.Threading.Tasks;
using Box.V2;
using Box.V2.Models;
using System.Windows.Navigation;




namespace JAM_windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        SelectDir targetDirectory;
        ConnectBox boxConnection = new ConnectBox();
        public string boxCode;
        public BoxBrowser boxBrowser = new BoxBrowser();

        public class BoxFileClass
        {
            public String FileName;
            public String FileSize;

        }

        public async void printURL()
        {
            System.Windows.MessageBox.Show(boxCode);
            boxBrowser.Close();
            // BoxClient boxClient = new BoxClient();
            List<BoxFile> files =  await boxConnection.GetInfo(boxCode);
            int x = 0;
            //while (x<files.Entries.Count())
            //{
            //    Console.WriteLine(files.Entries.ElementAtOrDefault<BoxItem>(x).Name);
            //    x++;
            //}
            foreach(BoxFile file in files)
            {
                //System.Windows.MessageBox.Show(file.Name);
                BoxComList.Items.Add(new String[] { boxName. = file.Name,  });
              //  BoxComList.Items.Add(file.Size.ToString());
              //  BoxComList.Items.Add(file.ModifiedAt.ToString());
            }
            //System.Windows.MessageBox.Show(file.Name);
           // Console.WriteLine
        }

        public MainWindow()
        {
            InitializeComponent();
            // Initialize directory if known
        }

        private void SelectDirectory_Click(object sender, RoutedEventArgs e)
        {
            targetDirectory = new SelectDir();
            if (targetDirectory.PathToDir == null)
            {
                targetDirectory = null;
                BackupLabel.Content = "[Please select a folder to use for back-up]";
                DirVolumeLabel.Content = "0 B";
                return;
            }

            BackupLabel.Content = targetDirectory.PathToDir;
            DirVolumeLabel.Content = targetDirectory.SizeFormat();
            // Console.WriteLine($"{0} has size {1}", targetDirectory.PathToDir, targetDirectory.SizeFormat());
        }

        private void BoxComConnect_Click(object sender, RoutedEventArgs e)
        {          
            boxConnection.InitClient();
            boxBrowser.setURL(boxConnection.InitClient(), this);
            boxBrowser.Show();
        }

     

     

    }
}
