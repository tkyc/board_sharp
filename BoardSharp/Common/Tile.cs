using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace BoardSharp.Common
{
    class Tile : Button
    {
        private int _x { get; }
        private int _y { get; }
        public const int WIDTH = 80;
        public const int HEIGHT = 80;

        public Tile(int x, int y)
        {
            this._x = x;
            this._y = y;
            this.Width = WIDTH;
            this.Height = HEIGHT;
        }
    }
}
