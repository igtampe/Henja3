using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Igtampe.Henja3.Editors;
using Igtampe.BasicRender;
using Igtampe.BasicGraphics;
using System.IO;
using Igtampe.Henja3.Windows;

namespace Igtampe.Henja3 {
    class Program {

        private static string[] CurrentDocument;
        private static string Filename;
        private static int CurrentX;
        private static int CurrentY;

        private static IHenjaEditor Editor;

        public static void Main(string[] args) {
            Console.SetWindowSize(160,50);
            Console.SetBufferSize(160,50);

            CurrentX = 0;
            CurrentY = 0;

            Console.Title = "Henja BasicGraphic Editor [Version 3.0] " + string.Join(" ",args);

            Redraw();

            if(args.Length == 1) {
                //Load a file.
                if(!File.Exists(args[0])) {
                    new ErrorWindow("File not found!").Execute();
                    return;
                }

                Filename = args[0];

                if(Filename.ToUpper().EndsWith(".DF")) { Editor = new DFEditor(); } else if(Filename.ToUpper().EndsWith(".HC")) { Editor = new HCEditor(); } else {
                    new ErrorWindow("I don't know how to process " + Filename + ". It should end with .DF or .HC!").Execute();
                    return;
                }

                CurrentDocument = File.ReadAllLines(Filename);
                Type();

            } else {
                //new file
                NewFileWindow FileWindow = new NewFileWindow();
                FileWindow.Execute();
                if(FileWindow.OKButton.Flag) {

                    Filename = FileWindow.Namebox.Text;

                    switch(FileWindow.ModeBox.SelectedItem) {
                        case 0:
                            Editor = new DFEditor();
                            if(!Filename.ToUpper().EndsWith(".DF")) { Filename += ".df"; }
                            break;
                        case 1:
                            Editor = new HCEditor();
                            if(!Filename.ToUpper().EndsWith(".HC")) { Filename += ".hc"; }
                            break;
                        default:
                            return;
                    }

                    CurrentDocument=Editor?.GenerateNew(FileWindow.XBox.Value,FileWindow.YBox.Value);
                    Type();
                }

            }
            RenderUtils.Pause();

        }

        private static void Type() {

            ConsoleKeyInfo CurrentKey;
            Redraw();

            while(true) {

                RenderUtils.SetPos(CurrentX,CurrentY + 1);
                CurrentKey = Console.ReadKey(true);

                //Save the file
                if(CurrentKey.Modifiers == ConsoleModifiers.Control && CurrentKey.Key == ConsoleKey.S) { File.WriteAllLines(Filename,CurrentDocument); } 
                else {
                    switch(CurrentKey.Key) {
                        case ConsoleKey.LeftArrow:
                            CurrentX = Math.Max(0,CurrentX - 1);
                            break;
                        case ConsoleKey.RightArrow:
                            CurrentX = Math.Min(Editor.GetWidth(CurrentDocument)-1,CurrentX + 1);
                            break;
                        case ConsoleKey.UpArrow:
                            CurrentY = Math.Max(0,CurrentY - 1);
                            break;
                        case ConsoleKey.DownArrow:
                            CurrentY = Math.Max(CurrentDocument.Length,CurrentY + 1);
                            break;
                        default:
                            Editor.KeyPress(ref CurrentDocument, CurrentX,CurrentY,CurrentKey);
                            break;
                    }
                
                }


            }

        
        }

        private static void Redraw() {
            if(Console.WindowWidth < 80) {Console.SetWindowSize(80,Console.WindowHeight);}
            if(Console.WindowHeight < 25) { Console.SetWindowSize(Console.WindowWidth,25); }

            RenderUtils.Color(ConsoleColor.DarkBlue,ConsoleColor.White);
            Console.Clear();

            Draw.Row(ConsoleColor.Black,Console.WindowWidth-1,0,0);
            Draw.Box(ConsoleColor.Black,Console.WindowWidth-1,2,0,Console.WindowHeight - 2);

            Draw.Sprite("Henja 3 | " + Editor?.GetName(),ConsoleColor.Black,ConsoleColor.White,0,0);

            Editor?.Render(ref CurrentDocument,false);


        }

    }
}
