using Microsoft.VisualBasic.Devices;
using OSRS_Runelite.API.Wrappers.Interactive;
using OSRS_Runelite.WinAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OSRS_Runelite.API.Input
{
    internal class Mouse
    {

        private static object _CURRENT_POSITION;
        internal static object CurrentPosition
        {
            get { return _CURRENT_POSITION; }
        }
        internal static bool LeftClick(RSPoint rsPoint)
        {
            return LeftClick(rsPoint.X, rsPoint.Y);
        }

        // Done
        internal static bool LeftClick(int x, int y)
        {

            if (!SetPosition(x, y))
            {
                return false;
            }

            Thread.Sleep(Helper.Randoms.RandomNumber(35, 100));

            if (!LeftDown(x, y))
            {
                return false;
            }

            Thread.Sleep(Helper.Randoms.RandomNumber(35, 100));

            if (!LeftUp(x, y))
            {
                return false;
            }

            return true;
        }

        internal static bool LeftClickShift(int x, int y)
        {
            if (!Keyboard.KeyDown(Constants.VK_SHIFT))
            {
                return false;
            }

            // Thread.Sleep(Helper.Randoms.RandomNumber(50, 100));
            Thread.Sleep(Helper.Randoms.RandomNumber(45, 100));

            if (!LeftClick(x, y))
            {
                return false;
            }

            //Thread.Sleep(Helper.Randoms.RandomNumber(50, 100));
            Thread.Sleep(Helper.Randoms.RandomNumber(45, 100));

            if (!Keyboard.KeyUp(Constants.VK_SHIFT))
            {
                return false;
            }

            Thread.Sleep(Helper.Randoms.RandomNumber(45, 100));

            return true;
        }

        // # Done
        private static bool LeftDown(int x, int y)
        {
            if (!Focus.ClientFocused)
            {
                if (!Focus.FocusClient())
                {
                    return false;
                }
            }

            return WinAPI.Native.PostMessage(
                Settings.pPrimaryGameWindow,
                WinAPI.Constants.WM_LBUTTONDOWN,
                1,
                WinAPI.Native.MakeLParam(x, y));
        }

        // # Done
        private static bool LeftUp(int x, int y)
        {
            if (!Focus.ClientFocused)
            {
                if (!Focus.FocusClient())
                {
                    return false;
                }
            }

            return WinAPI.Native.PostMessage(
                Settings.pPrimaryGameWindow,
                WinAPI.Constants.WM_LBUTTONUP,
                1,
                WinAPI.Native.MakeLParam(x, y));
        }

        internal static bool Move(int x, int y)
        {
            return true;
        }

        internal static bool RightClick(int x, int y)
        {
            if (!Focus.FocusClient())
            {
                return false;
            }

            if (!SetPosition(x, y))
            {
                return false;
            }

            Thread.Sleep(Helper.Randoms.RandomNumber(50, 100));

            if (!Focus.FocusClient())
            {
                return false;
            }

            if (!RightDown(x, y))
            {
                return false;
            }

            Thread.Sleep(Helper.Randoms.RandomNumber(50, 100));

            if (!Focus.FocusClient())
            {
                return false;
            }

            if (!RightUp(x, y))
            {
                return false;
            }

            return true;
        }

        internal static bool RightDown(int x, int y)
        {
            if (!Focus.ClientFocused)
            {
                if (!Focus.FocusClient())
                {
                    return false;
                }
            }

            return WinAPI.Native.PostMessage(
                Settings.pPrimaryGameWindow,
                WinAPI.Constants.WM_RBUTTONDOWN,
                1,
                WinAPI.Native.MakeLParam(x, y));
        }

        internal static bool RightUp(int x, int y)
        {
            if (!Focus.ClientFocused)
            {
                if (!Focus.FocusClient())
                {
                    return false;
                }
            }

            return WinAPI.Native.PostMessage(
                Settings.pPrimaryGameWindow,
                WinAPI.Constants.WM_RBUTTONUP,
                1,
                WinAPI.Native.MakeLParam(x, y));
        }

        internal static bool SetPosition(int x, int y)
        {
            if (!Focus.ClientFocused)
            {
                if (!Focus.FocusClient())
                {
                    return false;
                }
            }
            
            if (!WinAPI.Native.PostMessage(
               Settings.pPrimaryGameWindow,
               WinAPI.Constants.WM_MOUSEMOVE,
               0,
               WinAPI.Native.MakeLParam(x, y)))
            {
                return false;
            }

            // # SET X, Y WHEN IMPORTED OSRSSHAPE
            _CURRENT_POSITION = new object();

            return true;
        }

        internal static bool MiddleDown(int x, int y)
        {

            if (!Focus.ClientFocused)
            {
                if (!Focus.FocusClient())
                {
                    return false;
                }
            }

            if (!Native.PostMessage(
               Settings.pPrimaryGameWindow,
               Constants.WM_MOUSEMOVE,
               0,
               Native.MakeLParam(x, y)))
            {
                return false;
            }

            return true;
        }
    }
}
