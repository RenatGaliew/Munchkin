using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Data;
using Catel.MVVM;
using Munchkin.Models.Cards;
using Munchkin.Views;

namespace Munchkin.ViewModels
{
    public class CardOnHandsViewModel : ViewModelBase
    {
        public static readonly PropertyData CardsOnHandProperty = RegisterProperty<CardOnHandsViewModel, ObservableCollection<CardBaseViewModel>>(x => x.CardsOnHand); 
        public ObservableCollection<CardBaseViewModel> CardsOnHand
        {
            get => GetValue<ObservableCollection<CardBaseViewModel>>(CardsOnHandProperty);
            set => SetValue(CardsOnHandProperty, value);
        }

        public CardOnHandsViewModel()
        {
            CardsOnHand = new ObservableCollection<CardBaseViewModel>();
            CardsOnHand.Add(new CardWeaponViewModel(new CardWeapon()
            {
                Bonus = "Бонус +3",
                CardDescription = "Это огненная/ пламенная атака",
                CardName = "Электромагнитный бластер",
                TypeOfAttack = TypeOfAttack.Fire,
                WeaponClass = WeaponClass.OneHand,
                GoldInt = 400,
                BonusInt = 3,
                Image = ImageID.Weapon,
                SpecialFor = Army.Ork,
            })
            {
                IsCover = false
            }); 
            CardsOnHand.Add(new CardWeaponViewModel(new CardWeapon()
            {
                Bonus = "Бонус +5",
                CardDescription = "",
                CardName = "Суперский бронник",
                TypeOfAttack = TypeOfAttack.Fire,
                WeaponClass = WeaponClass.BigArmor,
                GoldInt = 700,
                BonusInt = 3,
                Image = ImageID.Weapon,
                SpecialFor = Army.Tau
            })
            {
                IsCover = false
            });
            CardsOnHand.Add(new CardWeaponViewModel(new CardWeapon()
            {
                Bonus = "Бонус +3",
                CardDescription = "Это огненная/ пламенная атака",
                CardName = "Электромагнитный бластер",
                TypeOfAttack = TypeOfAttack.Fire,
                WeaponClass = WeaponClass.OneHand,
                GoldInt = 400,
                BonusInt = 3,
                Image = ImageID.Weapon,
                SpecialFor = Army.Ork
            })
            {
                IsCover = false
            });
            CardsOnHand.Add(new CardWeaponViewModel(new CardWeapon()
            {
                Bonus = "Бонус +3",
                CardDescription = "Это огненная/ пламенная атака",
                CardName = "Электромагнитный бластер",
                TypeOfAttack = TypeOfAttack.Fire,
                WeaponClass = WeaponClass.OneHand,
                GoldInt = 400,
                BonusInt = 3,
                Image = ImageID.Weapon,
                SpecialFor = Army.Ork
            })
            {
                IsCover = false
            });
            CardsOnHand.Add(new CardWeaponViewModel(new CardWeapon()
            {
                Bonus = "Бонус +3",
                CardDescription = "Это огненная/ пламенная атака",
                CardName = "Электромагнитный бластер",
                TypeOfAttack = TypeOfAttack.Fire,
                WeaponClass = WeaponClass.OneHand,
                GoldInt = 400,
                BonusInt = 3,
                Image = ImageID.Weapon,
                SpecialFor = Army.Ork
            })
            {
                IsCover = false
            });
        }
    }
}
