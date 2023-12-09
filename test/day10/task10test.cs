using src.day10;
using Xunit;

namespace test.day10
{
    public class task10test
    {
        task10 newTask10 = CreateTask10();

        string filePath = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day10\\data\\exampleData.txt";
        string realFilePath = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day10\\data\\realData.txt";

        [Fact]
        public void First()
        {
            // Arrange

            // Act

            // Assert
        }

        private static task10 CreateTask10()
        {
            return new task10();
        }
    }
}
