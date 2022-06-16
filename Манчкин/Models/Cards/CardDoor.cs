using Munchkin.Models.Cards;
using Munchkin.Views;

namespace Munchkin.Models
{
    public class CardDoor : ICard
    {
        public ImageID Image { get; set; }
        public string CardName { get; set; }
        public string CardName2 { get; set; }
        public string CardDescription { get; set; }
        public string TextDown { get; set; }
    }
}
