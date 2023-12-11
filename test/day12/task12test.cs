using FluentAssertions;
using src.day12;
using Xunit;

namespace test.day12
{
    public class ItemTest
    {
        string filePath = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day12\\data\\exampleData.txt";
        string filePath1 = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day12\\data\\exampleData1.txt";
        string filePath2 = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day12\\data\\exampleData2.txt";
        string realFilePath = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day12\\data\\realData.txt";

        Item newItem = CreateItem();

        [Fact]
        public void Should()
        {
            // Arrange

            // Act

            // Assert
        }


        private static Item CreateItem()
        {
            return new Item();
        }
    }
}
