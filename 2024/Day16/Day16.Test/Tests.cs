using Day16.Src;
using FluentAssertions;

namespace Day16.Test
{
    public class Tests
    {
        [Theory]
        [InlineData("testData0.txt", 7036)]
        [InlineData("testData1.txt", 11048)]
        public void CalculateScore(string fileName, int expectedScore)
        {
            // Arrange
            var fullPath = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day16.Src/" + fileName;
            var data = Solution.ReadFile(fullPath);

            // Act
            var result = Solution.FindLowestScore(data);

            // Assert
            result.Should().Be(expectedScore);
        }

        [Theory]
        [InlineData("testData0.txt", 45)]
        [InlineData("testData1.txt", 64)]
        public void FindBestPathTiles(string fileName, int expectedScore)
        {
            // Arrange
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day16.Src/" + fileName;
            var data = Solution.ReadFile(filePath);

            // Act
            var result = Solution.FindBestPathTiles(data);

            // Assert
            result.Should().Be(expectedScore);
        }
    }
}
