using System.IO;
using System.Windows.Media.Imaging;
using Catel.Data;
using Catel.MVVM;
using Munchkin.Models;
using Munchkin.Models.Cards;
using Munchkin.Views;

namespace Munchkin.ViewModels
{
    public class MapViewModel : ViewModelBase
    {
        public static readonly PropertyData CardsProperty = RegisterProperty<MapViewModel, CardDoorViewModel>(x => x.Card);
        public static readonly PropertyData CardWeaponProperty = RegisterProperty<MapViewModel, CardWeaponViewModel>(x => x.CardWeapon);

        public CardDoorViewModel Card
        {
            get => GetValue<CardDoorViewModel>(CardsProperty);
            set => SetValue(CardsProperty, value);
        }
        
        public CardWeaponViewModel CardWeapon
        {
            get => GetValue<CardWeaponViewModel>(CardWeaponProperty);
            set => SetValue(CardWeaponProperty, value);
        }

        public MapViewModel()
        {
            Card = new CardDoorViewModel(new CardDoor()
            {
                CardDescription =
                    "Играй вместе с монстром с руки в любой бой (можно и в свой). Твой монстр присоединяется к тем, что уже бьются, - сложи их боевые силы. При поражении манчкин бившийся с ними делает отдельные броски смывки в любом угодном ему порядке.",
                CardName = "Бродячая тварь",
                CardName2 = "",
                TextDown = "",
                Image = ImageID.Goblin
            });

            CardWeapon = new CardWeaponViewModel(new CardWeapon()
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
            });
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
