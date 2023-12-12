using FluentAssertions;
using src.day13;
using Xunit;

namespace test.day13
{
    public class task13test
    {
        string filePath = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day13\\data\\inputData.txt";
        string filePath0 = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day13\\data\\inputData1.txt";
        string filePath1 = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day13\\data\\inputData2.txt";
        string realFilePath = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day13\\data\\realData.txt";

        Hunor newHunor = CreateHunor();

        [Fact]
        public void Should()
        {
            // Arrange

            // Act

            // Assert
        }


        private static Hunor CreateHunor()
        {
            return new Hunor();
        }
    }
}