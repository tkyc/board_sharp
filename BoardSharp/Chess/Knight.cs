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
        public Knight(string name, Tile position, Side side) : base(name, position, side) {}

        /// <summary>
        /// Determines if the move for a knight piece is valid.
        /// </summary>
        /// <param name="fromTile">The inital tile of the knight piece.</param>
        /// <param name="toTile">The tile to move to.</param>
        /// <returns>A bool indicating whether the move is legal</returns>
        public override bool IsValidMove(Tile fromTile, Tile toTile)
        {
            bool @base = base.IsValidMove(fromTile, toTile);

            bool isValid = ((Func<bool>)(() =>
            {
                int xDelta = Math.Abs(fromTile._x - toTile._x);
                int yDelta = Math.Abs(fromTile._y - toTile._y);

                return xDelta == 1 && yDelta == 2 || xDelta == 2 && yDelta == 1;

            }))();

            return @base && isValid;
        }
    }
}
