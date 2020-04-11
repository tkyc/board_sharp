using BoardSharp.Common;

namespace BoardSharp.Chess
{
    /// <summary>
    /// Pawn chess piece class.
    /// </summary>
    public class Pawn : ChessPiece
    {
        /// <summary>
        /// Pawn constructor.
        /// </summary>
        /// <param name="name">Name of the pawn (black_pawn or white_pawn).</param>
        /// <param name="position">The initial/current position of the pawn.</param>
        public Pawn(string name, Tile position) : base(name, position) {}

        /// <summary>
        /// Determines if the move for a pawn piece is valid.
        /// </summary>
        /// <param name="fromTile">The inital tile of the pawn piece.</param>
        /// <param name="toTile">The tile to move to.</param>
        /// <returns>A bool indicating whether the move is legal</returns>
        public override bool IsValidMove(Tile fromTile, Tile toTile)
        {
            return base.IsValidMove(fromTile, toTile);
        }
    }
}
