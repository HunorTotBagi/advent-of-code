using Day01.Src;

namespace Day01.Test;

public class Tests
{
    private readonly string _testData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day01.Src/Data/testData.txt";
    private readonly string _realData = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day01.Src/Data/realData.txt";

    private readonly CodeSolution _newCodeSolution = CreateCodeSolution();

    [Fact]
    public void Test1()
    {
        // Arrange

        // Act

        // Assert
    }

    private static CodeSolution CreateCodeSolution()
    {
        return new CodeSolution();
    }
}
