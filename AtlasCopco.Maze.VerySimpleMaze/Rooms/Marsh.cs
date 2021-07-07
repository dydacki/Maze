namespace AtlasCopco.Maze.VerySimpleMaze.Rooms
{
    using AtlasCopco.Maze.Core;

    public class Marsh : MazeTrapRoom
    {
        private const string Description =
            "You find yourself kneehigh into mudded water and with every step you feel the sucking resistance " +
            "when your feet is struggling to get free. Around you, you see pale trees standing tall straight out " +
            "of the water and the moonlight is blocked out by the lush vegetation. Occasionally you spot a broken " +
            "branch floating between the treestems.";

        public Marsh(int roomId, IMazeRoomTrap roomTrap) : base(roomId, Description, roomTrap)
        {
        }
    }
}
