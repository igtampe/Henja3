using Igtampe.BasicRender;
using Igtampe.BasicWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igtampe.Henja3.Windows.WindowElements {
    public class Slider:Textbox {

        private int sliderPosition;

        public int SliderPosition {
            get { return sliderPosition; }
            set { sliderPosition = value % Length; }
        }
        

        public Slider(Window Parent,int Length,int LeftPos,int TopPos,ConsoleColor BG,ConsoleColor HighlightedBG,ConsoleColor FG) : base(Parent,Length,LeftPos,TopPos,BG,HighlightedBG,FG) {SliderPosition = 0;}


        public override KeyPressReturn OnKeyPress(ConsoleKeyInfo Key) {
            switch(Key.Key) {
                case ConsoleKey.LeftArrow:
                    SliderPosition--;
                    break;
                case ConsoleKey.RightArrow:
                    SliderPosition++;
                    break;
                case ConsoleKey.Enter:
                case ConsoleKey.DownArrow:
                    return KeyPressReturn.NEXT_ELEMENT;
                case ConsoleKey.UpArrow:
                    return KeyPressReturn.PREV_ELEMENT;
                case ConsoleKey.Tab:
                    if(Key.Modifiers == ConsoleModifiers.Shift) { return KeyPressReturn.PREV_ELEMENT; }
                    return KeyPressReturn.NEXT_ELEMENT;
                default:
                    return KeyPressReturn.NOTHING;
            }
            DrawElement();
            return KeyPressReturn.NOTHING;

        }


        public override void DrawElement() {
            base.DrawElement();

            //Draw the slider bit.
            Draw.Block(FG,Parent.LeftPos + LeftPos + SliderPosition,TopPos + Parent.TopPos);

        }

    }
}
