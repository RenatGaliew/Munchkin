using System;
using Catel.Data;
using Catel.MVVM;
using Munchkin.Models;
using Munchkin.Views;

namespace Munchkin.ViewModels
{
    public class CardDoorViewModel : CardBaseViewModel
    {
        public static readonly PropertyData CardName2Property = RegisterProperty<CardDoorViewModel, string>(x => x.CardName2);
        public static readonly PropertyData TextDownProperty = RegisterProperty<CardDoorViewModel, string>(x => x.TextDown);
        
        public string CardName2
        {
            get => GetValue<string>(CardName2Property);
            set => SetValue(CardName2Property, value);
        }
      
        public string TextDown
        {
            get => GetValue<string>(TextDownProperty);
            set => SetValue(TextDownProperty, value);
        }

        public CardDoorViewModel(CardDoor model)
        {
            IsCover = true;
            Image = ImageID.Goblin;
            /*if (model.Image != null)
            {
                MemoryStream byteStream = new MemoryStream(model.Image);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = byteStream;
                image.EndInit();
                Image = image;
            }*/

            CardName = model.CardName;
            CardName2 = model.CardName2;
            CardDescription = model.CardDescription;
            TextDown = model.TextDown;
        }
    }
}
