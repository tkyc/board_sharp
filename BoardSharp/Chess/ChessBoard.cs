﻿using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using System.Collections.Generic;
using BoardSharp.Common;

namespace BoardSharp.Chess
{
    /// <summary>
    /// Chess board class.
    /// </summary>
    public class ChessBoard : Board, ISelection
    {
        /// <summary>
        /// The player's side. Either black or white.
        /// </summary>
        public Side _side { get; }

        /// <summary>
        /// The currently selected chess piece.
        /// </summary>
        public static object selected { get; set; }

        /// <summary>
        /// ChessBoard constructor.
        /// </summary>
        /// <param name="side">Chess side -- black or white.</param>
        public ChessBoard(Side side) : base(8, 8) 
        {
            _side = side;

            var brushConverter = new BrushConverter();

            for (int row = 0; row < _rows; row++)
            {
                for (int column = 0; column < _columns; column++)
                {
                    //Event handler queue -- the order handlers are executed when clicking a tile
                    _tiles[row, column].Click += HandleSelected;

                    if (row % 2 != 0 && column % 2 == 0) _tiles[row, column].Background = (Brush) brushConverter.ConvertFrom("#838383"); //Odd indexed row

                    else if (row % 2 == 0 && column % 2 != 0) _tiles[row, column].Background = (Brush) brushConverter.ConvertFrom("#838383"); //Even index row
                }
            }
        }

        /// <summary>
        /// Resets the chess pieces on the chess board.
        /// </summary>
        public override void ResetBoard()
        {
            for (int row = 0; row < _rows; row++)
            {
                for (int column = 0; column < _columns; column++)
                {
                    //Reset tile
                    _tiles[row, column].RemovePlayPiece();

                    //Will init a chess piece at tile if it is a designated default location
                    //Default locations are where chess pieces initially start out
                    //InitializeChessPieceAt(_tiles[row, column]);
                    ExplicitlyInitializeChessPieceAt(_tiles[row, column], _side);
                }
            }
        }

        /// <summary>
        /// Creates chess piece at the designated tile if it is a default location.
        /// Default locations are locations where chess pieces initially start at.
        /// This method is for multiplayer.
        /// </summary>
        /// <param name="tile">Tile to create chess piece at.</param>
        /// <param name="side">Chess side -- black or white.</param>
        /// <returns>The created chess piece.</returns>
        private PlayPiece ExplicitlyInitializeChessPieceAt(Tile tile, Side side)
        {
            int pawn = side == Side.WHITE ? 0 : 5;

            return (tile._x, tile._y) switch
            {
                //White chess pieces initialization
                var (x, _) when x == 6 - pawn                                        => tile.PlayPiece = new Pawn(ChessPiece.WHITE_PAWN, tile, Side.WHITE),
                var (x, y) when x == 7 - (int) side && (y == 0 || y == 7)            => tile.PlayPiece = new Rook(ChessPiece.WHITE_ROOK, tile, Side.WHITE),
                var (x, y) when x == 7 - (int) side && (y == 1 || y == 6)            => tile.PlayPiece = new Knight(ChessPiece.WHITE_KNIGHT, tile, Side.WHITE),
                var (x, y) when x == 7 - (int) side && (y == 2 || y == 5)            => tile.PlayPiece = new Bishop(ChessPiece.WHITE_BISHOP, tile, Side.WHITE),
                var (x, y) when x == 7 - (int) side && y == Math.Abs(3 - (int) side) => tile.PlayPiece = new Queen(ChessPiece.WHITE_QUEEN, tile, Side.WHITE),
                var (x, y) when x == 7 - (int) side && y == Math.Abs(4 - (int) side) => tile.PlayPiece = new King(ChessPiece.WHITE_KING, tile, Side.WHITE),

                //Black cess pieces initi(int) sidezation
                var (x, _) when x == 1 + pawn                                        => tile.PlayPiece = new Pawn(ChessPiece.BLACK_PAWN, tile, Side.BLACK),
                var (x, y) when x == 0 + (int) side && (y == 0 || y == 7)            => tile.PlayPiece = new Rook(ChessPiece.BLACK_ROOK, tile, Side.BLACK),
                var (x, y) when x == 0 + (int) side && (y == 1 || y == 6)            => tile.PlayPiece = new Knight(ChessPiece.BLACK_KNIGHT, tile, Side.BLACK),
                var (x, y) when x == 0 + (int) side && (y == 2 || y == 5)            => tile.PlayPiece = new Bishop(ChessPiece.BLACK_BISHOP, tile, Side.BLACK),
                var (x, y) when x == 0 + (int) side && y == Math.Abs(3 - (int) side) => tile.PlayPiece = new Queen(ChessPiece.BLACK_QUEEN, tile, Side.BLACK),
                var (x, y) when x == 0 + (int) side && y == Math.Abs(4 - (int) side) => tile.PlayPiece = new King(ChessPiece.BLACK_KING, tile, Side.BLACK),
                _ => null
            };
        }

