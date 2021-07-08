namespace AtlasCopco.Maze.VerySimpleMaze.Test
{
    using AtlasCopco.Integration.Maze;
    using AtlasCopco.Maze.VerySimpleMaze;
    using AtlasCopco.Maze.VerySimpleMaze.Rooms.Traps;
    using AtlasCopco.Maze.VerySimpleMaze.Test.Utils;
    using NUnit.Framework;

    [TestFixture]
    public class VerySimpleMazeFacadeFixture
    {
        [Test]
        public void ShouldFindPathToTreasury()
        {
            var directions = new char[5] { 'E', 'N', 'E', 'N', 'E' };
            var facade = this.CreateFacade(new SafeTrapFactory());
            facade.BuildMaze(5);

            var currentRoomId = facade.GetEntranceRoom();
            int? nextRoomId;
            var step = 0;
            do
            {
                nextRoomId = facade.GetRoom(currentRoomId, directions[step]);
                currentRoomId = nextRoomId.Value;
                step++;
            } while (step < directions.Length && !facade.CausesInjury(currentRoomId) && !facade.HasTreasure(currentRoomId));

            // It is safe to assume nextRoomId is not null,
            // since we mock entrance to be (0, 0) and move 
            // forward "stair-wise" to mocked treasury in (2, 2)
            Assert.True(facade.HasTreasure(nextRoomId.Value));
        }

        [Test]
        public void ShouldFallIntoTrapWhenSteppingIntoTrapRoom() 
        {
            var facade = this.CreateFacade(new DeadlyTrapFactory());
            facade.BuildMaze(5);
            var entranceId = facade.GetEntranceRoom();
            var nextRoomId = facade.GetRoom(entranceId, 'E');
            
            // It is safe to assume nextRoomId is not null,
            // since we mock entrance to be (0, 0).
            Assert.True(facade.CausesInjury(nextRoomId.Value));
        }

        private IMazeIntegration CreateFacade(IMazeRoomTrapFactory trapFactory) 
        {
            var roomFactory = new VerySimpleMazeRoomFactory(
                trapFactory, SequentialRandomFactory.BuildSequentialRandomizer(4));

            var mazeFactory = new VerySimpleMazeFactory(roomFactory, new FakeLocationGenerator());
            return new VerySimpleMazeFacade(mazeFactory);
        }
    }
}
