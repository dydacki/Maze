namespace AtlasCopco.Maze.VerySimpleMaze
{
    using System;

    using AtlasCopco.Maze.Core;
    using AtlasCopco.Maze.VerySimpleMaze.Helpers;

    public class VerySimpleMaze : IMaze
    {
        public VerySimpleMaze(IMazeRoom[,] mazeRooms, Location entranceLocation) 
        {
            this.MazeRooms = mazeRooms;
            this.EntranceLocation = entranceLocation;
        }

        public int Length => this.MazeRooms.GetLength(0);

        public int Width => this.MazeRooms.GetLength(1);

        public Location EntranceLocation { get; private set; }

        private IMazeRoom[,] MazeRooms { get; }

        public IMazeRoom GetRoom(Location location)
        {
            if (location.X < 0 || location.X > this.MazeRooms.GetLength(0) || location.Y < 0 || location.Y > this.MazeRooms.GetLength(1))
            {
                return null;
            }

            return this.MazeRooms[location.X, location.Y];
        }

        public IMazeRoom GetAdjacentRoom(Location location, char direction)
        {
            switch (char.ToUpper(direction)) 
            {
                case 'N':
                    return this.GetRoom(location.North);
                case 'E':
                    return this.GetRoom(location.East);
                case 'S':
                    return this.GetRoom(location.South);
                case 'W':
                    return this.GetRoom(location.West);
                default:
                    throw new ArgumentException("Unknown direction: '{0}'".InjectInvariant(direction));
            }
        }

        public override string ToString()
        {
            var mazeString = string.Empty;
            for (var i = 0; i < this.Length; i++)
            {
                for (var j = 0; j < this.Width; j++)
                {
                    mazeString += "[{0}]".InjectInvariant(this.GetRoom(new Location(i, j)).GetType().Name.PadRight(10));
                }

                mazeString += Environment.NewLine;
            }

            return mazeString;
        }
    }
}
