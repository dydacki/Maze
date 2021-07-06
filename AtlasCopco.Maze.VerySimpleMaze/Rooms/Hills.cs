namespace AtlasCopco.Maze.VerySimpleMaze.Rooms
{
    using AtlasCopco.Maze.Core;

    public class Hills : MazeRoom
    {
        private const string Description =
            @"You open a huge door with a crackling noise. In the dark woods you navigate the path not by sight yet
              by faith and memory.";

        public Hills(int roomId) : base(roomId, Description)
        {
        }
    }
}
