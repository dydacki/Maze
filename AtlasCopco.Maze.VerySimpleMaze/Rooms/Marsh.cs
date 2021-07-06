namespace AtlasCopco.Maze.VerySimpleMaze.Rooms
{
    using AtlasCopco.Maze.Core;
    using AtlasCopco.Maze.VerySimpleMaze.Rooms.Traps;

    public class Marsh : MazeTrapRoom
    {
        private const string Description =
            @"An orchestra of chirps and croaks sweeps over these fetid waters.";

        public Marsh(int roomId) : base(roomId, Description, new SinkingTrap())
        {
        }
    }
}
