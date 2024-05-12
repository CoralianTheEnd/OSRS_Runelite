using OSRS_Runelite.API.Wrappers.Interactive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using static OSRS_Runelite.API.Wrappers.ScreenLocations;

namespace OSRS_Runelite.API.Wrappers.GameData
{
    internal class Npc
    {
        #region Json Data Imported From Server

        public string Name { get; set; }

        public int Id { get; set; }

        public int CombatLevel { get; set; }

        public int AnimationId { get; set; }

        public bool IsDead { get; set; }

        public bool IsInteracting { get; set; }

        public string IsInteractingName { get; set; }

        public ClickBox ClickBox { get; set; }

        public WorldPoint WorldPoint { get; set; }

        #endregion

        #region Extended

        [JsonIgnore]
        public bool IsOnScreen
        {
            get
            {
                return this.ClickBox.IsOnScreen();
            }
        }

        #endregion

        #region Easy Access Functions

        public bool LeftClick()
        {
            return this.ClickBox.LeftClickMiddle();
        }

        #endregion
    }
}
