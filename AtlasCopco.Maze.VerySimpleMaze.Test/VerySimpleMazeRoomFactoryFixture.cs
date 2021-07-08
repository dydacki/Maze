namespace AtlasCopco.Maze.VerySimpleMaze.Test
{
    using System.Collections.Generic;
    using System.Linq;

    using AtlasCopco.Maze.Core;
    using AtlasCopco.Maze.VerySimpleMaze;    
    using AtlasCopco.Maze.VerySimpleMaze.Rooms;
    using AtlasCopco.Maze.VerySimpleMaze.Rooms.Traps;
    using AtlasCopco.Maze.VerySimpleMaze.Test.Utils;
    using NUnit.Framework;

    [TestFixture]
    public class VerySimpleMazeRoomFactoryFixture
    {
        [Test]
        public void ShouldBuildMazeEntrance() 
        {
            var entrance = new VerySimpleMazeRoomFactory().BuildEntrance(14);
            Assert.That(entrance, Is.TypeOf<Entrance>());
            Assert.AreEqual(entrance.RoomId, 14);
            Assert.True(entrance.IsEntrance);
            Assert.False(entrance.HasTreasure);
            Assert.That(!entrance.Traps.Any());
        }

        [Test]
        public void ShouldBuildMazeTreasury()
        {
            var treasury = new VerySimpleMazeRoomFactory().BuildTreasury(10);
            Assert.That(treasury, Is.TypeOf<Treasury>());
            Assert.AreEqual(treasury.RoomId, 10);
            Assert.False(treasury.IsEntrance);
            Assert.True(treasury.HasTreasure);
            Assert.That(!treasury.Traps.Any());
        }

        [Test]
        public void ShouldBuildRegularRoomsInAlphabeticalSequence() 
        {
            var mazeRooms = new List<IMazeRoom>();
            var roomFactory = new VerySimpleMazeRoomFactory(new VerySimpleRoomTrapFactory(), SequentialRandomFactory.BuildSequentialRandomizer());
            for (var i = 0; i < 4; i++) 
            {
                mazeRooms.Add(roomFactory.BuildRandomRoom(i));
            }

            Assert.False(mazeRooms.Any(r => r.IsEntrance));
            Assert.False(mazeRooms.Any(r => r.HasTreasure));

            this.AssertDesert(mazeRooms.ElementAt(0));
            this.AssertForest(mazeRooms.ElementAt(1));
            this.AssertHills(mazeRooms.ElementAt(2));
            this.AssertMarsh(mazeRooms.ElementAt(3));
        }

        public void AssertDesert(IMazeRoom desert) 
        {
            Assert.That(desert, Is.TypeOf<Desert>());
            Assert.That(desert.Traps.First(), Is.TypeOf<DehydrationTrap>());
        }

        public void AssertForest(IMazeRoom forest) 
        {
            Assert.That(forest, Is.TypeOf<Forest>());
            Assert.False(forest.Traps.Any());
        }

        public void AssertHills(IMazeRoom hills) 
        {
            Assert.That(hills, Is.TypeOf<Hills>());
            Assert.False(hills.Traps.Any());
        }

        public void AssertMarsh(IMazeRoom marsh)
        {
            Assert.That(marsh, Is.TypeOf<Marsh>());
            Assert.That(marsh.Traps.First(), Is.TypeOf<SinkingTrap>());
        }
    }
}
