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
using System.IO;



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
        }

        private void BoxComConnect_Click(object sender, RoutedEventArgs e)
        {          
            boxConnection.InitClient();
            boxBrowser.setURL(boxConnection.InitClient(), this);
            boxBrowser.Show();
        }

        private void Upload_Click(object sender, RoutedEventArgs e)
        {
            int z = targetDirectory.Files.Count;
            List<FileInfo> fileInfos = new List<FileInfo>();
            fileInfos = targetDirectory.Files;
            
            foreach(FileInfo file in fileInfos)
            {
                boxConnection.uploadFile(file.FullName, file.Name);
            }
        
          
        }

        public async void printURL()
        {
            boxBrowser.Close();

            List<BoxFile> files = await boxConnection.GetInfo(boxCode);
            
            foreach (BoxFile file in files)
            {
                BoxComList.Items.Add(new BoxFileClass { FileName = file.Name, Size = file.Size.ToString(), LastModified = file.ModifiedAt.Value.ToShortDateString() });
            }
        }


        public class BoxFileClass
        {
            public String FileName { get; set; }
            public String Size { get; set; }
            public String LastModified { get; set; }
        }

    }

}
