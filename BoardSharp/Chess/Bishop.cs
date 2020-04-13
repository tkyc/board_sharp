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
        /// <param name="name">Name of the bishop (black_bishop or white_bishop).</param> 
        /// <param name="position">The initial/current position of the bishop.</param>
        public Bishop(string name, Tile position) : base(name, position) {}

        /// <summary>
        /// Determines if the move for a bishop piece is valid.
        /// </summary>
        /// <param name="fromTile">The inital tile of the bishop piece.</param>
        /// <param name="toTile">The tile to move to.</param>
        /// <returns>A bool indicating whether the move is legal</returns>
        public override bool IsValidMove(Tile fromTile, Tile toTile)
        {
            bool @base = base.IsValidMove(fromTile, toTile);

            bool isValid = ((Func<bool>)(() =>
            {
                int xDelta = Math.Abs(fromTile._x - toTile._x);
                int yDelta = Math.Abs(fromTile._y - toTile._y);

                return xDelta == yDelta;

            }))();

            return @base && isValid;
        }
    }
}
