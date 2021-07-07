namespace AtlasCopco.Maze.VerySimpleMaze
{
    using System;

    using AtlasCopco.Maze.Core;
    using AtlasCopco.Maze.VerySimpleMaze.Helpers;

    public class VerySimpleMaze : IMaze
    {
        public VerySimpleMaze(IMazeRoom[,] mazeRooms) 
        {
            this.MazeRooms = mazeRooms;
        }

        public int Length => this.MazeRooms.GetLength(0);

        public int Width => this.MazeRooms.GetLength(1);

        private IMazeRoom[,] MazeRooms { get; }

        public Location EntranceLocation => this.GetEntranceLocation();

        public void AddRoom(IMazeRoom mazeRoom, Location location)
        {            
            this.MazeRooms[location.X, location.Y] = mazeRoom;
        }

        public IMazeRoom GetRoom(Location location)
        {
            if (location.X < 0 || location.X > this.MazeRooms.GetLength(0) || location.Y < 0 || location.Y > this.MazeRooms.GetLength(1))
            {
                return null;
            }

            return this.MazeRooms[location.X, location.Y];
        }

        private Location GetEntranceLocation() 
        {
            for (int i = 0; i < this.MazeRooms.GetLength(0); i++)
            {
                for (int j = 0; j < this.MazeRooms.GetLength(1); j++)
                {
                    var location = new Location(i, j);
                    if (this.GetRoom(location).IsEntrance)
                    {
                        return location;
                    }
                }
            }

            throw new Exception("Entrance not found!");
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
    }
}
