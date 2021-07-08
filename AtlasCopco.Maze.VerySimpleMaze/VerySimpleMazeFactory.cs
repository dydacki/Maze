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

            var maze = new IMazeRoom[size, size];
            var entLocation = this._generator.GenerateEdgeLocation(size);
            maze[entLocation.X, entLocation.Y] = this._roomFactory.BuildEntrance(entLocation.AsRoomId(size));

            var location = this._generator.GenerateInnerLocation(size);
            maze[location.X, location.Y] = this._roomFactory.BuildTreasury(location.AsRoomId(size));

            for (var i = 0; i < size ; i++) 
            {
                for (var j = 0; j < size; j++) 
                {
                    if (maze[i, j] == null)
                    {
                        maze[i, j] = this._roomFactory.BuildRandomRoom(new Location(i, j).AsRoomId(size));
                    }
                }
            }

            return new VerySimpleMaze(maze, entLocation);
        }
    }
}
