﻿using src.day11;
using Xunit;

namespace test.day11
{
    public class task11test
    {
        string filePath0 = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day11\\data\\exampleData0.txt";
        string filePath1 = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day11\\data\\exampleData1.txt";
        string filePath2 = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day11\\data\\exampleData2.txt";
        string realFilePath = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day11\\data\\realData.txt";

        [Theory]
        [InlineData("asd")]
        public void Should1(string fileName)
        {
            // Arrange
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../aoc/day11/data/" + fileName;

            // Act

            // Assert
        }

        [Fact]
        public void Should()
        {
            // Arrange

            // Act

            // Assert
        }

        private static Hunor Create()
        {
            return new Hunor();
        }
    }
}