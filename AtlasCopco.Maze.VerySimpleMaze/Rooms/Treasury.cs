namespace AtlasCopco.Maze.VerySimpleMaze.Rooms
{
    using AtlasCopco.Maze.Core;

    public class Treasury : MazeRoom
    {
        private const string Description = @"Treasury description goes here.";

        public Treasury(int roomId) : base(roomId, Description)
        {
        }
    }
}
