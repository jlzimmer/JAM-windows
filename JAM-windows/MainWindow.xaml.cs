﻿using System;
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



namespace JAM_windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

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
            // Console.WriteLine($"{0} has size {1}", targetDirectory.PathToDir, targetDirectory.SizeFormat());
        }

        private void BoxComConnect_Click(object sender, RoutedEventArgs e)
        {
            ConnectBox boxConnection = new ConnectBox();
            boxConnection.InitClient();
         
        }
    }
}
