using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRS_Runelite.WinAPI
{
    internal class Constants
    {
        // # PostMessages
        #region Post Message constants

        #region Windows

        // Window Focus
        internal const int WM_ACTIVATE = 0x0006;
        internal const int WA_ACTIVE = 1;

        #endregion

        #region Keyboard

        internal const int WM_KEYDOWN = 0x0100;
        internal const int WM_KEYUP = 0x0101;

        #endregion

        #region Mouse
        internal const int WM_MOUSEMOVE = 0x0200;
        internal const int WM_LBUTTONDOWN = 0x0201;
        internal const int WM_LBUTTONUP = 0x0202;
        internal const int WM_RBUTTONDOWN = 0x0204;
        internal const int WM_RBUTTONUP = 0x0205;
        // # https://learn.microsoft.com/en-us/windows/win32/inputdev/wm-mousewheel
        internal const int WM_MOUSEWHEEL = 0x020A;
        internal const int WM_MBUTTONDOWN = 0x0207;
        internal const int WM_MBUTTONUP = 0x0208;
        #endregion

        #region Cusor Types
        internal const int IDC_ARROW = 32512;
        internal const int IDC_TARGET = 32640;
        #endregion

        #region Mouse Button Keys
        internal const int VK_LBUTTON = 0x01;
        #endregion

        #region BitBlt
        // Define the TernaryRasterOperations enumeration for BitBlt
        internal const uint SRCCOPY = 0x00CC0020;
        #endregion

        #endregion

        internal const short VK_SHIFT = 0x10;
    }
}
