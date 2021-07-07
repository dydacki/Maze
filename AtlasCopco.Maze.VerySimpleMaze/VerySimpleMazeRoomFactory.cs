namespace AtlasCopco.Maze.VerySimpleMaze
{
    using System;
    using System.Linq;
    using System.Reflection;

    using AtlasCopco.Maze.Core;
    using AtlasCopco.Maze.VerySimpleMaze.Rooms;

    public class VerySimpleMazeRoomFactory
    {
        private IMazeRoomTrapFactory _trapFactory;

        public IMazeRoom BuildEntry(int roomId)
        {
            return this.CreateRandomMazeRoomOfType(typeof(Entry), roomId);
        }

        public IMazeRoom BuildTreasury(int roomId)
        {
            return this.CreateRandomMazeRoomOfType(typeof(Treasury), roomId);
        }

        public IMazeRoom BuildRandomRoom(int roomId)
        {
            return this.CreateRandomMazeRoomOfType(this.GetRandomRoomType(), roomId);
        }

        private Type GetRandomRoomType()
        {
            var roomTypeNames = Assembly.GetExecutingAssembly()
                                        .GetTypes()
                                        .Where(t => t.Namespace == "AtlasCopco.Maze.VerySimpleMaze.Rooms"
                                               && t.IsClass
                                               && !new[] { typeof(Entry), typeof(Treasury) }.Contains(t))
                                        .OrderBy(t => t.Name);

            return roomTypeNames.ElementAt(new Random().Next(roomTypeNames.Count()));
        }

        private IMazeRoom CreateRandomMazeRoomOfType(Type type, int roomId)
        {
            if (type == typeof(MazeTrapRoom))
            {
                return Activator.CreateInstance(type, roomId, this._trapFactory.CreateTrapFor(type)) as IMazeRoom;
            }

            return Activator.CreateInstance(type, roomId) as IMazeRoom;
        }
    }
}
