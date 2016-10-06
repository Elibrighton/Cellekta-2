using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ratings;

namespace Ratings_Tests
{
    [TestClass]
    public class RatingsTests
    {
        [TestMethod]
        public void IsChartedSong_SongNotCharted_Test()
        {
            // Arrange
            ICharts testCharts = new Charts();
            testCharts.GetCharts();
            var testArtist = "testArtist";
            var testTitle = "testTitle";

            // Act
            var testIsCharted = testCharts.IsChartedSong(testArtist, testTitle);

            // Assert
            Assert.IsFalse(testIsCharted);
        }

        [TestMethod]
        public void IsChartedSong_SongIsCharted_Test()
        {
            // Arrange
            ICharts testCharts = new Charts();
            testCharts.GetCharts();
            var testArtist = "The Chainsmokers Feat. Halsey";
            var testTitle = "Closer";

            // Act
            var testIsCharted = testCharts.IsChartedSong(testArtist, testTitle);

            // Assert
            Assert.IsTrue(testIsCharted);
        }
    }
}
