﻿using System;
using System.Collections.Generic;
using System.Text;
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
        /// <param name="position">The initial/current position of the pawn.</param>
        public Pawn(Tile position) : base("Pawn", position, ChessPieceEnum.Pawn) {}

        /// <summary>
        /// Determines if the move for a pawn piece is valid.
        /// </summary>
        /// <param name="fromTile">The inital tile of the pawn piece.</param>
        /// <param name="toTile">The tile to move to.</param>
        /// <returns>A bool indicating whether the move is legal</returns>
        public override bool isValidMove(Tile fromTile, Tile toTile)
        {
            throw new NotImplementedException();
        }
    }
}
