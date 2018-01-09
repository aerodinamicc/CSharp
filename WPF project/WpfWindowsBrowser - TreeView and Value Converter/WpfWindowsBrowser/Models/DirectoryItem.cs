/// <summary>
/// info about the directory file/folder/drive
/// </summary>
namespace WpfWindowsBrowser.Models
{
    public class DirectoryItem
    {
        public DirectoryItemType Type { get; set; }

        public string FullPath { get; set; }

        public string Name
        {
            get
            {
                return this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFolderName(this.Name);
            }
        }
    }
}
