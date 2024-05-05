using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRS_Runelite.API.Helper
{
    public class Randoms
    {
        private static Random rnd = new Random();

        public static int RandomNumber(int low, int high)
        {
            return rnd.Next(low, high);
        }
    }
}
