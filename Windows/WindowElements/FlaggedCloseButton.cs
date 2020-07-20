using Igtampe.BasicWindows;
using Igtampe.BasicWindows.WindowElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igtampe.Henja3.Windows.WindowElements {
    public class FlaggedCloseButton:CloseButton {

        public Boolean Flag;
        public FlaggedCloseButton(Window Parent, String Text, ConsoleColor BG, ConsoleColor FG, ConsoleColor HighlightedBG, int LeftPos, int TopPos) : base(Parent,Text,BG,FG,HighlightedBG,LeftPos,TopPos) {Flag = false;}

        public override KeyPressReturn Action() {
            Flag = true;
            return base.Action();
        }
    }
}
