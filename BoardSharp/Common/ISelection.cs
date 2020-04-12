using System.Windows;
using System.Windows.Media;

namespace BoardSharp.Common
{
    /// <summary>
    /// Interface for general selection interaction.
    /// Derived board classes may or may not implement. Selection should be board level functionality b/c the board aggregates Tiles.
    /// 
    /// FYI, there is a event handler queue.
    ///     Ex. Tile.Click += Onselect //OnSelect is added first
    ///         Tile.Click += Select
    /// </summary>
    public interface ISelection
    {
        /// <summary>
        /// The selected object.
        /// </summary>
        public object selected { get; set; }

        /// <summary>
        /// Method to select object.
        /// </summary>
        /// <param name="sender">object calling event handler.</param>
        /// <param name="e">Event object.</param>
        public void HandleSelected(object sender, RoutedEventArgs e);
    }
}
