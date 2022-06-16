using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Munchkin.Views;

namespace Munchkin.Models.Cards
{
    public enum WeaponClass
    {
        Head,
        OneHand,
        TwoHand,
        Armor,
        BigArmor,
        Boots,
        BigOneHand,
        Car,
        BigCar,
        Unknown,
    }

    public enum TypeOfAttack
    {
        Default,
        Fire,
    }
    
    public enum Army
    {
        Tyranid,
        Ork,
        Tau,

    }

    public class CardWeapon : ICard
    {
        public ImageID Image { get; set; }
        public string CardName { get; set; }
        public string Bonus { get; set; }
        public int BonusInt { get; set; }
        public string CardDescription { get; set; }
        public int GoldInt { get; set; }
        public WeaponClass WeaponClass { get; set; }
        public Army SpecialFor { get; set; }
        public TypeOfAttack TypeOfAttack { get; set; }
    }
}
