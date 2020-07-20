using Igtampe.BasicWindows;
using System;

namespace Igtampe.Henja3.Windows.WindowElements {
    public class NumericalTextBox:Textbox {

        private int val;

        public int Value {
            get { return val; }
            set { val = Math.Min(value,MaximumVal);
                Text = val.ToString();
            }
        }

        private readonly int MaximumVal;

        public NumericalTextBox(Window Parent,int MaximumVal,int Length,int LeftPos,int TopPos,ConsoleColor BG,ConsoleColor HighlightedBG,ConsoleColor FG) : base(Parent,Length,LeftPos,TopPos,BG,HighlightedBG,FG) {
            this.MaximumVal = MaximumVal;
            Value = 0;
        }

        public override KeyPressReturn OnKeyPress(ConsoleKeyInfo Key) {
            if(!char.IsLetter(Key.KeyChar)) {
                KeyPressReturn Return;
                String OldText = Text;
                Return = base.OnKeyPress(Key);

                if(OldText != Text) {
                    //if the text was modified update value
                    if(Int32.TryParse(Text,out int tempval)) { Value = tempval; }

                } 
                DrawElement();
                return Return;

            }
            return KeyPressReturn.NOTHING;
        }



    }
}
