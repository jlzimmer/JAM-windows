using System;
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

        public MainWindow()
        {
            InitializeComponent();
            // Initialize directory if known
        }

        private void SelectDirectory_Click(object sender, RoutedEventArgs e)
        {
            targetDirectory = new SelectDir();
            BackupLabel.Content = targetDirectory.PathToDir;
            // Console.WriteLine(targetDirectory.PathToDir);
        }
    }
}
