using src.day08_haunted_wasteland;
using src.day09;
using Xunit;

namespace test.day9
{
    public class task09test
    {
        task09 dummy = Createtask09();

        [Theory]
        [InlineData("file.txt")]
        public void Should(string fileName)
        {
            // Arrange
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../aoc/day08-haunted-wasteland/data/" + fileName;

            // Act

            // Assert
        }

        private static task09 Createtask09()
        {
            return new task09();
        }
    }
}
