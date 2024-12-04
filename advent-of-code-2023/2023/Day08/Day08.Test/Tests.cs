using Day08.Src;
using FluentAssertions;

namespace Day08.Test;

public class Tests
{
    Network newNetwork = CreateNetwork();

    [Theory]
    [InlineData("example1.txt", "RL")]
    [InlineData("example2.txt", "LLR")]
    public void Should_return_directions(string fileName, string expected)
    {
        // Arrange
        var filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day08.Src/" + fileName;

        // Act
        var result = newNetwork.GetDirections(filePath);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("example1.txt")]
    public void Should_return_nodes(string fileName)
    {
        // Arrange
        var filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day08.Src/" + fileName;

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
    [InlineData("example1.txt", 0, "R", "CCC")]
    [InlineData("example1.txt", 2, "L", "ZZZ")]
    public void Should_return_correct_way(string fileName, int index, string input, string expected)
    {
        // Arrange
        var filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day08.Src/" + fileName;

        // Act
        string result = newNetwork.GetNextDestionation(index, input, filePath);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("example2.txt", 0, "L", "BBB")]
    [InlineData("example2.txt", 1, "L", "AAA")]
    [InlineData("example2.txt", 0, "R", "BBB")]
    [InlineData("example2.txt", 1, "R", "ZZZ")]
    public void Should_return_correct_way2(string fileName, int index, string input, string expected)
    {
        // Arrange
        var filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day08.Src/" + fileName;

        // Act
        string result = newNetwork.GetNextDestionation(index, input, filePath);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("example1.txt", "AAA", "ZZZ")]
    [InlineData("example2.txt", "AAA", "BBB")]
    [InlineData("example2.txt", "BBB", "ZZZ")]
    public void Should_return_final_path(string fileName, string nextIteration, string expected)
    {
        // Arrange
        var filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day08.Src/" + fileName;

        // Act
        string result = newNetwork.GetFinalLocation(nextIteration, filePath);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("example1.txt", 2)]
    [InlineData("example2.txt", 6)]
    public void Should_return_final_number_of_steps(string fileName, int expected)
    {
        // Arrange
        var filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day08.Src/" + fileName;

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
        // Act
        ulong result = newNetwork.GetGCD(firstNumber, secondNumber);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(4, 5, 20)]
    [InlineData(10, 15, 30)]
    [InlineData(18, 24, 72)]

    public void Should_return_lcm(ulong firstNumber, ulong secondNumber, ulong expected)
    {
        // Act
        ulong result = newNetwork.GetLCM(firstNumber, secondNumber);

        // Assert
        result.Should().Be(expected);
    }

    private static Network CreateNetwork()
    {
        return new Network();
    }
}