using Catel.Data;
using Munchkin.Models.Cards;
using Munchkin.Views;

namespace Munchkin.ViewModels
{
    public class CardWeaponViewModel : CardBaseViewModel
    {
        public static readonly PropertyData TextDownProperty = RegisterProperty<CardWeaponViewModel, string>(x => x.TextDown);
        public static readonly PropertyData TypeOFAttackProperty = RegisterProperty<CardWeaponViewModel, TypeOfAttack>(x => x.TypeOfAttack);
        public static readonly PropertyData SpecialForProperty = RegisterProperty<CardWeaponViewModel, Army>(x => x.SpecialFor);
        public static readonly PropertyData SpecialForNameProperty = RegisterProperty<CardWeaponViewModel, string>(x => x.SpecialForName);
        public static readonly PropertyData GoldIntProperty = RegisterProperty<CardWeaponViewModel, int>(x => x.GoldInt);
        public static readonly PropertyData BonusIntProperty = RegisterProperty<CardWeaponViewModel, int>(x => x.BonusInt);
        public static readonly PropertyData BonusProperty = RegisterProperty<CardWeaponViewModel, string>(x => x.Bonus);
        public static readonly PropertyData WeaponClassProperty = RegisterProperty<CardWeaponViewModel, WeaponClass>(x => x.WeaponClass);
        public static readonly PropertyData WeaponClassNameProperty = RegisterProperty<CardWeaponViewModel, string>(x => x.WeaponClassName);
        public static readonly PropertyData GoldProperty = RegisterProperty<CardWeaponViewModel, string>(x => x.Gold);

        public string TextDown
        {
            get => GetValue<string>(TextDownProperty);
            set => SetValue(TextDownProperty, value);
        }
        public Army SpecialFor
        {
            get => GetValue<Army>(SpecialForProperty);
            set => SetValue(SpecialForProperty, value);
        } 
        public int GoldInt
        {
            get => GetValue<int>(GoldIntProperty);
            set => SetValue(GoldIntProperty, value);
        }
        public TypeOfAttack TypeOfAttack
        {
            get => GetValue<TypeOfAttack>(TypeOFAttackProperty);
            set => SetValue(TypeOFAttackProperty, value);
        }
        public int BonusInt
        {
            get => GetValue<int>(BonusIntProperty);
            set => SetValue(BonusIntProperty, value);
        }
        public string Bonus
        {
            get => GetValue<string>(BonusProperty);
            set => SetValue(BonusProperty, value);
        }
        public WeaponClass WeaponClass
        {
            get => GetValue<WeaponClass>(WeaponClassProperty);
            set => SetValue(WeaponClassProperty, value);
        }
        public string WeaponClassName
        {
            get => GetValue<string>(WeaponClassNameProperty);
            set => SetValue(WeaponClassNameProperty, value);
        }
        public string Gold
        {
            get => GetValue<string>(GoldProperty);
            set => SetValue(GoldProperty, value);
        }
        public string SpecialForName
        {
            get => GetValue<string>(SpecialForNameProperty);
            set => SetValue(SpecialForNameProperty, value);
        }

        private CardWeapon _model;
        public CardWeaponViewModel(CardWeapon model)
        {
            _model = model;
            IsCover = true;
            Image = ImageID.Weapon;
            /*if (model.Image != null)
            {
                MemoryStream byteStream = new MemoryStream(model.Image);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = byteStream;
                image.EndInit();
                Image = image;
            }*/

            Bonus=model.Bonus;
            BonusInt=model.BonusInt;
            CardDescription=model.CardDescription;
            CardName=model.CardName;
            GoldInt=model.GoldInt;
            SpecialFor=model.SpecialFor;
            TypeOfAttack=model.TypeOfAttack;
            WeaponClass=model.WeaponClass;
            WeaponClassName = Convert(WeaponClass);
            Gold = $"{GoldInt} голдов";
            SpecialForName = Convert(SpecialFor);
        }

        private string Convert(WeaponClass weaponClass)
        {
            switch (weaponClass)
            {
                case WeaponClass.Head: return "Головняк";
                case WeaponClass.OneHand: return "в 1 руку";
                case WeaponClass.TwoHand: return "в 2 руки";
                case WeaponClass.Armor: return "Бронник";
                case WeaponClass.BigArmor: return "Большой Бронник";
                case WeaponClass.Boots: return "Ботинки";
                case WeaponClass.BigOneHand: return "Большой в 1 руку";
                case WeaponClass.Car: return "Тачка";
                case WeaponClass.BigCar: return "Большая Тачка";
                case WeaponClass.Unknown: return "";
                default: return "";
            }
        }

        private string Convert(Army army)
        {
            switch (army)
            {
                case Army.Tyranid: return "Только для тиранидов";
                case Army.Ork: return "Только для орков";
                case Army.Tau: return "Только для тау";
                default: return "";
            }
        }
    }
}
