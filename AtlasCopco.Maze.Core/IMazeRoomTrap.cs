namespace AtlasCopco.Maze.Core
{
    /// <summary>
    /// Exposes simple characteristics of a room trap.
    /// </summary>
    public interface IMazeRoomTrap
    {
        string BehaviorDescription { get; }

        bool Fire();
    }
}
