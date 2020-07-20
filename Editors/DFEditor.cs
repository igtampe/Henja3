using Igtampe.BasicGraphics;
using Igtampe.BasicRender;
using System;
using System.Text;

namespace Igtampe.Henja3.Editors {
    public class DFEditor:IHenjaEditor {

        private const string ColorWheel = "4C6EA23B9315D087F";
        private int CurrentColorWheelPosition;

        public DFEditor() {CurrentColorWheelPosition = 0;}

        public void KeyPress(ref string[] Document,int X, int Y, ConsoleKeyInfo Key) {
            switch(Key.Key) {
                case ConsoleKey.PageUp:
                    //Move up in the color wheel
                    CurrentColorWheelPosition++;
                    CurrentColorWheelPosition %= ColorWheel.Length;
                    CurrentColorWheelPosition = Math.Abs(CurrentColorWheelPosition);
                    break;
                case ConsoleKey.PageDown:
                    //Move down in the color wheel
                    CurrentColorWheelPosition--;
                    CurrentColorWheelPosition %= ColorWheel.Length;
                    CurrentColorWheelPosition = Math.Abs(CurrentColorWheelPosition);
                    break;
                case ConsoleKey.K:
                    //Pick Color
                    try { CurrentColorWheelPosition = ColorWheel.IndexOf(Document[Y][X]); } catch { CurrentColorWheelPosition = 0; }
                    break;
                case ConsoleKey.Spacebar:
                    //Replace the text at that position
                    StringBuilder TempString = new StringBuilder(Document[Y]);
                    TempString[X] = ColorWheel[CurrentColorWheelPosition];
                    Document[Y] = TempString.ToString() ;
                    BasicGraphic.DrawColorString(ColorWheel[CurrentColorWheelPosition] + "");
                    break;
                default:
                    return;
            }

            Render(ref Document,true);

        }

        public void Render(ref String[] Document,Boolean Partial) {

            //Draw the stored graphic
            if(!Partial) {
                int X = 1;
                foreach(String Line in Document) {
                    RenderUtils.SetPos(0,X);
                    BasicGraphic.DrawColorString(Line);
                    X++;
                }
            }

            //Draw the color wheel
            RenderUtils.SetPos(Console.WindowWidth - ColorWheel.Length - 2,Console.WindowHeight - 2);
            BasicGraphic.DrawColorString(ColorWheel);
            Draw.Row(ConsoleColor.Black,ColorWheel.Length,Console.WindowWidth - ColorWheel.Length - 2,Console.WindowHeight - 1);
            Draw.Block(ConsoleColor.Red,Console.WindowWidth - ColorWheel.Length - 2 + CurrentColorWheelPosition,Console.WindowHeight - 1);

            Draw.Sprite("Use PGUP/PGDOWN to change colors, K to pick color, and SPACE to draw.",ConsoleColor.Black,ConsoleColor.White,0,Console.WindowHeight-1);

        }

        public string[] GenerateNew(int X,int Y) {
            String[] ReturnArray = new string[Y-1];
            for(int y = 0; y < Y-1; y++) {
                ReturnArray[y] = "";

                for(int x = 0; x < X; x++) {ReturnArray[y] += "F";}
            }

            return ReturnArray;
        }

        public string GetName() { return "DF Editor"; }
        public int GetWidth(String[] Document) { return Document[0].Length; }

    }
}
