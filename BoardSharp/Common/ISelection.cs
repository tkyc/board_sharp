using System.Windows;

namespace BoardSharp.Common
{
    /// <summary>
    /// Interface for play piece selection interaction.
    /// Derived board classes may or may not implement. Selection should be board level functionality b/c the board aggregates Tiles.
    /// FYI, OnSelect should be first in event handler queue.
    ///     Ex. Tile.Click += Onselect //OnSelect is first
    ///         Tile.Click += Select
    /// </summary>
    public interface ISelection
    {
        /// <summary>
        /// The selected play piece.
        /// </summary>
        public PlayPiece selectedPlayPiece { get; set; }

        /// <summary>
        /// Method to select play piece. Called if a play piece is not selected.
        /// </summary>
        /// <param name="sender">Tile object.</param>
        /// <param name="e">Event object.</param>
        public void SelectPlayPiece(object sender, RoutedEventArgs e);

        /// <summary>
        /// Method to perform an on select function on play piece. Called if play piece is selected.
        /// </summary>
        /// <param name="sender">Tile object.</param>
        /// <param name="e">Event object.</param>
        public void OnSelectPlayPiece(object sender, RoutedEventArgs e);
    }
}
