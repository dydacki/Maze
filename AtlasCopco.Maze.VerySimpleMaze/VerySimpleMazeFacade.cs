namespace AtlasCopco.Maze.VerySimpleMaze
{
    using System;

    using AtlasCopco.Integration.Maze;
    using AtlasCopco.Maze.Core;
    using AtlasCopco.Maze.VerySimpleMaze.Helpers;

    public class VerySimpleMazeFacade : IMazeIntegration
    {
        private IMaze _maze;
        private IMazeFactory _mazeFactory;

        public VerySimpleMazeFacade() : this(new VerySimpleMazeFactory())
        {
        }

        public VerySimpleMazeFacade(IMazeFactory mazeFactory) 
        {
            this._mazeFactory = mazeFactory;
        }

        public void BuildMaze(int size)
        {
            this._maze = this._mazeFactory.BuildMaze(size);
        }

        public bool CausesInjury(int roomId)
        {
            this.EnsureMazeInitialized();
            var room = this.EnsureValidRoom(roomId);
            return room is MazeTrapRoom;
        }

        public string GetDescription(int roomId)
        {
            this.EnsureMazeInitialized();
            var room = this.EnsureValidRoom(roomId);
            return room.GetDescription();
        }

        public int GetEntranceRoom()
        {
            EnsureMazeInitialized();
            return this._maze.EntranceLocation.AsRoomId(this._maze.Length);
        }

        public int? GetRoom(int roomId, char direction)
        {
            var roomLocation = roomId.AsLocation(this._maze.Length);
            return this._maze.GetAdjacentRoom(roomLocation, direction)?.RoomId;
        }

        public bool HasTreasure(int roomId)
        {
            EnsureMazeInitialized();
            var room = this.EnsureValidRoom(roomId);
            return room.HasTreasure;
        }

        private void EnsureMazeInitialized() 
        {            
            if (this._maze == null)
            {
                throw new ArgumentNullException("Maze not initialized. Please call the BuildMaze() method first.");
            }
        }

        private IMazeRoom GetRoom(int roomId)
        {
            var roomLocation = roomId.AsLocation(this._maze.Length);
            return this._maze.GetRoom(roomLocation);
        }

        private IMazeRoom EnsureValidRoom(int roomId) 
        {
            var room = this.GetRoom(roomId);
            if (room == null)
            {
                throw new ArgumentOutOfRangeException("Unknown room identifier.");
            }

            return room;
        }
    }
}
