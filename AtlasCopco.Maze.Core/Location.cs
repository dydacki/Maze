namespace AtlasCopco.Maze.Core
{
    /// <summary>
    /// Encapsulates coordinates of the <see cref="IMazeRoom"/> in the <see cref="IMaze"/>.
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class.
        /// </summary>
        /// <param name="x">
        /// A horizontal coordinate of the <see cref="IMazeRoom"/>.
        /// </param>
        /// <param name="y">
        /// A vertical coordinate of the <see cref="IMazeRoom"/>.
        /// </param>
        public Location(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class.
        /// </summary>
        public Location()
        {   
        }

        /// <summary>
        /// A horizontal coordinate of the <see cref="IMazeRoom"/>.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// A vertical coordinate of the <see cref="IMazeRoom"/>.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Gets a new instance of the <see cref="Location"/> class 
        /// situated on the North from the current location.
        /// </summary>
        public Location North => new Location(this.X, this.Y + 1);

        /// <summary>
        /// Gets a new instance of the <see cref="Location"/> class 
        /// situated on the East from the current location.
        /// </summary>
        public Location East => new Location(this.X + 1, this.Y);

        /// <summary>
        /// Gets a new instance of the <see cref="Location"/> class 
        /// situated on the South from the current location.
        /// </summary>
        public Location South => new Location (this.X, this.Y - 1);

        /// <summary>
        /// Gets a new instance of the <see cref="Location"/> class 
        /// situated on the West from the current location.
        /// </summary>
        public Location West => new Location(this.X - 1, this.Y);
    }
}
