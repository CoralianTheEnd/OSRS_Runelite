﻿using OSRS_Runelite.API.Wrappers.GameData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRS_Runelite.API.Methods.Interactives
{
    internal class GameObjects
    {
        public static List<GameObject> GetAll()
        {
            return Web.RequestData.ConvertJsonClientData<Dictionary<string, GameObject>>("/GameObjects").Values.ToList();
        }

        public static List<GameObject> GetAll(params int[] Id) 
        {
            return default;
        }

        public static List<GameObject> GetAll(params string[] name)
        {
            return default;
        }
    }
}
