using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using static OSRS_Runelite.WinAPI.Constants;
using static OSRS_Runelite.WinAPI.Structures;
using static OSRS_Runelite.WinAPI.Native;

namespace OSRS_Runelite.UI.Mouse
{
    public static class MouseCursorHandler
    {

        // Function to change cursor to target
        public static void SetCursorToTarget()
        {
            IntPtr targetCursor = LoadCursor(IntPtr.Zero, IDC_TARGET);
            SetCursor(targetCursor);
        }

        // Function to revert cursor back to arrow
        public static void SetCursorToArrow()
        {
            IntPtr arrowCursor = LoadCursor(IntPtr.Zero, IDC_ARROW);
            SetCursor(arrowCursor);
        }

        // Function to get window handle under mouse cursor
        public static IntPtr GetWindowHandleUnderMouse()
        {
            POINT cursorPos;
            GetCursorPos(out cursorPos);
            IntPtr hWnd = WindowFromPoint(cursorPos);
            return hWnd;
        }

        // Function to wait for left mouse button click
        public static void WaitForLeftMouseClick()
        {
            Console.WriteLine("Waiting for left mouse button click...");
            while (true)
            {
                // Check if the left mouse button is clicked
                if (GetAsyncKeyState(VK_LBUTTON) < 0)
                {
                    break;
                }
                // Sleep to avoid high CPU usage
                Thread.Sleep(100);
            }
        }
    }
}
