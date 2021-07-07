namespace AtlasCopco.Maze.VerySimpleMaze.Helpers
{
    using System;

    using AtlasCopco.Maze.Core;

    /// <summary>
    /// Extension methods for Core Maze library types.
    /// </summary>
    public static class CoreMazeTypesExtensions
    {
        /// <summary>
        /// Transforms an instance of the <see cref="Location"/> class 
        /// into an identifier of the <see cref="IMazeRoom"/>.
        /// </summary>
        /// <param name="location">
        /// An instance of the <see cref="Location"/> class to be transformed.
        /// </param>
        /// <param name="mazeSize">
        /// The size of the <see cref="IMaze"/> needed to calculate the room identifier.
        /// </param>
        /// <returns>
        /// A sequential room identifier in the mother strucure of the <see cref="IMaze"/>.
        /// </returns>
        public static int AsRoomId(this Location location, int mazeSize) 
        {
            if (location.X >= mazeSize || location.Y >= mazeSize)
            {
                throw new ArgumentOutOfRangeException(
                    "Invalid location coordinate. Maximum value of {0} allowed.".InjectInvariant(mazeSize - 1));
            }

            return location.Y * mazeSize + location.X;
        }

        /// <summary>
        /// Transforms an identifier of the <see cref="IMazeRoom"/>
        /// into an instance of the <see cref="Location"/> class.
        /// </summary>
        /// <param name="roomId">
        /// An identifier to be transformed.
        /// </param>
        /// <param name="mazeSize">
        /// The size of the <see cref="IMaze"/> needed to calculate the room identifier.
        /// </param>
        /// <returns>
        /// An instance of the <see cref="Location"/> class.
        /// </returns>
        public static Location AsLocation(this int roomId, int mazeSize)
        {
            if (roomId >= Math.Pow(mazeSize, 2))
            {
                throw new ArgumentOutOfRangeException(
                    "Invalid location coordinate. Maximum value of {0} allowed.".InjectInvariant(Math.Pow(mazeSize, 2) - 1));
            }

            return new Location(roomId % mazeSize, roomId / mazeSize);
        }
    }
}
