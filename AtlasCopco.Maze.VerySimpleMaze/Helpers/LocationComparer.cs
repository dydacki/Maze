namespace AtlasCopco.Maze.VerySimpleMaze.Helpers
{
    using System.Collections.Generic;

    using AtlasCopco.Maze.Core;

    public class LocationComparer : IEqualityComparer<Location>
    {
        public bool Equals(Location x, Location y)
        {
            return x.X == y.X && x.Y == y.Y;
        }

        public int GetHashCode(Location obj)
        {
            return obj.X.GetHashCode() ^ obj.Y.GetHashCode();
        }
    }
}
