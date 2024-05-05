using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OSRS_Runelite.API.Wrappers.GameData
{
    public class WorldPoint
    {
        [JsonPropertyName("x")]
        public double X { get; set; }

        [JsonPropertyName("y")]
        public double Y { get; set; }

        [JsonPropertyName("plane")]
        public double Plane { get; set; }

        [JsonPropertyName("regionID")]
        public double RegionID { get; set; }

        [JsonPropertyName("regionX")]
        public double RegionX { get; set; }

        [JsonPropertyName("regionY")]
        public double RegionY { get; set; }
    }
}
