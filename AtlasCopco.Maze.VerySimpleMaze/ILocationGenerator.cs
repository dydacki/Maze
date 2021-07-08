namespace AtlasCopco.Maze.VerySimpleMaze
{
    using AtlasCopco.Maze.Core;

    /// <summary>
    /// Exposes the functionality of generating random 
    /// instances of the <see cref="Location"/> class.
    /// </summary>
    public interface ILocationGenerator
    {
        /// <summary>
        /// Generates an instance of the <see cref="Location"/> class
        /// situated on the edge of the <see cref="IMaze"/>.
        /// </summary>
        /// <param name="size">
        /// Verticular or horizontal dimension of the <see cref="IMaze"/>.
        /// </param>
        /// <returns>
        /// An instance of the <see cref="Location"/> class.
        /// </returns>
        Location GenerateEdgeLocation(int size);

        /// <summary>
        /// Generates an instance of the <see cref="Location"/> class
        /// situated in the internal part of the <see cref="IMaze"/>.
        /// </summary>
        /// <param name="size">
        /// Verticular or horizontal dimension of the <see cref="IMaze"/>.
        /// </param>
        /// <returns>
        /// An instance of the <see cref="Location"/> class.
        /// </returns>
        Location GenerateInnerLocation(int size);
    }
}
