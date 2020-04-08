using System;
using System.Collections.Generic;
using System.Text;

namespace BoardSharp.Common
{
    /// <summary>
    /// Interface for a play piece.
    /// </summary>
    interface IPlayPiece
    {
        /// <summary>
        /// Moves play piece to designated board coordinates.
        /// </summary>
        /// <param name="tile">The board tile to move the play piece to.</param>
        /// <returns>A bool indicating whether the move was successful.</returns>
        bool move(Tile tile);
    }
}
