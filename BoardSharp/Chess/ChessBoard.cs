using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
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
            var brushConverter = new BrushConverter();

            for (int row = 0; row < _rows; row++)
            {
                for (int column = 0; column < _columns; column++)
                {
                    if (row % 2 != 0 && column % 2 == 0) _tiles[row, column].Background = (Brush) brushConverter.ConvertFrom("#838383"); //Odd indexed row

                    else if (row % 2 == 0 && column % 2 != 0) _tiles[row, column].Background = (Brush) brushConverter.ConvertFrom("#838383"); //Even index row
                }
            }
        }

        /// <summary>
        /// Resets the chess pieces on the chess board.
        /// </summary>
        public override void resetBoard()
        {
            for (int row = 0; row < _rows; row++)
            {
                for (int column = 0; column < _columns; column++)
                {
                    //Reset tile
                    _tiles[row, column].PlayPiece = null;

                    switch (row)
                    {
                        case 1:
                            Pawn blackPawn = new Pawn("black_pawn", _tiles[row, column]);
                            _tiles[row, column].PlayPiece = blackPawn;
                            break;
                        
                        case 6:
                            Pawn whitePawn = new Pawn("white_pawn", _tiles[row, column]);
                            _tiles[row, column].PlayPiece = whitePawn;
                            break;

                        case 0:
                            if (column == 0 || column == 7)
                            {
                                Rook blackRook = new Rook("black_rook", _tiles[row, column]);
                                _tiles[row, column].PlayPiece = blackRook;

                            } else if (column == 1 || column == 6)
                            {
                                Knight blackKnight = new Knight("black_knight", _tiles[row, column]);
                                _tiles[row, column].PlayPiece = blackKnight;

                            } else if (column == 2 || column == 5)
                            {
                                Bishop blackBishop = new Bishop("black_bishop", _tiles[row, column]);
                                _tiles[row, column].PlayPiece = blackBishop;

                            } else if (column == 3)
                            {
                                Queen blackQueen = new Queen("black_queen", _tiles[row, column]);
                                _tiles[row, column].PlayPiece = blackQueen;

                            } else if (column == 4)
                            {
                                King blackKing = new King("black_king", _tiles[row, column]);
                                _tiles[row, column].PlayPiece = blackKing;
                            }
                            break;

                        case 7:
                            if (column == 0 || column == 7)
                            {
                                Rook whiteRook = new Rook("white_rook", _tiles[row, column]);
                                _tiles[row, column].PlayPiece = whiteRook;

                            } else if (column == 1 || column == 6)
                            {
                                Knight whiteKnight = new Knight("white_knight", _tiles[row, column]);
                                _tiles[row, column].PlayPiece = whiteKnight;

                            } else if (column == 2 || column == 5)
                            {
                                Bishop whiteBishop = new Bishop("white_bishop", _tiles[row, column]);
                                _tiles[row, column].PlayPiece = whiteBishop;

                            } else if (column == 3)
                            {
                                Queen whiteQueen = new Queen("white_queen", _tiles[row, column]);
                                _tiles[row, column].PlayPiece = whiteQueen;

                            } else if (column == 4)
                            {
                                King whiteKing = new King("white_king", _tiles[row, column]);
                                _tiles[row, column].PlayPiece = whiteKing;
                            }
                            break;
                    }
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
