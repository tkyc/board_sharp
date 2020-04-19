using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace BoardSharp.Common
{
    /// <summary>
    /// Tile class. A tile on the game board.
    /// </summary>
    public class Tile : Button
    {
        /// <summary>
        /// The tile's width in pixels.
        /// </summary>
        public const int WIDTH = 80;

        /// <summary>
        /// The tiles's heigh in pixels.
        /// </summary>
        public const int HEIGHT = 80;

        /// <summary>
        /// The current play piece on this tile.
        /// </summary>
        private PlayPiece _playPiece;

        /// <summary>
        /// Tile x-coordinate.
        /// </summary>
        public int _x { get; }

        /// <summary>
        /// Tile y-coordinate.
        /// </summary>
        public int _y { get; }

        public static object selected { get; set; }

        /// <summary>
        /// Tile constructor.
        /// </summary>
        /// <param name="x">The tile's x-coordinate.</param>
        /// <param name="y">The tile's y-coordinate.</param>
        public Tile(int x, int y)
        {
            _x = x;
            _y = y;
            _playPiece = null;
            Width = WIDTH;
            Height = HEIGHT;
        }

        /// <summary>
        /// Removes the play piece from this tile.
        /// </summary>
        public void RemovePlayPiece()
        {
            PlayPiece = null;
        }

        /// <summary>
        /// Sets and gets the play piece for the tile.
        /// </summary>
        public PlayPiece PlayPiece
        {
            get { return _playPiece; }
            set { _playPiece = value; Content = value == null ? null : value._playPieceImage; }
        }
    }
}
