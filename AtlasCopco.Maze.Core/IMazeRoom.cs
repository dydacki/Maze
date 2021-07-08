namespace AtlasCopco.Maze.Core
{
    using System.Collections.Generic;

    /// <summary>
    /// Exposes basic features of a maze room the player can get in to.
    /// </summary>
    public interface IMazeRoom
    {
        /// <summary>
        /// Gets or sets the room identifier.
        /// </summary>
        int RoomId { get; set; }

        /// <summary>
        /// Gets the room description.
        /// </summary>
        string GetDescription();

        /// <summary>
        /// Gets or sets the value indicating if the room has an entrance to the maze.
        /// </summary>
        bool IsEntrance { get; set; }

        /// <summary>
        /// Gets or sets the value indicating if the room has a treasure.
        /// </summary>
        bool HasTreasure { get; set; }

        /// <summary>
        /// Gets the value indicating if the room causes an injury.
        /// </summary>
        bool CausesInjury { get; }

        /// <summary>
        /// Gets or sets the traps of the room.
        /// </summary>
        IList<IMazeRoomTrap> Traps { get; set; }

        /// <summary>
        /// Gets or sets the actions available in the room.
        /// </summary>
        IList<string> Actions { get; set; }
    }
}
