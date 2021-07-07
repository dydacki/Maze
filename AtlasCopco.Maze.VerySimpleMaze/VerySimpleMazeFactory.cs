namespace AtlasCopco.Maze.VerySimpleMaze
{
    using System;

    using AtlasCopco.Maze.Core;
    using AtlasCopco.Maze.VerySimpleMaze.Helpers;

    /// <summary>
    /// Builds and returns an instance of the <see cref="VerySimpleMaze"/> class.
    /// </summary>
    public class VerySimpleMazeFactory : IMazeFactory
    {
        private const int MinimalMazeSize = 3;

        private int _mazeSize;
        private VerySimpleMazeRoomFactory _roomFactory;
        private Random _randomizer;

        /// <summary>
        /// Initializes a new instance of the <see cref="VerySimpleMazeFactory"/> class.
        /// </summary>
        public VerySimpleMazeFactory() : this(new VerySimpleMazeRoomFactory(), new Random())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VerySimpleMazeFactory"/> class.
        /// </summary>
        /// <param name="roomFactory">
        /// An instance of the <see cref="VerySimpleMazeRoomFactory"/> class.
        /// </param>
        /// <param name="randomizer">
        /// An instance of the <see cref="Random"/> class.
        /// </param>
        public VerySimpleMazeFactory(VerySimpleMazeRoomFactory roomFactory, Random randomizer) 
        {
            this._roomFactory = roomFactory;
            this._randomizer = randomizer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public IMaze BuildMaze(int size)
        {
            if (size < MinimalMazeSize) 
            {
                throw new ArgumentOutOfRangeException(
                    "The stage edge cannot be smaller than {0} elements.".InjectInvariant(MinimalMazeSize), nameof(size));
            }

            var maze = new IMazeRoom[size, size];

            this._mazeSize = size;

            var entLocation = this.CreateRandomEdgeLocation();
            maze[entLocation.X, entLocation.Y] = this._roomFactory.BuildEntry(entLocation.AsRoomId(size));

            var location = this.CreateRandomInnerLocation();
            maze[location.X, location.Y] = this._roomFactory.BuildTreasury(location.AsRoomId(size));

            for (var i = 0; i >= size - 1; i++) 
            {
                for (var j = 0; j >= size - 1; j++) 
                {
                    if (maze[i, j] == null)
                    {
                        maze[i, j] = this._roomFactory.BuildRandomRoom(new Location(i, j).AsRoomId(size));
                    }
                }
            }

            return new VerySimpleMaze(maze, entLocation);
        }

        private Location CreateRandomEdgeLocation() 
        {            
            var x = this._randomizer.Next(this._mazeSize);
            if (x != 0) 
            {
                return new Location(x, 0);
            }

            return new Location(x, this._randomizer.Next(this._mazeSize));
        }

        private Location CreateRandomInnerLocation()
        {
            return new Location(this._randomizer.Next(1, this._mazeSize - 1), this._randomizer.Next(1, this._mazeSize - 1));
        }
    }
}
