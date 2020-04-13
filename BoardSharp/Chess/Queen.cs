using System;
using System.Collections.Generic;
using System.Text;
using BoardSharp.Common;

namespace BoardSharp.Chess
{
    /// <summary>
    /// Queen chess piece class.
    /// </summary>
    class Queen : ChessPiece
    {
        /// <summary>
        /// Queen constructor.
        /// </summary>
        /// <param name="name">Name of the queen (black_queen or white_queen).</param>
        /// <param name="position">The initial/current position of the queen.</param>
        public Queen(string name, Tile position) : base(name, position) {}

        /// <summary>
        /// Determines if the move for a queen piece is valid.
        /// </summary>
        /// <param name="fromTile">The inital tile of the queen piece.</param>
        /// <param name="toTile">The tile to move to.</param>
        /// <returns>A bool indicating whether the move is legal</returns>
        public override bool IsValidMove(Tile fromTile, Tile toTile)
        {
            bool @base = base.IsValidMove(fromTile, toTile);

            bool isValid = ((Func<bool>)(() =>
            {
                //Vertial and horizontal
                bool xDeltaLinear = fromTile._x - toTile._x == 0;
                bool yDeltaLinear = fromTile._y - toTile._y == 0;

                //Diagonal
                int xDeltaDiagonal = Math.Abs(fromTile._x - toTile._x);
                int yDeltaDiagonal = Math.Abs(fromTile._y - toTile._y);

                return xDeltaLinear ^ yDeltaLinear || xDeltaDiagonal == yDeltaDiagonal;

            }))();

            return @base && isValid;
        }
    }
}
