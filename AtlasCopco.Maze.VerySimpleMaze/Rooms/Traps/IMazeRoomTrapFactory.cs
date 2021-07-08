namespace AtlasCopco.Maze.VerySimpleMaze.Rooms.Traps
{
    using System;
    using AtlasCopco.Maze.Core;

    /// <summary>
    /// Exposes a functionality of a trap factory for maze rooms.
    /// </summary>
    public interface IMazeRoomTrapFactory
    {
        /// <summary>
        /// Creates an instance of the <see cref="IMazeRoomTrap"/> for a maze room.
        /// </summary>
        /// <param name="t">
        /// The <see cref="Type"/> of the room that a trap is created for.
        /// </param>
        /// <returns>
        /// An instance of the <see cref="IMazeRoomTrap"/> for a maze room.
        /// </returns>
        IMazeRoomTrap CreateTrapFor(Type t);
    }
}
