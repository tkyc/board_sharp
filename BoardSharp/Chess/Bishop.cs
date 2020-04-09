using System;
using System.Collections.Generic;
using System.Text;
using BoardSharp.Common;

namespace BoardSharp.Chess
{
    /// <summary>
    /// Bishop chess piece class.
    /// </summary>
    class Bishop : ChessPiece
    {
        /// <summary>
        /// Bishop constructor.
        /// </summary>
        /// <param name="position">The initial/current position of the bishop.</param>
        public Bishop(Tile position) : base("Bishop", position, ChessPieceEnum.Bishop) {}

        /// <summary>
        /// Determines if the move for a bishop piece is valid.
        /// </summary>
        /// <param name="fromTile">The inital tile of the bishop piece.</param>
        /// <param name="toTile">The tile to move to.</param>
        /// <returns>A bool indicating whether the move is legal</returns>
        public override bool isValidMove(Tile fromTile, Tile toTile)
        {
            throw new NotImplementedException();
        }
    }
}
