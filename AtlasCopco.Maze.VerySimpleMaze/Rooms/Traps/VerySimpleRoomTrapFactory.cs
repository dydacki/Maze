namespace AtlasCopco.Maze.VerySimpleMaze.Rooms.Traps
{
    using System;

    using AtlasCopco.Maze.Core;
    using AtlasCopco.Maze.VerySimpleMaze.Helpers;
    using AtlasCopco.Maze.VerySimpleMaze.Rooms.Traps;

    public class VerySimpleRoomTrapFactory : IMazeRoomTrapFactory
    {
        public IMazeRoomTrap CreateTrapFor(Type t)
        {
            if (t == typeof(Desert)) 
            {
                return new DehydrationTrap();
            }

            if (t == typeof(Marsh)) 
            {
                return new SinkingTrap();
            }

            throw new ArgumentException("No trap found for the type of {0}.".InjectInvariant(t.Name));
        }
    }
}
