namespace AtlasCopco.Maze.VerySimpleMaze.Rooms
{
    using System;
    using AtlasCopco.Maze.Core;

    /// <summary>
    /// 
    /// </summary>
    public interface IMazeRoomTrapFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        IMazeRoomTrap CreateTrapFor(Type t);
    }
}
