using System;
using System.Collections.Generic;
using System.Text;
using BoardSharp.Common;

namespace BoardSharp.Chess
{
    /// <summary>
    /// Rook chess piece class.
    /// </summary>
    class Rook : ChessPiece
    {
        /// <summary>
        /// Rook constructor.
        /// </summary>
        /// <param name="position">The initial/current position of the rook.</param>
        public Rook(Tile position) : base("Rook", position, ChessPieceEnum.Rook) {}

        /// <summary>
        /// Determines if the move for a rook piece is valid.
        /// </summary>
        /// <param name="fromTile">The inital tile of the pawn piece.</param>
        /// <param name="toTile">The tile to move to.</param>
        /// <returns>A bool indicating whether the move is legal</returns>
        public override bool isValidMove(Tile fromTile, Tile toTile)
        {
            throw new NotImplementedException();
        }
    }
}
