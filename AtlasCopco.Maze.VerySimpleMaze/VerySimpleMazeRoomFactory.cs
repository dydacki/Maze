namespace AtlasCopco.Maze.VerySimpleMaze
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using AtlasCopco.Maze.Core;
    using AtlasCopco.Maze.VerySimpleMaze.Rooms;
    using AtlasCopco.Maze.VerySimpleMaze.Rooms.Traps;

    public class VerySimpleMazeRoomFactory
    {
        private IMazeRoomTrapFactory _trapFactory;
        private IEnumerable<Type> _roomTypes;
        private Random _randomizer;

        public VerySimpleMazeRoomFactory() : this(new VerySimpleRoomTrapFactory(), new Random())
        {
        }

        public VerySimpleMazeRoomFactory(IMazeRoomTrapFactory trapFactory, Random randomizer)
        {
            this._trapFactory = trapFactory;
            this._randomizer = randomizer;
            this.InitializeRoomTypes();
        }

        public IMazeRoom BuildEntrance(int roomId)
        {
            return this.CreateMazeRoomOfType(typeof(Entrance), roomId);
        }

        public IMazeRoom BuildTreasury(int roomId)
        {
            return this.CreateMazeRoomOfType(typeof(Treasury), roomId);
        }

        public IMazeRoom BuildRandomRoom(int roomId)
        {
            return this.CreateMazeRoomOfType(this.GetRandomRoomType(), roomId);
        }

        private Type GetRandomRoomType()
        {
            return this._roomTypes.ElementAt(this._randomizer.Next(this._roomTypes.Count()));
        }

        private IMazeRoom CreateMazeRoomOfType(Type type, int roomId)
        {
            if (type.IsSubclassOf(typeof(MazeTrapRoom)))
            {
                return Activator.CreateInstance(type, roomId, this._trapFactory.CreateTrapFor(type)) as IMazeRoom;
            }

            return Activator.CreateInstance(type, roomId) as IMazeRoom;
        }

        private void InitializeRoomTypes() 
        {
            this._roomTypes = Assembly.GetExecutingAssembly()
                                      .GetTypes()
                                      .Where(t => t.Namespace == "AtlasCopco.Maze.VerySimpleMaze.Rooms"
                                             && t.IsClass
                                             && !new[] { typeof(Entrance), typeof(Treasury) }.Contains(t))
                                      .OrderBy(t => t.Name);
        }
    }
}
