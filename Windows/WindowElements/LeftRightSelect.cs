using Igtampe.BasicWindows;
using System;
using System.Collections.Generic;

namespace Igtampe.Henja3.Windows.WindowElements {
    public class LeftRightSelect:Textbox {

        private List<String> Items;
        private int selectedItem;

        public int SelectedItem {
            get { return selectedItem; }
            set { 
                selectedItem = Math.Abs(value % Items.Count);
                Text = Items[selectedItem];
            }
        }


        public LeftRightSelect(Window Parent, List<String> Items, int Length,int LeftPos,int TopPos,ConsoleColor BG,ConsoleColor HighlightedBG,ConsoleColor FG) : base(Parent,Length,LeftPos,TopPos,BG,HighlightedBG,FG) {
            this.Items = Items;
            SelectedItem = 0;
        }

        public override KeyPressReturn OnKeyPress(ConsoleKeyInfo Key) {
            switch(Key.Key) {
                case ConsoleKey.LeftArrow:
                    SelectedItem--;
                    break;
                case ConsoleKey.RightArrow:
                    SelectedItem++;
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

    }
}
