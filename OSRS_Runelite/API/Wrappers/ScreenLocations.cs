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


        internal static readonly RSRectangle[] FIXED_INVENTORY_SLOTS =
        {
            new RSRectangle(563, 213, 35 ,31), //1
            new RSRectangle(605, 213, 35 ,31),
            new RSRectangle(647, 213, 35 ,31),
            new RSRectangle(689, 213, 35 ,31), //4

            new RSRectangle(563, 249, 35 ,31), //5
            new RSRectangle(605, 249, 35 ,31),
            new RSRectangle(647, 249, 35 ,31),
            new RSRectangle(689, 249, 35 ,31), //8

            new RSRectangle(563, 285, 35 ,31), //9
            new RSRectangle(605, 285, 35 ,31),
            new RSRectangle(647, 285, 35 ,31),
            new RSRectangle(689, 285, 35 ,31), //12

            new RSRectangle(563, 321, 35 ,31), //13
            new RSRectangle(605, 321, 35 ,31),
            new RSRectangle(647, 321, 35 ,31),
            new RSRectangle(689, 321, 35 ,31), //16

            new RSRectangle(563, 357, 35 ,31), //17
            new RSRectangle(605, 357, 35 ,31),
            new RSRectangle(647, 357, 35 ,31),
            new RSRectangle(689, 357, 35 ,31), //20

            new RSRectangle(563, 393, 35 ,31), //21
            new RSRectangle(605, 393, 35 ,31),
            new RSRectangle(647, 393, 35 ,31),
            new RSRectangle(689, 393, 35 ,31), //24

            new RSRectangle(563, 429, 35 ,31), //25
            new RSRectangle(605, 213, 35 ,31),
            new RSRectangle(647, 213, 35 ,31),
            new RSRectangle(689, 213, 35 ,31), //28

        };
    }
}
