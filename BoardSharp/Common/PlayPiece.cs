using System;
using System.Collections.Generic;
using System.Text;

namespace BoardSharp.Common
{
    /// <summary>
    /// Generic board game piece class.
    /// </summary>
    public abstract class PlayPiece
    {
        /// <summary>
        /// Name of the play piece.
        /// </summary>
        public string _name { get; }

        /// <summary>
        /// The tile the play piece is currently located at.
        /// </summary>
        public Tile _tile { get; protected set; }

        /// <summary>
        /// Play piece
        /// </summary>
        /// <param name="name">Name of the play piece.</param>
        /// <param name="tile">The initial/current position of the play piece.</param>
        public PlayPiece(string name, Tile tile)
        {
            _name = name;
            _tile = tile;
        }
    }
}
