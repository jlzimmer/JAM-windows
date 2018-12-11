using System;
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
        // Paths - a list of FileInfo objects that represent all *accessible* paths, this list should only be set by GetDirSize()
        // ***
        public readonly string PathToDir;
        public long DirSize { get => GetDirSize(PathToDir); }
        public List<FileInfo> Files { get; set; }
        
        // ***
        // Returns SelectDir object on success, null on failure
        // Uses a System.Windows.Forms.FolderBrowserDialog() object to fetch the initial root directory and assigns it to PathToDir
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

        // ***
        // Returns a long int representing the total size of the root directory
        // This method is called each time the DirSize field is accessed to give an accurate and up-to-date read of the size of the working directory
        // Also builds a List<FileInfo> so that subsequent logical interactions on the list of valid file paths can be executed immediately without calling this method again
        private long GetDirSize(string root)
        {
            long size = 0;
            Stack<string> paths = new Stack<string>();
            List<FileInfo> files = new List<FileInfo>();

            if (!Directory.Exists(root))
            {
                throw new ArgumentException(String.Format("{0} is an invalid root directory path", root));
            }
            paths.Push(root);

            while (paths.Count > 0)
            {
                string current = paths.Pop();

                // Add all subdirectories of the current root to an array
                // Verify they are accessible and push them onto the Stack<string>
                string[] dPaths = null;
                try
                {
                    dPaths = Directory.GetDirectories(current);
                }
                catch (UnauthorizedAccessException e)
                {
                    // DO STUFF
                    continue;
                }
                catch (DirectoryNotFoundException e)
                {
                    // DO MORE STUFF
                    continue;
                }
                foreach (string d in dPaths)
                {
                    paths.Push(d);
                }

                // Add paths of all files in the current directory to an array
                // Create FileInfo objects and add it to the List after verifying they can be accessed
                string[] fPaths = null;
                try
                {
                    fPaths = Directory.GetFiles(current);
                }
                catch (UnauthorizedAccessException e)
                {
                    // SOMEONE FIGURE OUT HOW TO HANDLE THIS
                    continue;
                }
                catch (DirectoryNotFoundException e)
                {
                    // JUST LOG IT OR WHATEVER
                    continue;
                }
                foreach (string f in fPaths)
                {
                    try
                    {
                        FileInfo fileInfo = new FileInfo(f);
                        files.Add(fileInfo);
                        size += fileInfo.Length;
                    }
                    catch (FileNotFoundException e)
                    {
                        // DOCUMENT ERRORS SOMEWHERE
                        continue;
                    }
                }
            }
  
            this.Files = files;
            return size;
        }

        // ***
        // Returns a string that is displayed in the bottom right corner of the MainWindow view
        // Truncates the size of the root directory to one decimal point and add the appropriate suffix
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
