using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using BoardSharp.Common;

namespace BoardSharp.Chess
{
    /// <summary>
    /// Chess board class.
    /// </summary>
    public class ChessBoard : Board
    {
        /// <summary>
        /// ChessBoard constructor.
        /// </summary>
        public ChessBoard() : base(8, 8) 
        {
            for (int row = 0; row < _rows; row++)
            {
                for (int column = 0; column < _columns; column++)
                {
                    if (row % 2 != 0 && column % 2 == 0) _tiles[row, column].Background = Brushes.Black; //Odd indexed row

                    else if (row % 2 == 0 && column % 2 != 0) _tiles[row, column].Background = Brushes.Black; //Even index row
                }
            }
        }

        /// <summary>
        /// Sets the chess piece at the designated tile.
        /// </summary>
        /// <param name="tile">The tile to set the chess piece at.</param>
        /// <param name="playPiece">A chess piece (pawn, rook, knight, queen...).</param>
        /// <returns>A bool indicating if the move/set was successful.</returns>
        public override bool SetPlayPieceAt(Tile tile, PlayPiece playPiece)
        {
            return ((ChessPiece) playPiece).moveTo(tile);
        }
    }
}
