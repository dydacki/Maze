namespace AtlasCopco.Maze.VerySimpleMaze.Test.Helpers
{
    using System.Collections.Generic;
    using System.Linq;

    using AtlasCopco.Maze.Core;
    using AtlasCopco.Maze.VerySimpleMaze.Helpers;
    using NUnit.Framework;

    [TestFixture]
    public class LocationComparerFixture
    {
        [Test]
        public void GivenTwoSeparateLocationObjectsWithSameCoordinatesContainsMethodShouldReturnTrue() 
        {
            var locationList = new List<Location>();
            locationList.Add(new Location(2, 4));
            var sameCoordinatesLocation = new Location(2, 4);

            Assert.True(locationList.Contains(sameCoordinatesLocation, new LocationComparer()));
        }
    }
}
