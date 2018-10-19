using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JAM_windows
{
    class SelectDir
    {
        public string PathToDir { get; }
        public double DirSize { get; }

        public SelectDir()
        {
            using (FolderBrowserDialog browserDialog = new FolderBrowserDialog())
            {
                browserDialog.Description = "Select a local directory for cloud file synchronization.";
                browserDialog.RootFolder = Environment.SpecialFolder.UserProfile;

                browserDialog.ShowDialog();
                this.PathToDir = browserDialog.SelectedPath;
            }
        }
    }
}
