using InputManager;
using System;
using System.Windows.Forms;

namespace Script
{
    public class Teclado
    {
        public static void Pulsar(string tecla, bool mantener = false)
        {
            Keyboard.KeyPress((Keys)Enum.Parse(typeof(Keys), tecla));
        }
    }
}
