using System;
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
        /// <param name="name">Name of the rook (black_rook or white_rook).</param>
        /// <param name="position">The initial/current position of the rook.</param>
        public Rook(string name, Tile position, Side side) : base(name, position, side) {}

        /// <summary>
        /// Determines if the move for a rook piece is valid.
        /// </summary>
        /// <param name="fromTile">The inital tile of the pawn piece.</param>
        /// <param name="toTile">The tile to move to.</param>
        /// <returns>A bool indicating whether the move is legal</returns>
        public override bool IsValidMove(Tile fromTile, Tile toTile)
        {
            bool @base = base.IsValidMove(fromTile, toTile);

            bool isValid = ((Func<bool>)(() =>
            {
                bool xDelta = fromTile._x - toTile._x == 0;
                bool yDelta = fromTile._y - toTile._y == 0;
                //TODO -- Determine obstruction in path
                return xDelta ^ yDelta;

            }))();

            return @base && isValid;
        }
    }
}
