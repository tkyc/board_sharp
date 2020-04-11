using System;
using System.Collections.Generic;
using System.Text;
using BoardSharp.Common;

namespace BoardSharp.Chess
{
    /// <summary>
    /// King chess piece class.
    /// </summary>
    class King : ChessPiece
    {
        /// <summary>
        /// King constructor.
        /// </summary>
        /// <param name="name">Name of the king (black_king or white_king).</param>
        /// <param name="position">The initial/current position of the king.</param>
        public King(string name, Tile position) : base(name, position) {}

        /// <summary>
        /// Determines if the move for a king piece is valid.
        /// </summary>
        /// <param name="fromTile">The inital tile of the king piece.</param>
        /// <param name="toTile">The tile to move to.</param>
        /// <returns>A bool indicating whether the move is legal</returns>
        public override bool IsValidMove(Tile fromTile, Tile toTile)
        {
            throw new NotImplementedException();
        }
    }
}
