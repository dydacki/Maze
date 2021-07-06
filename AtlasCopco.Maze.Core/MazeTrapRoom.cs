namespace AtlasCopco.Maze.Core
{
    using System.Linq;

    public abstract class MazeTrapRoom : MazeRoom
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MazeTrapRoom"/> class.
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="description"></param>
        /// <param name="trap"></param>
        public MazeTrapRoom(int roomId, string description, IMazeRoomTrap trap) : base(roomId, description) 
        {
            this.Traps.Add(trap);
        }

        public override string GetDescription() 
        {
            var trap = this.Traps.FirstOrDefault();
            if (trap != null && trap.Fire())
            {
                return string.Format($"{this.GetType().Name} - {this._description}\n{trap.BehaviorDescription}");
            }

            return base.GetDescription();
        }
    }
}
