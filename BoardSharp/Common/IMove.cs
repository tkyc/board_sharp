namespace BoardSharp.Common
{
    /// <summary>
    /// Interface for moving a play piece.
    /// Derived play piece classes may or may not implement.
    /// </summary>
    public interface IMove
    {
        /// <summary>
        /// Moves play piece to designated board coordinates.
        /// </summary>
        /// <param name="tile">The board tile to move the play piece to.</param>
        /// <returns>A bool indicating whether the move was successful.</returns>
        public bool MoveTo(Tile tile);

        /// <summary>
        /// Determines if the move for a play piece is valid. If implemented should be called from MoveTo.
        /// </summary>
        /// <param name="fromTile">The inital tile of the play piece.</param>
        /// <param name="toTile">The tile to move to.</param>
        /// <returns>A bool indicating whether the move is legal</returns>
        public bool IsValidMove(Tile fromTile, Tile toTile);
    }
}
