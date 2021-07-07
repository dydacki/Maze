namespace AtlasCopco.Maze.VerySimpleMaze.Rooms
{
    using AtlasCopco.Maze.Core;

    public class Marsh : MazeTrapRoom
    {
        private const string Description =
            @"An orchestra of chirps and croaks sweeps over these fetid waters.";

        public Marsh(int roomId, IMazeRoomTrap roomTrap) : base(roomId, Description, roomTrap)
        {
        }
    }
}
