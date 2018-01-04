using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFBasics
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

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"The description is {this.DescriptionText.Text}");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            this.TableCheckBox.IsChecked = this.ChairCheckBox.IsChecked = this.WardrobeCheckBox.IsChecked =
                this.SofaCheckBox.IsChecked = this.PoufCheckBox.IsChecked = this.BedCheckBox.IsChecked =
                this.LampCheckBox.IsChecked = this.ShelfCheckBox.IsChecked = false;

            this.SelectedText.Text = "";
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            this.SelectedText.Text += ((CheckBox)sender).Content;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.NotesText == null)
            {
                return;
            }

            var box = (ComboBox)sender;
                var content = (ComboBoxItem)box.SelectedValue;

                this.NotesText.Text = (string)content.Content;
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox_SelectionChanged(this.FinishedDropdown, null);
        }
    }
}
