using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Catel.Data;
using Catel.MVVM;
using Munchkin.Models;
using Munchkin.Views;

namespace Munchkin.ViewModels
{
    public class CardDoorViewModel : ViewModelBase
    {
        public static readonly PropertyData ImageProperty = RegisterProperty<CardDoorViewModel, ImageID>(x => x.Image);
        public static readonly PropertyData CardNameProperty = RegisterProperty<CardDoorViewModel, string>(x => x.CardName);
        public static readonly PropertyData CardName2Property = RegisterProperty<CardDoorViewModel, string>(x => x.CardName2);
        public static readonly PropertyData CardDescriptionProperty = RegisterProperty<CardDoorViewModel, string>(x => x.CardDescription);
        public static readonly PropertyData TextDownProperty = RegisterProperty<CardDoorViewModel, string>(x => x.TextDown);
        public static readonly PropertyData IsTurnOverProperty = RegisterProperty<CardDoorViewModel, bool>(x => x.IsTurnOver);
        public static readonly PropertyData IsCoverProperty = RegisterProperty<CardDoorViewModel, bool>(x => x.IsCover);

        public ImageID Image
        {
            get => GetValue<ImageID>(ImageProperty);
            set => SetValue(ImageProperty, value);
        }
        public string CardName
        {
            get => GetValue<string>(CardNameProperty);
            set => SetValue(CardNameProperty, value);
        }
        public string CardName2
        {
            get => GetValue<string>(CardName2Property);
            set => SetValue(CardName2Property, value);
        }
        public string CardDescription
        {
            get => GetValue<string>(CardDescriptionProperty);
            set => SetValue(CardDescriptionProperty, value);
        }
        public string TextDown
        {
            get => GetValue<string>(TextDownProperty);
            set => SetValue(TextDownProperty, value);
        }
        public bool IsTurnOver
        {
            get => GetValue<bool>(IsTurnOverProperty);
            set => SetValue(IsTurnOverProperty, value);
        }
        public bool IsCover
        {
            get => GetValue<bool>(IsCoverProperty);
            set => SetValue(IsCoverProperty, value);
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

            AnimateCommad = new Command<CardDoorViewModel>(Animate);
        }

        private void Animate(CardDoorViewModel viewModel)
        {
            viewModel.TurnOver();
        }

        private void TurnOver()
        {
            IsTurnOver = true;
            IsCover = !IsCover;
            IsTurnOver = false;
        }

        public Command<CardDoorViewModel> AnimateCommad { get; set; }
    }
}
