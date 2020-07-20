using Igtampe.BasicGraphics;
using Igtampe.BasicWindows;
using Igtampe.BasicWindows.WindowElements;
using Igtampe.Henja3.Windows.WindowElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igtampe.Henja3.Windows {
    public class HiColorPicker:Window {

        private const string ColorWheel = "4C6EA23B9315D087F";

        private class Rainbow:BasicGraphic{
            public Rainbow() {
                String[] Rainbow = {ColorWheel };
                Contents = Rainbow;
                Name = "Rainbow";
            }
        }


        private readonly Slider Slider1;
        private readonly Slider Slider2;
        private readonly Slider Slider3;
        private readonly FlaggedCloseButton OKButton;


        public HiColorPicker():base("HiColor Color Picker","=========[HiColor Color Picker]=========".Length,10) {

            Rainbow RainbowGraphic = new Rainbow();


            Label MegaLabel = new Label(this,"Color 1:                   Shade: ░▒▓\n\n" +
                                             "Color 2:",ConsoleColor.Gray,ConsoleColor.Black,1,2);
            Image Rainbow1 = new Image(this,RainbowGraphic,10,2);
            Image Rainbow2 = new Image(this,RainbowGraphic,10,5);
            Slider1 = new Slider(this,RainbowGraphic.GetWidth(),10,3,ConsoleColor.DarkGray,ConsoleColor.DarkBlue,ConsoleColor.Red);
            Slider2 = new Slider(this,RainbowGraphic.GetWidth(),10,6,ConsoleColor.DarkGray,ConsoleColor.DarkBlue,ConsoleColor.Red);
            Slider3 = new Slider(this,3,35,3,ConsoleColor.DarkGray,ConsoleColor.DarkBlue,ConsoleColor.Red);
            OKButton = new FlaggedCloseButton(this,"[     OK     ]",ConsoleColor.DarkGray,ConsoleColor.White,ConsoleColor.DarkBlue,3,8);
            CloseButton Cancelbutton = new CloseButton(this,"[   CANCEL   ]",ConsoleColor.DarkGray,ConsoleColor.White,ConsoleColor.DarkBlue,24,8);

            WindowElement[] AddIt = { MegaLabel,Rainbow1,Rainbow2,Slider1,Slider2,Slider3,OKButton,Cancelbutton };
            AllElements.AddRange(AddIt);

            //Link elements
            Slider1.NextElement = Slider2;
            Slider2.PreviousElement = Slider1;
            Slider2.NextElement = Slider3;
            Slider3.PreviousElement = Slider2;
            Slider3.NextElement = OKButton;
            OKButton.PreviousElement = Slider3;
            OKButton.NextElement = Cancelbutton;
            Cancelbutton.PreviousElement = OKButton;
            Cancelbutton.NextElement = Slider1;
            Slider1.PreviousElement = Cancelbutton;

            //Highlight elements
            HighlightedElement = Slider1;
            Slider1.Highlighted = true;

        }

        public Boolean OK() { return OKButton.Flag; }
        public string GetResultColorString() {return ColorWheel[Slider1.SliderPosition].ToString() + ColorWheel[Slider2.SliderPosition].ToString() + Slider3.SliderPosition.ToString();}
    }
}
