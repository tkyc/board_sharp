using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace BoardSharp.Common
{
    /// <summary>
    /// Generic board game piece class.
    /// </summary>
    public abstract class PlayPiece
    {
        /// <summary>
        /// Name of the play piece.
        /// </summary>
        public string _name { get; }

        public Image _playPieceImage { get; }

        /// <summary>
        /// The tile the play piece is currently located at.
        /// </summary>
        public Tile _tile { get; protected set; }

        /// <summary>
        /// Play piece
        /// </summary>
        /// <param name="name">Name of the play piece.</param>
        /// <param name="tile">The initial/current position of the play piece.</param>
        public PlayPiece(string name,  Tile tile)
        {
            _name = name;
            _tile = tile;

            Image playPieceImage = new Image();
            playPieceImage.Source = new BitmapImage(new Uri($"pack://application:,,,/Chess/Images/{_name}.png"));
            _playPieceImage = playPieceImage;
        }
    }
}
