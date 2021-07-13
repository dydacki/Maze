namespace AtlasCopco.Maze.VerySimpleMaze.Helpers
{
    using System;
    using System.Collections.Generic;

    using AtlasCopco.Maze.Core;

    /// <summary>
    /// Extension methods for Core Maze library types.
    /// </summary>
    public static class CoreMazeTypesExtensions
    {
        /// <summary>
        /// Transforms an instance of the <see cref="Location"/> class 
        /// into an identifier of the <see cref="IMazeRoom"/>.
        /// </summary>
        /// <param name="location">
        /// An instance of the <see cref="Location"/> class to be transformed.
        /// </param>
        /// <param name="mazeSize">
        /// The size of the <see cref="IMaze"/> needed to calculate the room identifier.
        /// </param>
        /// <returns>
        /// A sequential room identifier in the mother strucure of the <see cref="IMaze"/>.
        /// </returns>
        public static int AsRoomId(this Location location, int mazeSize) 
        {
            if (location.X >= mazeSize || location.Y >= mazeSize)
            {
                throw new ArgumentOutOfRangeException(
                    "Invalid location coordinate. Maximum value of {0} allowed.".InjectInvariant(mazeSize - 1));
            }

            return location.Y * mazeSize + location.X;
        }

        /// <summary>
        /// Transforms an identifier of the <see cref="IMazeRoom"/>
        /// into an instance of the <see cref="Location"/> class.
        /// </summary>
        /// <param name="roomId">
        /// An identifier to be transformed.
        /// </param>
        /// <param name="mazeSize">
        /// The size of the <see cref="IMaze"/> needed to calculate the room identifier.
        /// </param>
        /// <returns>
        /// An instance of the <see cref="Location"/> class.
        /// </returns>
        public static Location AsLocation(this int roomId, int mazeSize)
        {
            if (roomId >= Math.Pow(mazeSize, 2))
            {
                throw new ArgumentOutOfRangeException(
                    "Invalid location coordinate. Maximum value of {0} allowed.".InjectInvariant(Math.Pow(mazeSize, 2) - 1));
            }

            return new Location(roomId % mazeSize, roomId / mazeSize);
        }

        /// <summary>
        /// Adds an instance of the <see cref="IMazeRoom"/> 
        /// to the array of <see cref="IMazeRoom"/> objects 
        /// and returns this array.
        /// </summary>
        /// <param name="mazeRooms">
        /// The array of <see cref="IMazeRoom"/> objects 
        /// that the room is to be added to.
        /// </param>
        /// <param name="roomToAdd">
        /// An instance of the <see cref="IMazeRoom"/> to be added.
        /// </param>
        /// <returns>
        /// The array of <see cref="IMazeRoom"/> objects with a room added.
        /// </returns>
        public static IMazeRoom[,] AddRoom(this IMazeRoom[,] mazeRooms, IMazeRoom roomToAdd) 
        {
            var location = roomToAdd.RoomId.AsLocation(mazeRooms.GetLength(0));
            mazeRooms[location.X, location.Y] = roomToAdd;
            return mazeRooms;
        }

        /// <summary>
        /// Adds a collection of the <see cref="IMazeRoom"/> objects
        /// to the array of <see cref="IMazeRoom"/> objects.
        /// and returns this array.
        /// </summary>
        /// <param name="mazeRooms">
        /// The array of <see cref="IMazeRoom"/> objects 
        /// that the collection of <see cref="IMazeRoom"/> objects 
        /// is to be added to.
        /// </param>
        /// <param name="roomsToAdd">
        /// A collection of the <see cref="IMazeRoom"/> objects to be added.
        /// </param>
        /// <returns>
        /// The array of <see cref="IMazeRoom"/> objects with 
        /// a collection of rooms added.
        /// </returns>
        public static IMazeRoom[,] AddRooms(this IMazeRoom[,] mazeRooms, IEnumerable<IMazeRoom> roomsToAdd)
        {
            foreach (var room in roomsToAdd)
            {
                var location = room.RoomId.AsLocation(mazeRooms.GetLength(0));
                mazeRooms[location.X, location.Y] = room;
            }

            return mazeRooms;
        }
    }
}
