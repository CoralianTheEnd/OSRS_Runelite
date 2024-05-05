using System.Text.Json.Serialization;

namespace OSRS_Runelite.API.Wrappers.GameData
{
    public class Character
    {
        [JsonPropertyName("combatLevel")]
        public int CombatLevel { get; set; }

        [JsonPropertyName("overHeadIcon")]
        public required string OverHeadIcon { get; set; }

        [JsonPropertyName("skullIcon")]
        public required string SkullIcon { get; set; }

        [JsonPropertyName("interactingName")]
        public required string InteractingName { get; set; }

        [JsonPropertyName("overheadText")]
        public required string OverheadText { get; set; }

        [JsonPropertyName("isDead")]
        public bool IsDead { get; set; }

        [JsonPropertyName("animationID")]
        public int AnimationID { get; set; } // Corrected

        [JsonPropertyName("poseAnimationID")]
        public int PoseAnimationID { get; set; } // Corrected

        [JsonPropertyName("runEnergy")]
        public int RunEnergy { get; set; }

        [JsonPropertyName("healthCurrent")]
        public int HealthCurrent { get; set; }

        [JsonPropertyName("healthMax")]
        public int HealthMax { get; set; }

        [JsonPropertyName("prayerCurrent")]
        public int PrayerCurrent { get; set; }

        [JsonPropertyName("prayerMax")]
        public int PrayerMax { get; set; }

        [JsonPropertyName("worldPoint")]
        public required WorldPoint WorldPoint { get; set; }
    }
}
