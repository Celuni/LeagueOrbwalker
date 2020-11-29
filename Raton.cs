using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Script
{
    public class Raton
    {
        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        private const int MOUSEEVENT_LEFTDOWN = 0x02;
        private const int MOUSEEVENT_LEFTUP = 0x04;
        private const int MOUSEEVENT_MIDDLEDOWN = 0x20;
        private const int MOUSEEVENT_MIDDLEUP = 0x40;
        private const int MOUSEEVENT_RIGHTDOWN = 0x08;
        private const int MOUSEEVENT_RIGHTUP = 0x10;

        public static void clickDerecho(int X, int Y)
        {
            mouse_event(MOUSEEVENT_RIGHTDOWN, X, Y, 0, 0);
            mouse_event(MOUSEEVENT_RIGHTUP, X, Y, 0, 0);
        }
        public static void clickIzquierdo(int X, int Y)
        {
            mouse_event(MOUSEEVENT_LEFTDOWN, X, Y, 0, 0);
            mouse_event(MOUSEEVENT_LEFTUP, X, Y, 0, 0);
        }
    }
}
