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

        private VerySimpleMazeRoomFactory _roomFactory;
        private ILocationGenerator _generator;
        private IMazeRoom[,] _maze;
        private Location _entryLocation;

        /// <summary>
        /// Initializes a new instance of the <see cref="VerySimpleMazeFactory"/> class.
        /// </summary>
        public VerySimpleMazeFactory() : this(new VerySimpleMazeRoomFactory(), new VerySimpleLocationGenerator())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VerySimpleMazeFactory"/> class.
        /// </summary>
        /// <param name="roomFactory">
        /// An instance of the <see cref="VerySimpleMazeRoomFactory"/> class.
        /// </param>
        /// <param name="generator">
        /// An instance of a class implementing the <see cref="ILocationGenerator"/> interface.
        /// </param>
        public VerySimpleMazeFactory(VerySimpleMazeRoomFactory roomFactory, ILocationGenerator generator) 
        {
            this._roomFactory = roomFactory;
            this._generator = generator;
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

            this._maze = new IMazeRoom[size, size];

            this.BuildEntrance();
            this.BuildTreasury();
            this.BuildRooms();

            return new VerySimpleMaze(this._maze, this._entryLocation);
        }

        private void BuildEntrance() 
        {
            var entLoc = this._generator.GenerateEdgeLocation(this._maze.GetLength(0));
            this._maze[entLoc.X, entLoc.Y] = this._roomFactory.BuildEntrance(entLoc.AsRoomId(this._maze.GetLength(0)));
            this._entryLocation = entLoc;
        }

        private void BuildTreasury()
        {
            var loc = this._generator.GenerateInnerLocation(this._maze.GetLength(0));
            this._maze[loc.X, loc.Y] = this._roomFactory.BuildTreasury(loc.AsRoomId(this._maze.GetLength(0)));
        }

        private void BuildRooms()
        {
            var size = this._maze.GetLength(0);
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    if (this._maze[i, j] == null)
                    {
                        this._maze[i, j] = this._roomFactory.BuildRandomRoom(new Location(i, j).AsRoomId(size));
                    }
                }
            }
        }
    }
}
