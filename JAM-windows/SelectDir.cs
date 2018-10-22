using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JAM_windows
{
    class SelectDir
    {
        public string PathToDir { get; }
        public long DirSize { get => GetDirSize(PathToDir); }

        public SelectDir()
        {
            using (FolderBrowserDialog browserDialog = new FolderBrowserDialog())
            {
                browserDialog.Description = "Select a local directory for cloud file synchronization.";
                browserDialog.RootFolder = Environment.SpecialFolder.Desktop;

                if (browserDialog.ShowDialog() == DialogResult.OK)
                {
                    PathToDir = browserDialog.SelectedPath;
                }
                else
                {
                    PathToDir = null;
                }
            }
        }

        private long GetDirSize(string dir)
        {
            long size = 0;

            try
            {
                foreach (string item in Directory.GetFiles(dir))
                {
                    FileInfo fileInfo = new FileInfo(item);
                    size += fileInfo.Length;
                }
                foreach (string path in Directory.GetDirectories(dir))
                {
                    size += GetDirSize(path);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // log and inform user list of directories/files skipped
            }
            catch (IOException)
            {
                // display messagebox with Skip/Cancel options
            }

            return size;
        }

        public string SizeFormat()
        {
            string[] suffix = new string[] { "B", "KB", "MB", "GB" };
            double size = DirSize;
            int index = 0;

            while (size / 1000 >= 1 || index < 3)
            {
                size /= 1000;
                index++;
            }

            size = Math.Round(size, 1);
            string info = size + " " + suffix[index];

            return info;
        }
    }
    //test
}
