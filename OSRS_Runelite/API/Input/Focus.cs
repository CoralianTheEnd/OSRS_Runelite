using OSRS_Runelite.WinAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRS_Runelite.API.Input
{
    internal class Focus
    {
        internal static bool ClientFocused
        {
            get
            {
                return Native.IsWindowEnabled(Settings.pPrimaryGameWindow);
            }
        }

        internal static bool FocusClient()
        {
            return Native.PostMessage(
                               Settings.pPrimaryGameWindow,
                               Constants.WM_ACTIVATE,
                               Constants.WA_ACTIVE,
                               0);
        }
    }
}
