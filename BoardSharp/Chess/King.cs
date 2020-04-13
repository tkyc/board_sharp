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
        public King(string name, Tile position, Side side) : base(name, position, side) {}

        /// <summary>
        /// Determines if the move for a king piece is valid.
        /// </summary>
        /// <param name="fromTile">The inital tile of the king piece.</param>
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

                //One unit of movement
                bool xDelta = Math.Abs(fromTile._x - toTile._x) == 1;
                bool yDelta = Math.Abs(fromTile._y - toTile._y) == 1;

                //Legal movement is one unit of a diagonal, vertical or horizontal movement
                return (xDeltaLinear ^ yDeltaLinear || xDeltaDiagonal == yDeltaDiagonal) && (xDelta || yDelta);

            }))();

            return @base && isValid;
        }
    }
}
