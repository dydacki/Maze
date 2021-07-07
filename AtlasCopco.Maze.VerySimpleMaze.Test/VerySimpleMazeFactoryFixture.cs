namespace AtlasCopco.Maze.VerySimpleMaze.Test
{
    using System;

    using AtlasCopco.Maze.VerySimpleMaze;
    using NUnit.Framework;

    [TestFixture]
    public class VerySimpleMazeFactoryFixture
    {
        [Test]
        public void ShouldBuildSquareBasedMazeWithEntranceOnTheEdge() 
        {
            var mazeSize = new Random().Next(4, 8);
            var verySimpleMaze = new VerySimpleMazeFactory().BuildMaze(mazeSize);

            Assert.That(verySimpleMaze.Length, Is.EqualTo(mazeSize));
            Assert.That(verySimpleMaze.Width, Is.EqualTo(mazeSize));

            var entLocation = verySimpleMaze.EntranceLocation;
            Assert.True(entLocation.X == 0 || entLocation.Y == 0);
        }

        [Test]
        public void ShouldThrowExceptionWhenAttemptedToConstructTooSmallMaze() 
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new VerySimpleMazeFactory().BuildMaze(2));
        }
    }
}
