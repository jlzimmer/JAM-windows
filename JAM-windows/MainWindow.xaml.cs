﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;

namespace JAM_windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SelectDir targetDirectory;
        OneDriveConnect ODconnect;

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

        private void OneDriveConnect_Click(object sender, RoutedEventArgs e)
        {
            ODconnect = new OneDriveConnect();
            string userInfo = ODconnect.GetUserInfo().ToString();
            if (userInfo == null)
            {
                MessageBox.Show("There was an error connecting to the Microsoft Graph API.", "Connection results", MessageBoxButton.OK);
                return;
            }
            else
            {
                MessageBox.Show($"{userInfo}", "Connection results", MessageBoxButton.OK);
            }


        }
    }
}
