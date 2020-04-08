using System;
using System.Collections.Generic;
using System.Text;
using BoardSharp.Common;

namespace BoardSharp.Chess
{
    abstract class ChessPiece : PlayPiece, IPlayPiece
    {
        public abstract bool move(Tile tile);
    }
}
