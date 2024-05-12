using OSRS_Runelite.API.Wrappers.Interactive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static OSRS_Runelite.API.Wrappers.ScreenLocations;

namespace OSRS_Runelite.API.Wrappers.GameData
{
    public class ClickBox
    {

        public double X { get; set; }

        public double Y { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public bool IsOnScreen()
        {
            // Check if ScreenX is between 0 and the width of the screen
            bool xOnScreen = this.X >= GAME_SCREEN_FIXED.Left && this.X <= GAME_SCREEN_FIXED.Right;

            // Check if ScreenY is between 0 and the height of the screen
            bool yOnScreen = this.Y >= GAME_SCREEN_FIXED.Top && this.Y <= GAME_SCREEN_FIXED.Bottom;

            return xOnScreen && yOnScreen;
        }

        public bool LeftClickMiddle()
        {
            int randomX = (int)(this.X + (this.Width / 2));
            int randomY = (int)(this.Y + (this.Height / 2));

            return Input.Mouse.LeftClick(new RSPoint(randomX, randomY));
        }

        public override string ToString()
        {
            return $"X: {this.X} Y: {this.Y} Width: {this.Width} Height: {this.Height}";
        }
    }
}
