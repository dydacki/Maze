namespace AtlasCopco.Maze.VerySimpleMaze
{
    using System;

    using AtlasCopco.Maze.Core;

    public class VerySimpleLocationGenerator : ILocationGenerator
    {
        public Location GenerateEdgeLocation(int size)
        {
            var x = new Random().Next(size);
            if (x != 0)
            {
                return new Location(x, 0);
            }

            return new Location(x, new Random().Next(size));
        }

        public Location GenerateInnerLocation(int size)
        {
            return new Location(new Random().Next(1, size), new Random().Next(1, size));
        }
    }
}
