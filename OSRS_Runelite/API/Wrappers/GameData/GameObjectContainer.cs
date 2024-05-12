using System;
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
        public GameObject[] GameObjects => 
            Web.RequestData.ConvertJsonClientData<Dictionary<string, GameObject>>("/GameObjects").Values.ToArray();

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

        public GameObject? FindClosestGameObjectById(int id)
        {
            if (GameObjects == null || GameObjects.Length == 0)
            {
                Logger.Error("The GameObject list must not be empty.");
                return null;
            }

            DynamicLocalPlayer player = new DynamicLocalPlayer();

            if (player == null)
            {
                Logger.Error("The player must not be empty.");
                return null;
            }

            return GameObjects
                .Where(go => go.Id == id && go.IsOnScreen()) // Filter by ID and valid WorldPoint
                .OrderBy(go => CalculateDistance(go.WorldPoint, player.WorldPoint))
                .FirstOrDefault(); // Return the closest matching GameObject
        }

        public GameObject? FindClosestGameObjectByIds(params int[] ids)
        {
            if (GameObjects == null || GameObjects.Length == 0)
            {
                Logger.Error("The GameObject list must not be empty.");
                return null;
            }

            DynamicLocalPlayer player = new DynamicLocalPlayer();

            if (player == null)
            {
                Logger.Error("The player must not be empty.");
                return null;
            }

            return GameObjects
                .Where(go => ids.Contains(go.Id) && go.IsOnScreen()) // Filter by IDs array and valid WorldPoint
                .OrderBy(go => CalculateDistance(go.WorldPoint, player.WorldPoint))
                .FirstOrDefault(); // Return the closest matching GameObject
        }

        // Function to calculate the Euclidean distance between two WorldPoints
        private static double CalculateDistance(WorldPoint a, WorldPoint b)
        {
            //var i = Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));

            //Console.WriteLine($"Player Point: {b.X}:{b.Y} Object Point: {a.X}:{a.Y}");
            //Console.WriteLine($"DISTANCE FROM PLAYER: {i}");

            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2)); ;
        }
    }
}
