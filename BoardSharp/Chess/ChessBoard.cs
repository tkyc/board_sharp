using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using BoardSharp.Common;

namespace BoardSharp.Chess
{
    /// <summary>
    /// Chess board class.
    /// </summary>
    public class ChessBoard : Board, ISelection
    {
        /// <summary>
        /// The selected play piece.
        /// </summary>
        public PlayPiece selectedPlayPiece { get; set; }

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
                    //Event handler queue -- the order handlers are executed when click a tile
                    _tiles[row, column].Click += OnSelectPlayPiece;
                    _tiles[row, column].Click += SelectPlayPiece;

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
                    InitializeChessPieceAt(_tiles[row, column]);
                }
            }
        }

        /// <summary>
        /// Creates chess piece at the designated tile if it is a default location.
        /// Default locations are locations where chess pieces initially start at.
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
                case 0:
                    tile.PlayPiece = new Pawn(ChessPiece.BLACK_PAWN, tile);
                    break;
                case 1: case 8:
                    tile.PlayPiece = new Rook(ChessPiece.BLACK_ROOK, tile);
                    break;
                case 2: case 7:
                    tile.PlayPiece = new Knight(ChessPiece.BLACK_KNIGHT, tile);
                    break;
                case 3: case 6:
                    tile.PlayPiece = new Bishop(ChessPiece.BLACK_BISHOP, tile);
                    break;
                case 4:
                    tile.PlayPiece = new Queen(ChessPiece.BLACK_QUEEN, tile);
                    break;
                case 5:
                    tile.PlayPiece = new King(ChessPiece.BLACK_KING, tile);
                    break;

                //White pieces pieces initialization
                case 17:
                    tile.PlayPiece = new Pawn(ChessPiece.WHITE_PAWN, tile);
                    break;
                case 16: case 9:
                    tile.PlayPiece = new Rook(ChessPiece.WHITE_ROOK, tile);
                    break;
                case 15: case 10:
                    tile.PlayPiece = new Knight(ChessPiece.WHITE_KNIGHT, tile);
                    break;
                case 14: case 11:
                    tile.PlayPiece = new Bishop(ChessPiece.WHITE_BISHOP, tile);
                    break;
                case 13:
                    tile.PlayPiece = new King(ChessPiece.WHITE_KING, tile);
                    break;
                case 12:
                    tile.PlayPiece = new Queen(ChessPiece.WHITE_QUEEN, tile);
                    break;
                
                //If calculation of tile's _x and _y does not match a case => do not add a chess piece to tile
                default:
                    return;
            }
        }

        /// <summary>
        /// Method to select play piece.
        /// </summary>
        /// <param name="sender">Tile object.</param>
        /// <param name="e">Event object.</param>
        public void SelectPlayPiece(object sender, RoutedEventArgs e)
        {
            if (selectedPlayPiece == null)
            {
                Trace.WriteLine("Called from select...");

                selectedPlayPiece = ((Tile)sender).PlayPiece;
            }
        }

        /// <summary>
        /// Method to on select play piece.
        /// </summary>
        /// <param name="sender">Tile object.</param>
        /// <param name="e">Event object.</param>
        public void OnSelectPlayPiece(object sender, RoutedEventArgs e)
        {
            if (selectedPlayPiece != null)
            {
                Trace.WriteLine("Called from on select...");

                ((ChessPiece)selectedPlayPiece).MoveTo((Tile)sender);

                selectedPlayPiece = null;
            }
        }
    }
}
