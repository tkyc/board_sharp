using System;
using System.Collections.Generic;
using System.Text;
using BoardSharp.Common;

namespace BoardSharp.Chess
{
    /// <summary>
    /// Generic chess play piece class.
    /// </summary>
    public abstract class ChessPiece : PlayPiece, IPlayPiece
    {
        /// <summary>
        /// Chess piece type.
        /// </summary>
        public ChessPieceEnum _type { get; }

        /// <summary>
        /// Chess piece constructor.
        /// </summary>
        /// <param name="name">Name of the chess piece.</param>
        /// <param name="tile">The initial/current position of the play piece.</param>
        /// <param name="type">Type of chess piece.</param>
        public ChessPiece(string name, Tile tile, ChessPieceEnum type) : base(name, tile)
        {
            _type = type;
        }

        /// <summary>
        /// Moves play piece to designated board coordinates.
        /// </summary>
        /// <param name="tile">The board tile to move the play piece to.</param>
        /// <returns>A bool indicating whether the move was successful.</returns>
        public bool moveTo(Tile tile)
        {
            if (isValidMove(_tile, tile))
            {
                _tile._playPiece = null;
                tile._playPiece = this;
                _tile = tile;

                return true;
            }

            return false;
        }

        /// <summary>
        /// Determines if the move for a play piece is valid.
        /// </summary>
        /// <param name="fromTile">The inital tile of the play piece.</param>
        /// <param name="toTile">The tile to move to.</param>
        /// <returns>A bool indicating whether the move is legal</returns>
        public abstract bool isValidMove(Tile fromTile, Tile toTile);
    }
}
