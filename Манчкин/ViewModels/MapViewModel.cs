using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using Catel.Data;
using Catel.MVVM;
using Munchkin.Models;
using Munchkin.Views;

namespace Munchkin.ViewModels
{
    public class MapViewModel : ViewModelBase
    {
        public static readonly PropertyData CardsProperty = RegisterProperty<MapViewModel, ObservableCollection<CardDoorViewModel>>(x => x.Cards);

        public ObservableCollection<CardDoorViewModel> Cards
        {
            get => GetValue<ObservableCollection<CardDoorViewModel>>(CardsProperty);
            set => SetValue(CardsProperty, value);
        }

        public MapViewModel()
        {
            Cards = new ObservableCollection<CardDoorViewModel>();
            Cards.Add(new CardDoorViewModel(new CardDoor()
            {
                CardDescription = "Играй вместе с монстром с руки в любой бой (можно и в свой). Твой монстр присоединяется к тем, что уже бьются, - сложи их боевые силы. При поражении манчкин бившийся с ними делает отдельные броски смывки в любом угодном ему порядке.",
                CardName = "Бродячая тварь",
                CardName2 = "",
                TextDown = "",
                Image = ImageID.Goblin
            }));
            Cards.Add(new CardDoorViewModel(new CardDoor()
            {
                CardDescription = "Играй в любой бой на любого монстра. Побежденный шипастый монстр даёт на одно сокровище больше",
                CardName = "Шипастый",
                CardName2 = "+5 МОНСТРУ",
                TextDown = "+1 сокровище",
                Image = ImageID.Goblin
            }));
        }

        public byte[] ImageToByteArray(BitmapImage imageIn)
        {
            byte[] data;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageIn));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            return data;
        }
    }
}