        /// <summary>
        /// Creates chess piece at the designated tile if it is a default location.
        /// Default locations are locations where chess pieces initially start at.
        /// This method is for single player.
        /// </summary>
        /// <param name="tile">The tile to create the chess piece at.</param>
        private void InitializeChessPieceAt(Tile tile)
        {
            //chessPiece depends on calculated result of tile's _x and _y
            int chessPiece = ((Func<int>)(() => 
            {
                if (tile._x == 1) return 0;
                if (tile._x == 6) return 17;
                if (tile._x == 7) { return tile._x + tile._y + 2; }
                if (tile._x == 0) { return tile._x + tile._y + 1; }
                return -1;
            }))();

            switch (chessPiece)
            {
                //Black chess pieces initialization
                case 0:           tile.PlayPiece = new Pawn(ChessPiece.BLACK_PAWN, tile, Side.BLACK); break;
                case 1: case 8:   tile.PlayPiece = new Rook(ChessPiece.BLACK_ROOK, tile, Side.BLACK); break;
                case 2: case 7:   tile.PlayPiece = new Knight(ChessPiece.BLACK_KNIGHT, tile, Side.BLACK); break;
                case 3: case 6:   tile.PlayPiece = new Bishop(ChessPiece.BLACK_BISHOP, tile, Side.BLACK); break;
                case 4:           tile.PlayPiece = new Queen(ChessPiece.BLACK_QUEEN, tile, Side.BLACK); break;
                case 5:           tile.PlayPiece = new King(ChessPiece.BLACK_KING, tile, Side.BLACK); break;

                //White chess pieces initialization
                case 17:          tile.PlayPiece = new Pawn(ChessPiece.WHITE_PAWN, tile, Side.WHITE); break;
                case 16: case 9:  tile.PlayPiece = new Rook(ChessPiece.WHITE_ROOK, tile, Side.WHITE); break;
                case 15: case 10: tile.PlayPiece = new Knight(ChessPiece.WHITE_KNIGHT, tile, Side.WHITE); break;
                case 14: case 11: tile.PlayPiece = new Bishop(ChessPiece.WHITE_BISHOP, tile, Side.WHITE); break;
                case 13:          tile.PlayPiece = new King(ChessPiece.WHITE_KING, tile, Side.WHITE); break;
                case 12:          tile.PlayPiece = new Queen(ChessPiece.WHITE_QUEEN, tile, Side.WHITE); break;
                
                //If calculation of tile's _x and _y does not match a case => do not add a chess piece to tile
                default: return;
            }
        }

        /// <summary>
        /// Method to handle selected play piece.
        /// </summary>
        /// <param name="sender">Tile object.</param>
        /// <param name="e">Event object.</param>
        public void HandleSelected(object sender, RoutedEventArgs e)
        {
            if (selected == null)
            {
                selected = ((Tile)sender).PlayPiece;

            } else
            {
                ((ChessPiece)selected).MoveTo((Tile)sender);

                selected = null;
            }
        }
    }
}
