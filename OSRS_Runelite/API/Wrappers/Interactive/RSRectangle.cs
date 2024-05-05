using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRS_Runelite.API.Wrappers.Interactive
{
    internal class RSRectangle
    {
        private int _X;
        private int _Y;
        private int _WIDTH;
        private int _HEIGHT;

        public RSRectangle(int x, int y, int width, int height)
        {
            _X = x;
            _Y = y;
            _WIDTH = width;
            _HEIGHT = height;
        }

        public RSRectangle(RSPoint location, Size size)
        {
            _X = location.X;
            _Y = location.Y;
            _WIDTH = size.Width;
            _HEIGHT = size.Height;
        }

        public int X
        {
            get => _X;
        }

        public int Y
        {
            get => _Y;
        }

        public int Width
        {
            get => _WIDTH;
        }

        public int Height
        {
            get => _HEIGHT;
        }

        public RSPoint Location
        {
            get => new(_X, _Y);
        }

        public Size Size
        {
            get => new(_WIDTH, _HEIGHT);
        }

        public bool ShiftLeftClick()
        {
            return Input.Mouse.LeftClickShift(this.Location.X + 5, this.Location.Y + 5);
        }
    }
}
