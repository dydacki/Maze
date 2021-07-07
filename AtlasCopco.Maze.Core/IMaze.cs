namespace AtlasCopco.Maze.Core
{
    /// <summary>
    /// Exposes basic features of a maze.
    /// </summary>
    public interface IMaze
    {
        /// <summary>
        /// Gets an instance of the <see cref="IMazeRoom"/> from a specified position of the <see cref="IMaze"/>.
        /// </summary>
        /// <param name="location">The location of the <see cref="IMazeRoom"/> to retrieve.</param>
        /// <returns>An instance of the <see cref="IMazeRoom"/> from the specified position.</returns>
        IMazeRoom GetRoom(Location location);

        /// <summary>
        /// Gets an instance of the <see cref="IMazeRoom"/> adjacent to the room specified with location,
        /// in the selected direction.
        /// </summary>
        /// <param name="location">The location of the current <see cref="IMazeRoom"/>.</param>
        /// <param name="direction">The direction of the <see cref="IMazeRoom"/> to retrieve, compared to the current <paramref name="location"/>.</param>
        /// <returns>An instance of the <see cref="IMazeRoom"/> adjacent to the room 
        /// with the specified <paramref name="location"/> in the specified <paramref name="direction"/>.
        /// Null if there isn't any.
        /// </returns>
        IMazeRoom GetAdjacentRoom(Location location, char direction);

        /// <summary>
        /// Gets the length of the maze.
        /// </summary>
        int Length { get; }

        /// <summary>
        /// Gets the width of the maze.
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Gets the entrance room location.
        /// </summary>
        Location EntranceLocation { get; }
    }
}
