using System;
using System.Windows;

namespace LettersOnTheTrack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new TrackViewModel();
        }
    }
}
