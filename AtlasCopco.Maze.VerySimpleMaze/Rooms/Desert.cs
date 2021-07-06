namespace AtlasCopco.Maze.VerySimpleMaze.Rooms
{
    using AtlasCopco.Maze.Core;
    using AtlasCopco.Maze.VerySimpleMaze.Rooms.Traps;

    public class Desert : MazeTrapRoom
    {
        private const string Description =
            @"Something to figure about the desert.";

        public Desert(int roomId) : base(roomId, Description, new DehydrationTrap())
        {
        }
    }
}
