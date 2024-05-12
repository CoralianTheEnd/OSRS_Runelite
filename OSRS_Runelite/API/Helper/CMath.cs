using OSRS_Runelite.API.Wrappers.GameData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRS_Runelite.API.Helper
{
    internal class CMath
    {
        internal static double CalculateDistance(WorldPoint a, WorldPoint b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2)); ;
        }
    }
}
