namespace AtlasCopco.Maze.VerySimpleMaze
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AtlasCopco.Maze.Core;
    using AtlasCopco.Maze.VerySimpleMaze.Helpers;

    /// <summary>
    /// Builds and returns an instance of the <see cref="VerySimpleMaze"/> class.
    /// </summary>
    public class VerySimpleMazeFactory : IMazeFactory
    {
        private const int MinimalMazeSize = 3;

        private int _size;
        private ILocationGenerator _generator;
        private VerySimpleMazeRoomFactory _roomFactory;
        private IList<int> _usedIds;

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
            this._usedIds = new List<int>();
        }

        /// <summary>
        /// Builds an instance of the <see cref="VerySimpleMaze"/> class
        /// containing a maze entrance, a treasury and a collection
        /// of randomly generated maze rooms.
        /// </summary>
        /// <param name="size">
        /// A size of the edge of a maze to be generated
        /// </param>
        /// <returns>
        /// An instance of the <see cref="VerySimpleMaze"/> class.
        /// </returns>
        public IMaze BuildMaze(int size)
        {
            if (size < MinimalMazeSize)
            {
                throw new ArgumentOutOfRangeException(
                    "The stage edge cannot be smaller than {0} elements.".InjectInvariant(MinimalMazeSize), nameof(size));
            }

            this._size = size;
            var maze = new IMazeRoom[size, size]
                .AddRoom(this.BuildEntrance())
                .AddRoom(this.BuildTreasury())
                .AddRooms(this.BuildRooms());

            return new VerySimpleMaze(maze, this._usedIds[0].AsLocation(this._size));
        }

        private IMazeRoom BuildEntrance() 
        {
            var entLoc = this._generator.GenerateEdgeLocation(this._size).Tee(this.AddUsedId);
            return this._roomFactory.BuildEntrance(entLoc.AsRoomId(this._size));
        }

        private IMazeRoom BuildTreasury()
        {
            var loc = this._generator.GenerateInnerLocation(this._size).Tee(this.AddUsedId);
            return this._roomFactory.BuildTreasury(loc.AsRoomId(this._size));
        }

        private IEnumerable<IMazeRoom> BuildRooms()
        {
            for (var i = 0; i < this._size; i++)
            {
                for (var j = 0; j < this._size; j++)
                {
                    var roomId = new Location(i, j).AsRoomId(this._size);
                    if (!this._usedIds.Contains(roomId))
                    {
                        yield return this._roomFactory.BuildRandomRoom(roomId);
                    }
                }
            }
        }

        private void AddUsedId(Location location) 
        {
            this._usedIds.Add(location.AsRoomId(this._size));
        }
    }
}
