using System.Windows;
using SPORTs.View;
using SPORTs.Model;

namespace SPORTs
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            LoadImages.loadImages();
            InitializeComponent();
            MainFrame.Navigate(new Authorization());
        }
    }
}
