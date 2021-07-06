namespace AtlasCopco.Maze.Core
{
    public interface IMazeRoomTrap
    {
        string BehaviorDescription { get; }

        bool Fire();
    }
}
