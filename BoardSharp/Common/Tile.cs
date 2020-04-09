using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace BoardSharp.Common
{
    /// <summary>
    /// Tile class. A tile on the game board.
    /// </summary>
    public sealed class Tile : Button
    {
        /// <summary>
        /// Tile x-coordinate.
        /// </summary>
        public int _x { get; }

        /// <summary>
        /// Tile y-coordinate.
        /// </summary>
        public int _y { get; }

        /// <summary>
        /// The current play piece on this tile.
        /// </summary>
        public PlayPiece _playPiece { get; set; }

        /// <summary>
        /// The tile's width in pixels.
        /// </summary>
        public const int WIDTH = 80;

        /// <summary>
        /// The tiles's heigh in pixels.
        /// </summary>
        public const int HEIGHT = 80;

        /// <summary>
        /// Tile constructor.
        /// </summary>
        /// <param name="x">The tile's x-coordinate.</param>
        /// <param name="y">The tile's y-coordinate.</param>
        public Tile(int x, int y)
        {
            this._x = x;
            this._y = y;
            this._playPiece = null;
            this.Width = WIDTH;
            this.Height = HEIGHT;
        }
    }
}
