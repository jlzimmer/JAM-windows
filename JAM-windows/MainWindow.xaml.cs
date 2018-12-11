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




namespace JAM_windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SelectDir targetDirectory;

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

        private void GoogleDriveConnect_Click(object sender, RoutedEventArgs e)
        {
            var googleDriveConnect = new DriveQuickstart.GoogleDriveConnect();

            googleDriveConnect.GoogleDrive();

            if (googleDriveConnect == null)
            {
                // some error stuff
                Console.Write("Could not instantiate google drive connect");

            }
        }
    }
}
