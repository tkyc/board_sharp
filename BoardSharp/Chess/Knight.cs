using System;
using System.Collections.Generic;
using System.Text;
using BoardSharp.Common;

namespace BoardSharp.Chess
{
    /// <summary>
    /// knight chess piece class.
    /// </summary>
    class Knight : ChessPiece
    {
        /// <summary>
        /// Knight constructor.
        /// </summary>
        /// <param name="name">Name of the knight (black_knight or white_knight).</param>
        /// <param name="position">The initial/current position of the knight.</param>
        public Knight(string name, Tile position) : base(name, position, ChessPieceEnum.Knight) {}

        /// <summary>
        /// Determines if the move for a knight piece is valid.
        /// </summary>
        /// <param name="fromTile">The inital tile of the knight piece.</param>
        /// <param name="toTile">The tile to move to.</param>
        /// <returns>A bool indicating whether the move is legal</returns>
        public override bool isValidMove(Tile fromTile, Tile toTile)
        {
            throw new NotImplementedException();
        }
    }
}
