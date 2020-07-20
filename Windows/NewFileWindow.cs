using Igtampe.BasicWindows;
using Igtampe.BasicWindows.WindowElements;
using Igtampe.Henja3.Windows.WindowElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igtampe.Henja3.Windows {
    public class NewFileWindow:Window {

        public Textbox Namebox;
        public LeftRightSelect ModeBox;
        public NumericalTextBox XBox;
        public NumericalTextBox YBox;
        public FlaggedCloseButton OKButton;


        public NewFileWindow() : base("New File","==================[New File]================".Length,10) {
            //haha I still will not count it.

            //Megalabel
            AllElements.Add(new Label(this,"Name of File:\n\nMode of File\n\nSize of File:     x",ConsoleColor.Gray,ConsoleColor.Black,1,2));

            //FielName box
            Namebox = new Textbox(this,28,15,2,ConsoleColor.DarkGray,ConsoleColor.DarkBlue,ConsoleColor.White);
            AllElements.Add(Namebox);

            String[] Items = { "DF Editor","HC Editor" };

            //ModeBox
            ModeBox = new LeftRightSelect(this,new List<string>(Items),28,15,4,ConsoleColor.DarkGray,ConsoleColor.DarkBlue,ConsoleColor.White);
            AllElements.Add(ModeBox);

            //XBox and YBox
            XBox = new NumericalTextBox(this,150,3,15,6,ConsoleColor.DarkGray,ConsoleColor.DarkBlue,ConsoleColor.White);
            YBox = new NumericalTextBox(this,40,3,21,6,ConsoleColor.DarkGray,ConsoleColor.DarkBlue,ConsoleColor.White);
            AllElements.Add(XBox);
            AllElements.Add(YBox);

            //OKButton
            OKButton = new FlaggedCloseButton(this,"[     OK     ]",ConsoleColor.DarkGray,ConsoleColor.White,ConsoleColor.DarkBlue,5,8);
            AllElements.Add(OKButton);

            //CancelButton
            CloseButton Cancelbutton = new CloseButton(this,"[   CANCEL   ]",ConsoleColor.DarkGray,ConsoleColor.White,ConsoleColor.DarkBlue,26,8);
            AllElements.Add(Cancelbutton);

            //Link elements
            Namebox.NextElement = ModeBox;
            ModeBox.PreviousElement = Namebox;
            ModeBox.NextElement = XBox;
            XBox.PreviousElement = ModeBox;
            XBox.NextElement = YBox;
            YBox.PreviousElement = XBox;
            YBox.NextElement = OKButton;
            OKButton.PreviousElement = YBox;
            OKButton.NextElement = Cancelbutton;
            Cancelbutton.PreviousElement = OKButton;
            Cancelbutton.NextElement = Namebox;
            Namebox.PreviousElement = Cancelbutton;

            //Highlight Element.
            HighlightedElement = Namebox;
            Namebox.Highlighted = true;

        }




    }
}
