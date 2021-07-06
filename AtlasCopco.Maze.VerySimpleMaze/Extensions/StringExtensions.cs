namespace AtlasCopco.Maze.VerySimpleMaze.Extensions
{
    using System.Globalization;

    /// <summary>
    /// Extension methods for <see cref="string" />s.
    /// </summary>
    internal static class StringExtensions
    {
        /// <summary>
        /// Extension method wrapping string.Format with InvariantCulture.
        /// </summary>
        /// <param name="format">The format string.</param>
        /// <param name="parameters">The positional parameters.</param>
        /// <returns>Invariant formatted string.</returns>
        internal static string InjectInvariant(this string format, params object[] parameters)
        {
            return string.Format(CultureInfo.InvariantCulture, format, parameters);
        }
    }
}
