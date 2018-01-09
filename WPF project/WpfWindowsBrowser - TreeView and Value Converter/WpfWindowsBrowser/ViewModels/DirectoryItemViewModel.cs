using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfWindowsBrowser.Models;

namespace WpfWindowsBrowser.ViewModels
{
    public class DirectoryItemViewModel
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

        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }

        public bool CanExpand
        {
            get
            {
                return this.Type != DirectoryItemType.File;
            }
        }

        public bool isExpanded
        {
            get
            {
                return this.Children?.Count(c => c != null) > 0;
            }
            set
            {
                //if the UI tells us to expand
                if (value == true)
                {
                    //find all children
                    Expand();
                }
                else
                {
                    this.ClearChildren();
                }
            }
        }

        private void ClearChildren()
        {
            this.Children.Clear();

            if (this.Type != DirectoryItemType.File)
            {
                this.Children.Add(null);
            }

        }

        private void Expand()
        {
            throw new NotImplementedException();
        }
    }
}
