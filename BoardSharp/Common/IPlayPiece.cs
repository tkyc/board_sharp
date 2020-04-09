using System;
using System.Collections.Generic;
using System.Text;

namespace BoardSharp.Common
{
    /// <summary>
    /// Interface for a play piece.
    /// </summary>
    public interface IPlayPiece
    {
        /// <summary>
        /// Moves play piece to designated board coordinates.
        /// </summary>
        /// <param name="tile">The board tile to move the play piece to.</param>
        /// <returns>A bool indicating whether the move was successful.</returns>
        public bool moveTo(Tile tile);

        /// <summary>
        /// Determines if the move for a play piece is valid.
        /// </summary>
        /// <param name="fromTile">The inital tile of the play piece.</param>
        /// <param name="toTile">The tile to move to.</param>
        /// <returns>A bool indicating whether the move is legal</returns>
        public bool isValidMove(Tile fromTile, Tile toTile);
    }
}
