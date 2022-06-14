using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using Munchkin.Models;
using Munchkin.Views;

namespace Munchkin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public WindowViewModel WindowViewModel = new WindowViewModel();
        public MainWindow()
        {
            InitializeComponent();

        }
    }
}
