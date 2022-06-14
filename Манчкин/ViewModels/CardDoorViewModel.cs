using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Munchkin.ViewModels
{
    public class CardDoorViewModel
    {
        public ImageSource Image { get; set; }
        public string CardName { get; set; }
        public string CardName2 { get; set; }
        public string CardDescription { get; set; }
        public string TextDown { get; set; }
    }
}
