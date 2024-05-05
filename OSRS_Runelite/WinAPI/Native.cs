using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static OSRS_Runelite.WinAPI.Structures;

namespace OSRS_Runelite.WinAPI
{
    internal class Native
    {
        [DllImport("gdi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool BitBlt(
            IntPtr hdcDest, 
            int nXDest, 
            int nYDest, 
            int nWidth, 
            int nHeight, 
            IntPtr hdcSrc, 
            int nXSrc, 
            int nYSrc, 
            uint dwRop
        );

        [DllImport("gdi32.dll", SetLastError = true)]
        internal static extern IntPtr CreateCompatibleBitmap(
            IntPtr hdc, 
            int nWidth, 
            int nHeight
        );

        [DllImport("gdi32.dll", SetLastError = true)]
        internal static extern IntPtr CreateCompatibleDC(
            IntPtr hdc
        );

        [DllImport("gdi32.dll", SetLastError = true)]
        internal static extern bool DeleteDC(
            IntPtr hdc
        );

        [DllImport("gdi32.dll", SetLastError = true)]
        internal static extern bool DeleteObject(
            IntPtr hObject
        );

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr FindWindow(
            string lpClassName,
            string lpWindowName
            );

        [DllImport("user32.dll", EntryPoint = "FindWindowEx", CharSet = CharSet.Auto)]
        internal static extern IntPtr FindWindowEx(
            IntPtr hwndParent,
            IntPtr hwndChildAfter,
            string lpszClass,
            string lpszWindow
        );

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern short GetAsyncKeyState(
            int vKey
        );

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool GetCursorPos(
            out POINT lpPoint
        );

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr GetWindowDC(
            IntPtr hwnd
        );

        [DllImport("user32.dll", SetLastError = true)]
        unsafe internal static extern bool GetWindowRect(
            [In] IntPtr hWnd,
            [Out] Structures.RECT* lpRect
        );

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return:MarshalAs(UnmanagedType.Bool)]
        internal static extern bool IsWindowEnabled(
            [In] IntPtr hWnd
        );

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr LoadCursor(
            IntPtr hInstance, 
            int lpCursorName
        );

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        internal static extern uint MapVirtualKey(
            uint uCode,
            uint uMapType
        );

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool PostMessage(
            [In, Optional] IntPtr hWnd,
            [In] uint Msg,
            [In] IntPtr wParam,
            [In] IntPtr lParam
        );

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern int ReleaseDC(
            IntPtr hwnd, 
            IntPtr hdc
        );

        [DllImport("gdi32.dll", SetLastError = true)]
        internal static extern IntPtr SelectObject(
            IntPtr hdc, 
            IntPtr hObject
        );

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr SetCursor(
            IntPtr hCursor
        );

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr WindowFromPoint(
            Structures.POINT point
        );

        #region LParam Functions

        internal static IntPtr MakeLParam(int LoWord, int HiWord)
        {
            return (IntPtr)((HiWord << 16) | (LoWord & 0xFFFF));
        }

        internal static IntPtr MakeKeyDownLParam(uint repeatCount, uint virtualKeyCode, bool extendedKey, bool previousKeyState)
        {
            uint scanCode = MapVirtualKey(virtualKeyCode, 0); // Get scan code from virtual key code

            uint lParam = 0;

            lParam |= repeatCount & 0xFFFF;
            lParam |= (scanCode << 16) & 0xFF0000;
            if (extendedKey)
                lParam |= (1 << 24);
            if (previousKeyState)
                lParam |= (1 << 30);

            return (IntPtr)lParam;
        }

        internal static IntPtr MakeKeyUpLParam(uint virtualKeyCode, bool extendedKey)
        {
            uint lParam = 0;
            uint scanCode = MapVirtualKey(virtualKeyCode, 0); // Get scan code from virtual key code

            lParam |= (1u << 16) & 0xFF0000; // Setting repeat count to 1
            lParam |= (scanCode << 16) & 0xFF0000; // Scan code
            if (extendedKey)
                lParam |= (1u << 24); // Extended key flag
            lParam |= (1u << 30); // Previous key state
            lParam |= (1u << 31); // Transition state

            return (IntPtr)lParam;
        }

        #endregion
    }
}
