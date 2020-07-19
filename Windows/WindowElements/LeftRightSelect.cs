using Igtampe.BasicWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igtampe.Henja3.Windows.WindowElements {
    public class LeftRightSelect:Textbox {

        private List<String> Items;
        public int SelectedItem;

        public Textbox(Window Parent, List<String> Items, int Length,int LeftPos,int TopPos,ConsoleColor BG,ConsoleColor HighlightedBG,ConsoleColor FG) : base(Parent) { }


        public override void DrawElement() {
            throw new NotImplementedException();
        }
    }
}
