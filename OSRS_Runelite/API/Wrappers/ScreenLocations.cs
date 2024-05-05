using OSRS_Runelite.API.Wrappers.Interactive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRS_Runelite.API.Wrappers
{
    internal class ScreenLocations
    {
        internal static readonly RSPoint CENTER_GAME_SCREEN = new RSPoint(259, 170);

        internal static readonly Rectangle GAME_SCREEN_FIXED = new Rectangle(0, 0, 517, 339);
        internal static readonly Rectangle INVENTORY_FIXED = new Rectangle(550, 205, 185, 260);

    }
}
