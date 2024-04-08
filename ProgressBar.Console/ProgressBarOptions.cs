using System;

namespace Bardin08.ProgressBar
{
    /// <summary>
    /// Represents options for customizing a console progress bar.
    /// </summary>
    public class ProgressBarOptions
    {
        /// <summary>
        /// Gets or sets the width of the progress bar in characters.
        /// </summary>
        public int Width { get; set; } = 50;

        /// <summary>
        /// Gets or sets the character used to fill the progress bar.
        /// </summary>
        public char Filler { get; set; } = '█';

        /// <summary>
        /// Gets or sets the character that represents an arrow for the progress bar.
        /// </summary>
        public char Arrow { get; set; } = '█';

        /// <summary>
        /// Gets or sets the prefix to be displayed before the progress bar.
        /// Can be used to add a label or tabulation.
        /// </summary>
        public string Prefix { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether to display the elapsed time alongside the progress bar.
        /// </summary>
        public bool DisplayElapsedTime { get; set; } = false;

        /// <summary>
        /// Gets or sets the color of the progress bar.
        /// </summary>
        public ConsoleColor? Color { get; set; } = null;
    }
}