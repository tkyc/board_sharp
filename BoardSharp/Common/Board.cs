using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace BoardSharp.Common 
{
    class Board : Grid
    {
        protected int _rows;
        protected int _columns;
        protected Tile[,] _tiles;

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
                ColumnDefinitions.Add(new ColumnDefinition());

                for (int column = 0; column < _columns; column++)
                {
                    Tile tile = new Tile(row, column);

                    _tiles[row, column] = tile;
                    Children.Add(tile);

                    SetRow(tile, row);
                    SetColumn(tile, column);
                }
            }
        }

        public void InitBoardGui(Window window)
        {
            window.Content = this;
            window.SizeToContent = SizeToContent.WidthAndHeight;
        }
    }
}
