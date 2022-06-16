using System;
using Catel.Data;
using Catel.MVVM;
using Munchkin.Views;

namespace Munchkin.ViewModels
{
    public interface ICardBase
    {
        public event EventHandler TurnOver;
        public ImageID Image { get; }
        public string CardName { get; }
        public string CardDescription { get; }
        public bool IsCover { get; }
    }

    public abstract class CardBaseViewModel: ViewModelBase, ICardBase
    {
        public event EventHandler TurnOver;
        public static readonly PropertyData ImageProperty = RegisterProperty<CardBaseViewModel, ImageID>(x => x.Image);
        public static readonly PropertyData CardNameProperty = RegisterProperty<CardBaseViewModel, string>(x => x.CardName);
        public static readonly PropertyData CardDescriptionProperty = RegisterProperty<CardBaseViewModel, string>(x => x.CardDescription);
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
        public string CardDescription
        {
            get => GetValue<string>(CardDescriptionProperty);
            set => SetValue(CardDescriptionProperty, value);
        }
        public bool IsCover
        {
            get => GetValue<bool>(IsCoverProperty);
            set => SetValue(IsCoverProperty, value);
        }
        public Command<CardWeaponViewModel> AnimateCommad { get; }

        public CardBaseViewModel()
        {
            AnimateCommad = new Command<CardWeaponViewModel>(Animate);
        }

        private void Animate(CardWeaponViewModel viewModel)
        {
            TurnOver?.Invoke(this, EventArgs.Empty);
        }
    }
}