using OSRS_Runelite.WinAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRS_Runelite.API.Wrappers.Interactive
{
    public class RSPoint
    {

        public int X
        {
            get
            {
                Structures.RECT rect;

                unsafe
                {
                    if (Native.GetWindowRect(Settings.pPrimaryGameWindow, &rect))
                    {
                        return True_X + rect.left;
                    }
                }

                // 
                return -1;
            }
        }

        public int Y
        {
            get
            {
                Structures.RECT rect;

                unsafe
                {
                    if (Native.GetWindowRect(Settings.pPrimaryGameWindow, &rect))
                    {
                        return True_Y + rect.top;
                    }
                }

                // 
                return -1;
            }
        }

        public static RSPoint Empty;

        public int True_X;
        public int True_Y;

        public RSPoint(int x, int y)
        {
            True_X = x;
            True_Y = y;
        }
    }
}
