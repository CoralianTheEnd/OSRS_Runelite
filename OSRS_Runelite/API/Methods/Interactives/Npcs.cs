using OSRS_Runelite.API.Wrappers.GameData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRS_Runelite.API.Methods.Interactives
{
    internal class Npcs
    {
        public static List<Npc> GetAll()
        {
            return Web.RequestData.ConvertJsonClientData<Dictionary<string, Npc>>("/Npcs").Values.ToList();
        }

        //public static List<Npc> GetAll(params int[] Id)
        //{
        //    return default;
        //}

        //public static List<Npc> GetAll(params string[] name)
        //{
        //    return default;
        //}

        public static Npc GetClosest(params string[] name)
        {
            DynamicLocalPlayer player = new DynamicLocalPlayer();

            return GetAll()
                .Where(go => name.Contains(go.Name) && go.IsOnScreen)
                .OrderBy(go => Helper.CMath.CalculateDistance(go.WorldPoint, player.WorldPoint))
                .FirstOrDefault();
        }
    }
}
