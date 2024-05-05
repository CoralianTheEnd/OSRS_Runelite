﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using OSRS_Runelite.API.Helper;
using System.Linq;

namespace OSRS_Runelite.API.Wrappers.GameData
{
    public class GameObjectContainer
    {
        private GameObject[] _gameObjects;
        public GameObject[] GameObjects
        {
            get
            {
                LoadData();
                return _gameObjects;
            }
        }

        [JsonIgnore]
        public int TotalGameObjects => GameObjects?.Length ?? 0;

        public GameObject? GetFirstOnScreen(int id)
        {
            return GameObjects?.FirstOrDefault(g => g.Id == id && g.IsOnScreen());
        }
     
        public GameObject? GetFirstOnScreen(params int[] ids)
        {
            return GameObjects?.FirstOrDefault(g => ids.Contains(g.Id) && g.IsOnScreen());
        }

        //public GameObject? FindClosestGameObjectById(int id)
        //{
        //    if (GameObjects == null || GameObjects.Length == 0)
        //    {
        //        Logger.Error("The GameObject list must not be empty.");
        //        return null;
        //    }

        //    CharacterContainer player = new CharacterContainer();

        //    if (player == null)
        //    {
        //        Logger.Error("The player must not be empty.");
        //        return null;
        //    }

        //    return GameObjects
        //        .Where(go => go.Id == id && go.IsOnScreen()) // Filter by ID and valid WorldPoint
        //        .OrderBy(go => CalculateDistance(go.WorldPoint, player.LocalPlayer.WorldPoint))
        //        .FirstOrDefault(); // Return the closest matching GameObject
        //}

        // Function to calculate the Euclidean distance between two WorldPoints
        private static double CalculateDistance(WorldPoint a, WorldPoint b)
        {
            //var i = Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));

            //Console.WriteLine($"Player Point: {b.X}:{b.Y} Object Point: {a.X}:{a.Y}");
            //Console.WriteLine($"DISTANCE FROM PLAYER: {i}");

            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2)); ;
        }

        private void LoadData()
        {

            _gameObjects = 
                Web.RequestData.ConvertJsonClientData<Dictionary<string, GameObject>>("/GameObjects").Values.ToArray();
           
            ////string rawJson = Web.RequestData.RequestClientData(Web.DataTypes.RSData.TEST_OBJECT2);

            //var options = new JsonSerializerOptions
            //{
            //    PropertyNameCaseInsensitive = true
            //};

            //// Deserialize into a dictionary
            //var gameObjectsDict = 
            //    JsonSerializer.Deserialize<Dictionary<string, GameObject>>(rawJson, options);

            //_gameObjects = gameObjectsDict.Values.ToArray();
        }
    }
}
