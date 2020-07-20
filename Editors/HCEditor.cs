using Igtampe.BasicGraphics;
using Igtampe.BasicRender;
using Igtampe.BasicWindows.ExampleWindows;
using System;
using System.Text;

namespace Igtampe.Henja3.Editors {
    public class HCEditor:IHenjaEditor {

        private const string ColorWheel = "441-460-461-C61-CE0-CE1-CE2-EE2-E10-EA1-AE2-AE1-AA2-AB1-AB2-BB2-3B2-B31-3B2-3B1-3B0-331-932-392-992-192-912-190-110-512-152-551-D52-D51-D50-DD0-4D2-4D1-4D0-440-400-401-402-000-000-802-801-800-882-870-871-872-772-7F0-7F1-7F2-FF2";

        private int currentColorWheelPosition;
        private string ColorString;

        private Boolean CustomColor;

        public int CurrentColorWheelPosition {
            get { return currentColorWheelPosition; }
            set { 
                currentColorWheelPosition = Math.Abs(value % ColorWheel.Split('-').Length);
                ColorString = GetHiColorString(currentColorWheelPosition);
                CustomColor = false;
            }
        }        

        public HCEditor() { CurrentColorWheelPosition = 0; }

        public string GetName() { return "HC Editor"; }
        public int GetWidth(String[] Document) { return Document[0].Split('-').Length; }

        public void KeyPress(ref string[] Document,int X,int Y,ConsoleKeyInfo Key) {
            switch(Key.Key) {
                case ConsoleKey.PageUp:
                    //Move up in the color wheel
                    CurrentColorWheelPosition++;
                    break;
                case ConsoleKey.PageDown:
                    //Move down in the color wheel
                    CurrentColorWheelPosition--;
                    break;
                case ConsoleKey.K:
                    //Pick Color
                    ColorString = Document[Y].Split('-')[X];
                    CustomColor = true;
                    break;
                case ConsoleKey.C:
                    new HelloWorldWindow().Execute();
                    break;
                case ConsoleKey.Spacebar:
                    //Replace the text at that position
                    string[] Line = Document[Y].Split('-');
                    Line[X] = ColorString;
                    Document[Y] = String.Join("-",Line);
                    HiColorGraphic.HiColorDraw(ColorString);
                    break;
                default:
                    return;
            }

            Render(ref Document,true);

        }

        public void Render(ref String[] Document, Boolean Partial) {
            //Draw the stored graphic
            if(!Partial) {
                int X = 1;
                foreach(String Line in Document) {
                    RenderUtils.SetPos(0,X);
                    HiColorGraphic.HiColorDraw(Line);
                    X++;
                }
            }


            //Draw the color wheel
            RenderUtils.SetPos(Console.WindowWidth - ColorWheel.Split('-').Length - 4,Console.WindowHeight - 2);
            HiColorGraphic.HiColorDraw(ColorString+"-000-"+ColorWheel);
            ConsoleColor PickerColor;
            if(CustomColor) { PickerColor = ConsoleColor.Red; } else { PickerColor = ConsoleColor.DarkRed; }

            Draw.Row(ConsoleColor.Black,ColorWheel.Split('-').Length,Console.WindowWidth - ColorWheel.Split('-').Length - 2,Console.WindowHeight - 1);
            Draw.Block(PickerColor,Console.WindowWidth - ColorWheel.Split('-').Length - 2 + CurrentColorWheelPosition,Console.WindowHeight - 1);

            Draw.Sprite("Use PGUP/PGDOWN to change colors, C to open the\nold color editor, K to pick color, and SPACE to draw.",ConsoleColor.Black,ConsoleColor.White,0,Console.WindowHeight - 2);

        }

        public string[] GenerateNew(int X,int Y) {
            String[] ReturnArray = new string[Y - 1];
            for(int y = 0; y < Y; y++) {
                ReturnArray[y] = "";
                for(int x = 0; x < X; x++) { ReturnArray[y] += "FF0-"; }
                ReturnArray[y]=ReturnArray[y].TrimEnd('-');
            }

            return ReturnArray;
        }


        private String GetHiColorString(int pos) {return ColorWheel.Split('-')[pos];}

    }
}
