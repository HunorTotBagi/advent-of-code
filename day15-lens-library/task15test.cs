using advent_of_code_LATEST;
using FluentAssertions;
using Xunit;

namespace TestProject1
{
    public class task15tests
    {
        Hunor newHunor = CreateHunor();

        string testData = "C:\\Users\\htotbagi\\source\\repos\\advent-of-code-LATEST\\advent-of-code-LATEST\\data\\day15\\testData.txt";
        string realData = "C:\\Users\\htotbagi\\source\\repos\\advent-of-code-LATEST\\advent-of-code-LATEST\\data\\day15\\realData.txt";

        [Theory]
        [InlineData('H', 72)]
        [InlineData('A', 65)]
        [InlineData('S', 83)]

        public void Test0(char input, int expected)
        {
            // Arrange

            // Act
            int result = newHunor.ConvertToAscii(input);
            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("HASH", 52)]
        [InlineData("rn=1", 30)]
        [InlineData("cm-", 253)]
        [InlineData("qp=3", 97)]
        [InlineData("cm=2", 47)]
        [InlineData("qp-", 14)]
        [InlineData("pc=4", 180)]
        [InlineData("ot=9", 9)]
        [InlineData("ab=5", 197)]
        [InlineData("pc-", 48)]
        [InlineData("pc=6", 214)]
        [InlineData("ot=7", 231)]
        [InlineData("rn", 0)]
        [InlineData("qp", 1)]
        public void Test1(string input, int expected)
        {
            // Arrange

            // Act
            int result = newHunor.HASHAlgo(input);
            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Should_read()
        {
            List<string> expected = new List<string>();

            List<string> result = newHunor.ReadFile(testData);

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Shoudl_syn()
        {
            List<string> input = newHunor.ReadFile(testData);

            int result = newHunor.Final(input);

            result.Should().Be(1320);
        }

        [Fact]
        public void Shoudl_syn1111()
        {
            List<string> input = newHunor.ReadFile(realData);

            int result = newHunor.Final(input);

            result.Should().Be(512950);
        }

        [Theory]
        [InlineData("rn=1", 0)]
        [InlineData("cm-", 0)]
        [InlineData("qp=3", 1)]
        [InlineData("ot=7", 3)]
        public void Should_retur_label_ascyy(string input, int expected)
        {

            int result = newHunor.GetBoxIndex(input);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("rngwergw=1", true)]
        [InlineData("qpasd=3", true)]
        [InlineData("ottt=7", true)]
        [InlineData("cm-1", false)]
        public void Should_return_true_if_equal(string input, bool exp)
        {
            bool result = newHunor.HaveEqual(input);

            result.Should().Be(exp);
        }

        [Theory]
        [InlineData("rngwergw-1", true)]
        [InlineData("qpasd=3", false)]
        [InlineData("ottt-7", true)]
        public void Should_return_true_if_mins(string input, bool exp)
        {
            bool result = newHunor.HaveMinus(input);

            result.Should().Be(exp);
        }

        [Theory]
        [InlineData("rngwergw-1", 1)]
        [InlineData("qpasd=35", 35)]
        [InlineData("ottt-711", 711)]
        public void Should_return_number(string input, int exp)
        {
            int result = newHunor.ExtractNumber(input);

            result.Should().Be(exp);
        }

        [Fact]
        public void Main_logic()
        {
            List<string> input = newHunor.ReadFile(testData);
            List<List<string>> exp = new List<List<string>>();

            List<List<string>> res = newHunor.PutInBox(input);

            res.Should().BeEquivalentTo(exp);
        }

        [Fact]
        public void Final_answer()
        {
            List<string> input = newHunor.ReadFile(testData);
            
            int result = newHunor.FinalResult(input);

            result.Should().Be(145);  
        }

        [Fact]
        public void Final_answer_real()
        {
            List<string> input = newHunor.ReadFile(realData);

            int result = newHunor.FinalResult(input);

            result.Should().Be(247153);
        }


        private static Hunor CreateHunor()
        {
            return new Hunor();
        }
    }
}