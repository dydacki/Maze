namespace AtlasCopco.Maze.Core
{
    using System.Linq;

    public abstract class MazeTrapRoom : MazeRoom
    {
        private bool _trapFired;

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

        /// <summary>
        /// Gets the value indicating if the room causes an injury.
        /// </summary>
        public override bool CausesInjury
        {
            get
            {
                if (this.Traps.Any())
                {
                    this._trapFired = this.Traps.First().Fire();
                    return this._trapFired;
                }

                return false;
            }
        }

        /// <summary>
        /// Gets the room description.
        /// </summary>
        public override string GetDescription() 
        {            
            if (this._trapFired)
            {
                var trapDescription = this.Traps.First().BehaviorDescription;
                return string.Format($"{this.GetType().Name} - {this._description}\n{trapDescription}");
            }

            return base.GetDescription();
        }
    }
}
