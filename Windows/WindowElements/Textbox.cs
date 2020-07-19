using Igtampe.BasicRender;
using Igtampe.BasicWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igtampe.Henja3.Windows.WindowElements {
    public class Textbox:WindowElement {

        private readonly int Length;
        private readonly ConsoleColor BG;
        private readonly ConsoleColor HighlightedBG;
        private readonly ConsoleColor FG;

        public string Text { get; set; }

        public Textbox(Window Parent,int Length, int LeftPos, int TopPos, ConsoleColor BG, ConsoleColor HighlightedBG, ConsoleColor FG) : base(Parent) {
            this.Length = Length;
            this.LeftPos = LeftPos;
            this.TopPos = TopPos;
            this.BG = BG;
            this.HighlightedBG = HighlightedBG;
            this.FG = FG;
        }

        public override KeyPressReturn OnKeyPress(ConsoleKeyInfo Key) {

            switch(Key.Key) {
                case ConsoleKey.Backspace:
                    if(Text.Length > 0) { Text = Text.Remove(Text.Length - 1); }
                    break;
                case ConsoleKey.Enter:
                case ConsoleKey.RightArrow:
                case ConsoleKey.DownArrow:
                    return KeyPressReturn.NEXT_ELEMENT;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.UpArrow:
                    return KeyPressReturn.PREV_ELEMENT;
                case ConsoleKey.Tab:
                    if(Key.Modifiers == ConsoleModifiers.Shift) { return KeyPressReturn.PREV_ELEMENT; }
                    return KeyPressReturn.NEXT_ELEMENT;
                default:
                    Text += Key.KeyChar;
                    break;
            }
            DrawElement();
            return KeyPressReturn.NOTHING;
        }

        public override void DrawElement() {

            ConsoleColor Color = BG;
            if(Highlighted) {Color = HighlightedBG;}

            Draw.Box(Color,Length,1,Parent.LeftPos + LeftPos,Parent.TopPos + TopPos);

            String DrawText = Text;
            if(DrawText.Length > Length) { DrawText = DrawText.Remove(0,DrawText.Length-Length); }

            Draw.Sprite(Text,Color,FG,LeftPos+Parent.LeftPos,TopPos+Parent.TopPos);

        }
    }

    

}
