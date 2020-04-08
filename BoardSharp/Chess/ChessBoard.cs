using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using BoardSharp.Common;

namespace BoardSharp.Chess
{
    class ChessBoard : Board
    {
        public ChessBoard(int rows, int columns) : base(rows, columns) 
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
            return ((ChessPiece) playPiece).move(tile);
        }
    }
}
