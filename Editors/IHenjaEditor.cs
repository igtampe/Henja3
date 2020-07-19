using System;

namespace Igtampe.Henja3.Editors {
    public interface IHenjaEditor {
        void KeyPress(ref String[] Document,int X, int Y, ConsoleKeyInfo Key);
        void Render(ref String[] Document);
        String GetName();
        String[] GenerateNew(int X,int Y);
    }
}
