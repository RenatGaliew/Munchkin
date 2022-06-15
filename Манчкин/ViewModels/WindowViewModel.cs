using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors.Core;
using Munchkin.ViewModels;
using Munchkin.Views;

namespace Munchkin.Models
{
    public class WindowViewModel
    {
        public ICommand StartGameCommand { get; set; }

        public WindowViewModel()
        {
            StartGameCommand = new ActionCommand(StartGame);
        }

        private void StartGame()
        {
            MapViewWindow w = new MapViewWindow();
            w.Show();
            w.DataContext = new MapViewModel();
        }
    }
}
