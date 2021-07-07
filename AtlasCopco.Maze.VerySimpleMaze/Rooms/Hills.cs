namespace AtlasCopco.Maze.VerySimpleMaze.Rooms
{
    using AtlasCopco.Maze.Core;

    public class Hills : MazeRoom
    {
        private const string Description =
            "As you exit the cramped hallway you are met with a fresh breath of air. In front of you is a vast area of " +
            "hills covered in fields of grass and boulders. You can hear cicadas in the distance and glimpse a predatory " +
            "bird as it pass the glaring sun in the sky.";

        public Hills(int roomId) : base(roomId, Description)
        {
        }
    }
}
