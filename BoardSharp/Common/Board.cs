using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace BoardSharp.Common 
{
    /// <summary>
    /// Generic board object.
    /// FYI -- "row" is synonymous with "x" coordinate and "column" is synonymous with "y" coordinate.
    /// </summary>
    public abstract class Board : Grid
    {
        /// <summary>
        /// Number of rows within the board.
        /// </summary>
        protected int _rows;

        /// <summary>
        /// Number of columns withing the board.
        /// </summary>
        protected int _columns;

        /// <summary>
        /// A 2D tile matrix that comprises the board.
        /// </summary>
        protected Tile[,] _tiles;

        /// <summary>
        /// Board constructor.
        /// Number of tiles is rows * columns.
        /// </summary>
        /// <param name="rows">The number of rows within the board.</param>
        /// <param name="columns">The number of columns withing the board.</param>
        public Board(int rows, int columns)
        {
            _rows = rows;
            _columns = columns;
            _tiles = new Tile[_rows, _columns];

            Width = _rows * Tile.WIDTH;
            Height = _columns * Tile.HEIGHT;

            for (int row = 0; row < _rows; row++)
            {
                RowDefinitions.Add(new RowDefinition());

                for (int column = 0; column < _columns; column++)
                {
                    if (column == 0) ColumnDefinitions.Add(new ColumnDefinition());

                    Tile tile = new Tile(row, column);

                    _tiles[row, column] = tile;
                    Children.Add(tile);

                    SetRow(tile, row);
                    SetColumn(tile, column);
                }
            }
        }

        /// <summary>
        /// Initialized the board GUI.
        /// </summary>
        /// <param name="window">The window object of the program.</param>
        public void InitBoardGui(Window window)
        {
            window.Content = this;
            window.SizeToContent = SizeToContent.WidthAndHeight;
        }

        /// <summary>
        /// Gets the play piece at the specified tile.
        /// </summary>
        /// <param name="row">Row of play piece.</param>
        /// <param name="column">Column of play piece.</param>
        /// <returns>The play piece at the designated tile.</returns>
        public PlayPiece GetPlayPieceAt(int row, int column)
        {
            return _tiles[row, column].PlayPiece;
        }

        /// <summary>
        /// Resets the play pieces on the board.
        /// </summary>
        public abstract void ResetBoard();
    }
}
