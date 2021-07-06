namespace AtlasCopco.Maze.Core
{
    /// <summary>
    /// A facade for building different kinds of mazes.
    /// </summary>
    public interface IMazeFactory
    {
        /// <summary>
        /// Builds and returns an instance of the <see cref="IMaze"/> interface.
        /// </summary>
        /// <param name="size">Width or height of the maze to be built.</param>
        /// <returns>
        /// An instance of the <see cref="IMaze"/> interface.
        /// </returns>
        IMaze BuildMaze(int size);
    }
}
