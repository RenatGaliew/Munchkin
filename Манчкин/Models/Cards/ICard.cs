using Munchkin.Views;

namespace Munchkin.Models.Cards
{
    public interface ICard
    {
        public ImageID Image { get; set; }
        public string CardName { get; set; }
        public string CardDescription { get; set; }
    }
}