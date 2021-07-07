namespace AtlasCopco.Maze.VerySimpleMaze.Rooms
{
    using AtlasCopco.Maze.Core;

    public class Entrance : MazeRoom
    {
        private const string Description =
            "This otherwise normal space has one distinguishing feature. The stone around the door has been pulled over " +
            "its edges, as though the rock were as soft as clay and could be moved with fingers.The stone of the door " +
            "and wall seems hastily molded together.";

        public Entrance(int roomId) : base(roomId, Description, true)
        {
        }
    }
}
