using OSRS_Runelite.API.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OSRS_Runelite.API.Wrappers.GameData
{
    internal class CameraContainer
    {
        private Camera _CAMERA;

        public Camera Camera {

            get {

                LoadData();
                return _CAMERA;

            } 

        }

        private void LoadData()
        {
            var rawJson = 
                Web.RequestData.RequestClientData(Web.DataTypes.RSData.CAMERA);

            if (rawJson == null)
            {
                Logger.Error("Failed to get player data from the server. Shutdown.");
                return;
            }

            // Deserialize into a dictionary
            var gameObjectsDict = JsonSerializer.Deserialize<Camera>(rawJson);
            if (gameObjectsDict == null)
            {
                Logger.Error("Failed to parse retreived player data.");
                return;
            }

            _CAMERA = gameObjectsDict;
        }
    }
}
