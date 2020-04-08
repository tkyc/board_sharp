using System;
using System.Collections.Generic;
using System.Text;
using BoardSharp.Common;

namespace BoardSharp.Chess
{
    class Pawn : ChessPiece
    {
        public override bool move(Tile tile)
        {
            //TODO - enforce movement rules.
            tile._playPiece = this;
            return true;
        }
    }
}
