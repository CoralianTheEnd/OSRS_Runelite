using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OSRS_Runelite.API.Wrappers.GameData
{
    internal class Camera
    {
        [JsonPropertyName("yaw")]
        public int Yaw { get; set; }

        [JsonPropertyName("pitch")]
        public int Pitch { get; set; }

        [JsonPropertyName("zoom")]
        public int Zoom { get; set; }

        [JsonPropertyName("x")]
        public int X { get; set; }

        [JsonPropertyName("y")]
        public int Y { get; set; }

        [JsonPropertyName("z")]
        public int Z { get; set; }

        [JsonPropertyName("x2")]
        public int X2 { get; set; }

        [JsonPropertyName("y2")]
        public int Y2 { get; set; }

        [JsonPropertyName("z2")]
        public int Z2 { get; set; }

    }
}
