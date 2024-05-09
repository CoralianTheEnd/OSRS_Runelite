using OSRS_Runelite.API.Wrappers.GameData;
using OSRS_Runelite.WinAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSRS_Runelite.API.Input
{
    internal class Keyboard
    {
        internal static bool Type(string message, bool pressEnter)
        {
            foreach (var item in message)
            {
                if (!KeyPress((Keys)item))
                {
                    return false;
                }
            }

            return true;
        }

        internal static bool KeyPress(Keys key)
        {
            return KeyPress(key, Helper.Randoms.RandomNumber(15, 80));
        }

        internal static bool KeyPress(Keys key, int waitInMs) 
        {
            if (!KeyDown(key))
            {
                return false;
            }

            Thread.Sleep(waitInMs);

            return KeyUp(key);
        }

        internal static bool KeyDown(Keys key)
        {
            //if (!Focus.ClientFocused)
            //{

            //}

            if (!Focus.FocusClient())
            {
                return false;
            }

            return Native.PostMessage(
                                    Settings.pPrimaryGameWindow,
                                    Constants.WM_KEYDOWN,
                                    (IntPtr)key,
                                    Native.MakeKeyDownLParam(0, (uint)key, false, false));
        }

        internal static bool KeyUp(Keys key)
        {
            //if (!Focus.ClientFocused)
            //{

            //}

            if (!Focus.FocusClient())
            {
                return false;
            }

            return Native.PostMessage(
                                    Settings.pPrimaryGameWindow,
                                    Constants.WM_KEYUP,
                                    (IntPtr)key,
                                    Native.MakeKeyUpLParam((uint)key, false));

        }

        internal static bool KeyPress(short keys)
        {

            if (!KeyDown(keys))
            {
                return false;
            }

            Thread.Sleep(10);

            if (!KeyUp(keys))
            {
                return false;
            }

            return true;
        }

        internal static bool KeyUp(short vk_Keycode)
        {
            //if (!Focus.ClientFocused)
            //{

            //}

            if (!Focus.FocusClient())
            {
                return false;
            }

            return Native.PostMessage(
                Settings.pPrimaryGameWindow,
                Constants.WM_KEYUP,
                (IntPtr)vk_Keycode,
                Native.MakeKeyUpLParam((uint)vk_Keycode, false)); ;

        }

        internal static bool KeyDown(short vk_Keycode)
        {
            //if (!Focus.ClientFocused)
            //{
            //    if (!Focus.FocusClient())
            //    {
            //        return false;
            //    }
            //}

            if (!Focus.FocusClient())
            {
                return false;
            }

            return Native.PostMessage(
                Settings.pPrimaryGameWindow,
                Constants.WM_KEYDOWN,
                (IntPtr)vk_Keycode,
                Native.MakeKeyDownLParam(0, (uint)vk_Keycode, false, false));
        }


        // # Right = Yaw Up
        // # Left = Yaw Down

        // Up = Pitch up
        // Down = pitch down
        internal static bool keyboardRotateToYaw(int yaw)
        {

            DynamicCamera camera = new DynamicCamera();

            while (!IsWithinRange(yaw, camera.Yaw, 50))
            {

                Console.WriteLine($"Random till we hit: {IsWithinRange(yaw, camera.Yaw, 50)}");
                if (!KeyDown(Keys.Right))
                {
                    Console.Write("Failed to press key down");
                    return false;
                }

                Thread.Sleep(100);

                if (!KeyUp(Keys.Right))
                {
                    Console.Write("Failed to press key down");
                    return false;
                }

                //Thread.Sleep(500);

            }

            return true;

        }

        private static bool IsWithinRange(int a, int b, int range)
        {
            // Calculate the absolute difference
            int difference = Math.Abs(a - b);

            Console.WriteLine($"Difference: {difference}");
            // Check if the difference is within the specified range
            return difference <= range;
        }
    }
}
