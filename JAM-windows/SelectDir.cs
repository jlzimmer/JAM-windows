using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JAM_windows
{
    class SelectDir
    {
        public string PathToDir { get; }
        public long DirSize { get => GetDirSize(); }

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

        private long GetDirSize()
        {
            string[] items = Directory.GetFiles(PathToDir, "*", SearchOption.AllDirectories);
            long size = 0;

            foreach (string item in items)
            {
                FileInfo fileInfo = new FileInfo(item);
                size += fileInfo.Length;
            }

            return size;
        }
    }
}
