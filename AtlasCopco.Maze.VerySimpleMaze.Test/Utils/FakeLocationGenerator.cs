namespace AtlasCopco.Maze.VerySimpleMaze.Test.Utils
{
    using AtlasCopco.Maze.Core;
    using AtlasCopco.Maze.VerySimpleMaze;

    public class FakeLocationGenerator : ILocationGenerator
    {
        public Location GenerateEdgeLocation(int size)
        {
            return new Location(0, 0);
        }

        public Location GenerateInnerLocation(int size)
        {
            return new Location(size / 2, size / 2);
        }
    }
}
