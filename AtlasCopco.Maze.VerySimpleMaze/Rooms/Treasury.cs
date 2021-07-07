namespace AtlasCopco.Maze.VerySimpleMaze.Rooms
{
    using AtlasCopco.Maze.Core;

    public class Treasury : MazeRoom
    {
        private const string Description = 
            "You are rich! You literally struck gold as the first thing that happens when you open the door is " +
            "that you accidentally kick a golden chalice. But that treasure is just the beginning. Mountains of " +
            "gold and jewels of various colours tower in front of you. The air is old but the smell of riches is " + 
            "plentiful and your exhausted body once again feel agile as happiness flow through it.";

        private const string Action = "Your adventure ends here happily. After finding your way back, you will live a good and wealthy life.";

        public Treasury(int roomId) : base(roomId, Description, false, true, Action)
        {
        }
    }
}
