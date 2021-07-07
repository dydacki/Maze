namespace AtlasCopco.Maze.VerySimpleMaze.Rooms
{
    using AtlasCopco.Maze.Core;

    public class Desert : MazeTrapRoom
    {
        private const string Description =
            @"Something to figure about the desert.";

        public Desert(int roomId, IMazeRoomTrap roomTrap) : base(roomId, Description, roomTrap)
        {
        }
    }
}
