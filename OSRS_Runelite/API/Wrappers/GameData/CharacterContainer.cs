using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using OSRS_Runelite.API.Helper;

namespace OSRS_Runelite.API.Wrappers.GameData
{

    public class CharacterContainer
    {
        [JsonIgnore]
        private Character _CHARACTER;

        public Character LocalPlayer 
        {
            get
            {
                GetPlayerData();
                return _CHARACTER;
            }
        }

        private void GetPlayerData()
        {
            var rawJson = Web.RequestData.RequestClientData(Web.DataTypes.RSData.PLAYER);

            if (rawJson == null)
            {
                Logger.Error("Failed to get player data from the server. Shutdown.");
                return;
            }

            // Deserialize into a dictionary
            var gameObjectsDict = JsonSerializer.Deserialize<Character>(rawJson);
            if (gameObjectsDict == null)
            {
                Logger.Error("Failed to parse retreived player data.");
                return;
            }

            _CHARACTER = gameObjectsDict;
        }
    }
}
