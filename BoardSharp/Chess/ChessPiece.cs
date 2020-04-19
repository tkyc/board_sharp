using BoardSharp.Common;

namespace BoardSharp.Chess
{
    /// <summary>
    /// Generic chess play piece class.
    /// </summary>
    public abstract class ChessPiece : PlayPiece, IMove
    {
        /// <summary>
        /// The side of the chess piece.
        /// </summary>
        protected Side _side;

        /// <summary>
        /// .png file names of white chess pieces
        /// </summary>
        public const string WHITE_PAWN = "white_pawn";
        public const string WHITE_ROOK = "white_rook";
        public const string WHITE_KNIGHT = "white_knight";
        public const string WHITE_BISHOP = "white_bishop";
        public const string WHITE_QUEEN = "white_queen";
        public const string WHITE_KING = "white_king";

        /// <summary>
        /// .png file names of black chess pieces
        /// </summary>
        public const string BLACK_PAWN = "black_pawn";
        public const string BLACK_ROOK = "black_rook";
        public const string BLACK_KNIGHT = "black_knight";
        public const string BLACK_BISHOP = "black_bishop";
        public const string BLACK_QUEEN = "black_queen";
        public const string BLACK_KING = "black_king";

        /// <summary>
        /// Chess piece constructor.
        /// </summary>
        /// <param name="name">Name of the chess piece. Corresponds to the chess piece image graphic.</param>
        /// <param name="tile">The initial/current position of the play piece.</param>
        public ChessPiece(string name, Tile tile, Side side) : base(name, tile) 
        {
            _side = side;
        }

        /// <summary>
        /// Moves play piece to designated board coordinates.
        /// </summary>
        /// <param name="tile">The board tile to move the play piece to.</param>
        /// <returns>A bool indicating whether the move was successful.</returns>
        public bool MoveTo(Tile tile)
        {
            if (IsValidMove(_tile, tile))
            {
                _tile.RemovePlayPiece();
                tile.PlayPiece = this;
                _tile = tile;

                return true;
            }

            return false;
        }

        /// <summary>
        /// Determines if the move for a chess piece is valid.
        /// </summary>
        /// <param name="fromTile">The inital tile of the play piece.</param>
        /// <param name="toTile">The tile to move to.</param>
        /// <returns>A bool indicating whether the move is legal</returns>
        public virtual bool IsValidMove(Tile fromTile, Tile toTile)
        {
            //From tile must have a chess piece selected and to tile must be free or contains opposing player's chess piece
            return fromTile.PlayPiece != null && toTile.PlayPiece == null 
                || fromTile.PlayPiece != null && ((ChessPiece)fromTile.PlayPiece)._side != ((ChessPiece)toTile.PlayPiece)._side;
        }
    }
}
