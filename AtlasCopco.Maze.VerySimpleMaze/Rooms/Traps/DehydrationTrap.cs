namespace AtlasCopco.Maze.VerySimpleMaze.Rooms.Traps
{
    using System;

    using AtlasCopco.Maze.Core;

    public class DehydrationTrap : IMazeRoomTrap
    {
        public string BehaviorDescription =>
            @"The heat of the dessert has burnt your body to the ground slowly, exposing your ribs and lungs...";
        
        public bool Fire()
        {
            return new Random().Next(0, 10) <= 2;
        }
    }
}
