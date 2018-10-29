﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JAM_windows
{
    class SelectDir
    {
        // Properties
        // ***
        // PathToDir - the directory root selected by the user via dialog window that appears during class construction
        // DirSize - calculated value that calls GetDirSize() each time the property is accessed, this is to ensure that any external changes are accounted for
        // Paths - a list of strings that represent all *accessible* paths, this list should only be set by GetDirSize()
        // ***
        public readonly string PathToDir;
        public long DirSize { get => GetDirSize(PathToDir); }
        public List<FileInfo> Files { get; }

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

        private static long GetDirSize(string dir)
        {
            long size = 0;
            string[] paths = null;
            List<FileInfo> files = new List<FileInfo>();

            try
            {
                paths = Directory.GetFiles(dir);

                if (paths != null)
                {
                    foreach (string s in paths)
                    {
                        FileInfo f = new FileInfo(s);
                        files.Add(f);
                        size += f.Length;
                    }
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
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
}
