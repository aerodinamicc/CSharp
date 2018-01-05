using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace WpfWindowsBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        #region Loaded
         /// <summary>
         /// Loads on start of the application
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var drive in Directory.GetLogicalDrives())
            {
                var item = new TreeViewItem()
                {
                    Header = drive.ToString(),
                    Tag = drive.ToString()
                };

                item.Items.Add(null);

                //Listen for an item being expanded

                item.Expanded += FolderExpanded;

                FolderView.Items.Add(item);
            }
            
        }

        private void FolderExpanded(object sender, RoutedEventArgs e)
        {
            #region Initial checks
                        var item = (TreeViewItem)sender;

                        if (item.Items.Count != 1 || item.Items[0] != null)
                        {
                            return;
                        }

                        //Clear dummy data
                        item.Items.Clear();

                        var fullPath = (string)item.Tag;

                        #endregion
            #region Get directories
            var directories = new List<string>();

            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                {
                    directories.AddRange(dirs);
                }

                directories.ForEach(dirPath =>
                {
                    var subItem = new TreeViewItem()
                    {
                        Header = GetFolderName(dirPath),
                        Tag = dirPath
                    };

                    subItem.Items.Add(null);

                    subItem.Expanded += FolderExpanded;

                    item.Items.Add(subItem);
                });
            }
            catch { }
            #endregion
            #region Get files
            var files = new List<string>();

            try
            {
                var fs = Directory.GetFiles(fullPath);
                if (fs.Length > 0)
                {
                    files.AddRange(fs);
                }

                files.ForEach(dirPath =>
                {
                    var subItem = new TreeViewItem()
                    {
                        Header = GetFolderName(dirPath),
                        Tag = dirPath
                    };

                    item.Items.Add(subItem);
                });
            }
            catch { }
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

        #endregion  
}
