namespace AtlasCopco.Maze.VerySimpleMaze.Test.Utils
{
    using System;

    using AtlasCopco.Maze.Core;
    using AtlasCopco.Maze.VerySimpleMaze.Rooms.Traps;
    using Moq;

    public class SafeTrapFactory : IMazeRoomTrapFactory
    {
        public IMazeRoomTrap CreateTrapFor(Type t)
        {
            var moqTrap = new Mock<IMazeRoomTrap>();
            moqTrap.Setup(trap => trap.Fire())
                   .Returns(false);

            return moqTrap.Object;
        }
    }
}
