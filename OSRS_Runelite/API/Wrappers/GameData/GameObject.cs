using OSRS_Runelite.API.Wrappers.Interactive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static OSRS_Runelite.API.Wrappers.ScreenLocations;

namespace OSRS_Runelite.API.Wrappers.GameData
{
    public class GameObject
    {
        public int Id { get; set; }

        public required ClickBox ClickBox { get; set; }

        public required WorldPoint WorldPoint { get; set; }

        public bool IsOnScreen()
        {
            // Check if ScreenX is between 0 and the width of the screen
            bool xOnScreen = this.ClickBox.X >= GAME_SCREEN_FIXED.Left && this.ClickBox.X <= GAME_SCREEN_FIXED.Right;

            // Check if ScreenY is between 0 and the height of the screen
            bool yOnScreen = this.ClickBox.Y >= GAME_SCREEN_FIXED.Top && this.ClickBox.Y <= GAME_SCREEN_FIXED.Bottom;

            return xOnScreen && yOnScreen;
        }

        public bool LeftClickMiddle()
        {
            int randomX = (int)(this.ClickBox.X + (this.ClickBox.Width / 2));
            int randomY = (int)(this.ClickBox.Y + (this.ClickBox.Height / 2));

            return Input.Mouse.LeftClick(new RSPoint(randomX, randomY));
        }

    }
}
