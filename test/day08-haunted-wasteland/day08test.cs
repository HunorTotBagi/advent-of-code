using FluentAssertions;
using src.day08_haunted_wasteland;
using Xunit;

namespace test.day08_haunted_wasteland
{
    public class day08test
    {
        Network newNetwork = CreateNetwork();

        [Theory]
        [InlineData("C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\code\\day08\\data\\example1.txt", "RL")]
        [InlineData("C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\code\\day08\\data\\example2.txt", "LLR")]
        [InlineData("C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\code\\day08\\data\\realNetwork.txt", "LRRLRRRLLRRRLRRRLLRRLRRRLRRLRRLRLRLRLRLRLLRRRLRRLRLRRRLRRRLRLRRRLRLRRLRRRLRRRLRLLRRRLRLLLRLRRRLRLRRLRRLLLLRRLRRLRLRLRRLRLRRLRRRLRRRLRLRLRRLLLLRRLRLRRLLRRRLRLRLRLRRRLRLLLRLRLRRRLRLRRRLRRRLRRRLLRRLRRRLRRRLRRRLRRRLRLLRRRLRLRRRLRLRLRRRLRRLRRLLRRRLRRRLRRRLRLRLRLRRLRRRLRRLRLRLRLRRRR")]
        public void Should_return_directions(string filePath, string expected)
        {
            // Act
            var result = newNetwork.GetDirections(filePath);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\code\\day08\\data\\example1.txt")]
        public void Should_return_nodes(string filePath)
        {
            // Arrange
            List<List<string>> expected = new List<List<string>>
            {
                new List<string>{"AAA", "BBB", "CCC"},
                new List<string>{"BBB", "DDD", "EEE"},
                new List<string>{"CCC", "ZZZ", "GGG"},
                new List<string>{"DDD", "DDD", "DDD"},
                new List<string>{"EEE", "EEE", "EEE"},
                new List<string>{"GGG", "GGG", "GGG"},
                new List<string>{"ZZZ", "ZZZ", "ZZZ"},
            };

            // Act
            var result = newNetwork.GetNodes(filePath);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(0, "R", "CCC")]
        [InlineData(2, "L", "ZZZ")]
        public void Should_return_correct_way(int index, string input, string expected)
        {
            // Arrange
            string filePath = "C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\code\\day08\\data\\example1.txt";

            // Act
            string result = newNetwork.GetNextDestionation(index, input, filePath);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(0, "L", "BBB")]
        [InlineData(1, "L", "AAA")]
        [InlineData(0, "R", "BBB")]
        [InlineData(1, "R", "ZZZ")]
        public void Should_return_correct_way2(int index, string input, string expected)
        {
            // Arrange
            string filePath = "C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\code\\day08\\data\\example2.txt";

            // Act
            string result = newNetwork.GetNextDestionation(index, input, filePath);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\code\\day08\\data\\example1.txt", "AAA", "ZZZ")]
        [InlineData("C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\code\\day08\\data\\example2.txt", "AAA", "BBB")]
        [InlineData("C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\code\\day08\\data\\example2.txt", "BBB", "ZZZ")]
        public void Should_return_final_path(string filePath, string nextIteration, string expected)
        {
            // Act
            string result = newNetwork.GetFinalLocation(nextIteration, filePath);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\code\\day08\\data\\example1.txt", 2)]
        [InlineData("C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\code\\day08\\data\\example2.txt", 6)]
        [InlineData("C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\code\\day08\\data\\realNetwork.txt", 16897)]
        public void Should_return_final_number_of_steps(string filePath, int expected)
        {
            // Act
            int result = newNetwork.GetNumberOfSteps(filePath);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(10, 15, 5)]
        [InlineData(48, 36, 12)]
        [InlineData(356, 242, 2)]
        public void Should_return_gcd(ulong firstNumber, ulong secondNumber, ulong expected)
        {
            ulong result = newNetwork.GetGCD(firstNumber, secondNumber);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(10, 15, 30)]
        [InlineData(4, 5, 20)]
        [InlineData(18, 24, 72)]
        public void Should_return_lcm(ulong firstNumber, ulong secondNumber, ulong expected)
        {
            ulong result = newNetwork.GetLCM(firstNumber, secondNumber);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\code\\day08\\data\\realNetwork.txt")]
        public void Should_return_all_nodes_that_ends_with_A(string filePath)
        {
            // Arrange
            List<string> expected = new List<string>
            {
                "MCA",
                "AAA",
                "DCA",
                "LGA",
                "NLA",
                "VPA"
            };


            // Act
            List<string> result = newNetwork.GetNodesThatEndOnA(filePath);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData("C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\code\\day08\\data\\realNetwork.txt")]
        public void Should_return_result_for_all_nodes_that_end_with_A(string filePath)
        {
            // Arrange
            List<int> expected = new List<int>
            {
                16343,16897,20221,18559,11911,21883
            };


            // Act
            List<int> result = newNetwork.GetIndividualNumbers(filePath);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData("C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\code\\day08\\data\\realNetwork.txt")]
        public void Should_for_puzzle2_lcm(string filePath)
        {
            // Act
            ulong result = newNetwork.GetLCMFinalAnswer(filePath);

            // Assert
            result.Should().Be(16563603485021);
        }

        private static Network CreateNetwork()
        {
            return new Network();
        }
    }
}
