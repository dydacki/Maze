namespace AtlasCopco.Maze.VerySimpleMaze.Test.Helpers
{
    using System;

    using AtlasCopco.Maze.Core;
    using AtlasCopco.Maze.VerySimpleMaze.Helpers;
    using NUnit.Framework;

    [TestFixture]
    public class CoreMazeTypesExtensionsFixture
    {
        [Test]
        [TestCase(0, 0, 4, 0)]
        [TestCase(1, 1, 4, 5)]
        [TestCase(3, 3, 4, 15)]
        public void ShouldTransformLocationIntoRoomIdentifier(int x, int y, int mazeSize, int expectedroomId) 
        {
            Assert.That(new Location(x, y).AsRoomId(mazeSize), Is.EqualTo(expectedroomId));
        }

        [Test]
        public void ShouldThrowExceptionWhenLocationCoordinateExceedsMazeValue()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Location(4, 0).AsRoomId(4));
        }

        [Test]
        [TestCase(0, 4, 0, 0)]
        [TestCase(5, 4, 1, 1)]
        [TestCase(15, 4, 3, 3)]
        public void ShouldTransformRoomIdentifierIntoLocation(int roomId, int mazeSize, int expectedX, int expectedY)
        {
            var location = roomId.AsLocation(mazeSize);
            Assert.That(location.X, Is.EqualTo(expectedX));
            Assert.That(location.Y, Is.EqualTo(expectedY));
        }

        [Test]
        [TestCase(70, 5)]
        [TestCase(25, 5)]
        public void ShouldThrowExceptionWhenIdentifierExceedsMazeDimensions(int tooLargeIdentifier, int mazeSize)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => tooLargeIdentifier.AsLocation(mazeSize));
        }
    }
}
