﻿using System;
using System.Diagnostics;
using BoardSharp.Common;

namespace BoardSharp.Chess
{
    /// <summary>
    /// Pawn chess piece class.
    /// </summary>
    public class Pawn : ChessPiece
    {
        /// <summary>
        /// Pawn constructor.
        /// </summary>
        /// <param name="name">Name of the pawn (black_pawn or white_pawn).</param>
        // <param name="position">The initial/current position of the pawn.</param>
        public Pawn(string name, Tile position, Side side) : base(name, position, side) {}

        /// <summary>
        /// Determines if the move for a pawn piece is valid.
        /// </summary>
        /// <param name="fromTile">The inital tile of the pawn piece.</param>
        /// <param name="toTile">The tile to move to.</param>
        /// <returns>A bool indicating whether the move is legal</returns>
        public override bool IsValidMove(Tile fromTile, Tile toTile)
        {
            bool @base= base.IsValidMove(fromTile, toTile);

            bool isValid = ((Func<bool>)(() =>
            {
                //Can move 2 squares on first turn
                bool firstTurn = fromTile._x == 6 && fromTile._x - toTile._x == 2;

                //Attack diagonally
                //TODO -- attack diagonally

                //Can move 1 square forward
                return fromTile._x - toTile._x == 1 || firstTurn;

            }))();

            return @base && isValid;
        }
    }
}
