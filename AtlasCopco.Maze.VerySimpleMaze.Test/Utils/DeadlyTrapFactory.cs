namespace AtlasCopco.Maze.VerySimpleMaze.Test.Utils
{
    using System;

    using AtlasCopco.Maze.Core;
    using AtlasCopco.Maze.VerySimpleMaze.Rooms.Traps;
    using Moq;

    public class DeadlyTrapFactory : IMazeRoomTrapFactory
    {
        public IMazeRoomTrap CreateTrapFor(Type t)
        {
            var moqTrap = new Mock<IMazeRoomTrap>();
            moqTrap.Setup(trap => trap.BehaviorDescription)
                   .Returns("You're dead, game is over...");

            moqTrap.Setup(trap => trap.Fire())
                   .Returns(true);

            return moqTrap.Object;
        }
    }
}
