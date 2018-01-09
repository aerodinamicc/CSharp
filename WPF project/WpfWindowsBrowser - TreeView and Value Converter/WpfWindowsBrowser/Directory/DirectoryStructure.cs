using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using WpfWindowsBrowser.Models;

namespace WpfWindowsBrowser
{
    /// <summary>
    /// this class will contain the logic for quering the directories
    /// </summary>

    public static class DirectoryStructure
    {
        public static List<DirectoryItem> GetLogicalDrives()
        {
            return Directory.GetLogicalDrives().Select(
                drive => new DirectoryItem()
                {
                    FullPath = drive,
                    Type = DirectoryItemType.Drive
                }).ToList();
        }

        public static List<DirectoryItem> DirectoryContent(string fullPath)
        {
            #region Get directories
            var items = new List<DirectoryItem>();

            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                {
                    items.AddRange(dirs.Select(d => new DirectoryItem()
                    {
                        FullPath = d,
                        Type = DirectoryItemType.Folder
                    }));
                }
            }
            catch { }
            #endregion
            #region Get files
            var files = new List<DirectoryItem>();

            try
            {
                var fs = Directory.GetFiles(fullPath);
                if (fs.Length > 0)
                {
                    items.AddRange(fs.Select(f => new DirectoryItem()
                    {
                        FullPath = f,
                        Type = DirectoryItemType.File
                    }));
                }
            }
            catch { }

            return items;
            #endregion
        }

        public static string GetFolderName(string dirPath)
        {
            if (string.IsNullOrEmpty(dirPath))
            {
                return string.Empty;
            }

            //make it universal, regardless of whether / or \ is used
            string normalizedPath = dirPath.Replace('/', '\\');

            var lastIndex = normalizedPath.LastIndexOf('\\');

            if (lastIndex <= 0)
            {
                return dirPath;
            }

            return dirPath.Substring(lastIndex + 1);
        }
    }
}
