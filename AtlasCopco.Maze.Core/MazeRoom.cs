namespace AtlasCopco.Maze.Core
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// Exposes basic features of a maze room the player can get in to.
    /// </summary>
    public abstract class MazeRoom : IMazeRoom
    {        
        protected string _description;

        /// <summary>
        /// Initializes a new instance of the <see cref="MazeRoom"/> class.
        /// </summary>
        /// <param name="roomId">A unique room identifier.</param>
        /// <param name="description">A room description.</param>
        /// <param name="isEntrance">A variable indicating whether or not a room is an entrance.</param>
        /// <param name="hasTreasure">A variable indicating whether or not a room has treasure.</param>
        /// <param name="defaultAction">Default action of a room.</param>
        public MazeRoom(int roomId, 
                        string description,
                        bool isEntrance = false, 
                        bool hasTreasure = false, 
                        string defaultAction = "Move to other rooms") 
        {
            this.RoomId = roomId;
            this._description = description;
            this.IsEntrance = isEntrance;
            this.HasTreasure = hasTreasure;

            this.Traps = new List<IMazeRoomTrap>();            
            this.Actions = new List<string>();
            this.Actions.Add(defaultAction);
        }

        /// <summary>
        /// Gets or sets the room identifier.
        /// </summary>
        public int RoomId { get; set; }

        /// <summary>
        /// Gets the room description.
        /// </summary>
        public virtual string GetDescription()
        {
            if (this.Actions.Any())
            {
                return string.Format(CultureInfo.InvariantCulture, $"{this.GetType().Name} - {this._description}\n{this.Actions.First()}");
            }

            return string.Format(CultureInfo.InvariantCulture, $"{this.GetType().Name} - {this._description}");
        }

        /// <summary>
        /// Gets or sets the value indicating if the room has an entrance to the maze.
        /// </summary>
        public bool IsEntrance { get; set; }

        /// <summary>
        /// Gets or sets the value indicating if the room has a treasure.
        /// </summary>
        public bool HasTreasure { get; set; }

        /// <summary>
        /// Gets the value indicating if the room causes an injury.
        /// </summary>
        public virtual bool CausesInjury => false;

        /// <summary>
        /// Gets or sets the traps of the room.
        /// </summary>
        public IList<IMazeRoomTrap> Traps { get; set; }

        /// <summary>
        /// Gets or sets the actions available in the room.
        /// </summary>
        public IList<string> Actions { get; set; }
    }
}
