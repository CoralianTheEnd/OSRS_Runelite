using OSRS_Runelite.API.Wrappers.Interactive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRS_Runelite.API.Wrappers.GameData
{
    public class LocalScreenPoint
    {
        public double X;
        public double Y;

        public bool LeftClickMiddle()
        {
            return Input.Mouse.LeftClick((int)X, (int)Y);
        }

    }
}
