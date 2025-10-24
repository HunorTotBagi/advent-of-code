using FluentAssertions;
using Xunit;
using Src.Day05;

namespace Tests;

public class Day05Tests
{
    [Theory]
    [InlineData("aeiou", true)]
    [InlineData("xazegov", true)]
    [InlineData("aeiouaeiouaeiou", true)]
    [InlineData("wzkmt", false)]
    [InlineData("wzkamt", false)]
    [InlineData("owzkamt", false)]
    [InlineData("owzkamtiyyyyyyyyyyyy", true)]
    public void ContainsAtLeastThreeVowelTest(string input, bool expected)
    {
        // Act
        var result = SolutionP1.ContainsAtLeastThreeVowel(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("abcdde", true)]
    [InlineData("aabbccdd", true)]
    [InlineData("azabzbczcdzd", false)]
    public void ContainsAtLeastOneLetterThatAppearsTwiceTest(string input, bool expected)
    {
        // Act
        var result = SolutionP1.ContainsAtLeastOneLetterThatAppearsTwice(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("abrthgrthrdth", false)]
    [InlineData("asdegercdrgretg", false)]
    [InlineData("awbqwertyi", true)]
    public void DoesNotHaveDisallowedStringTest(string input, bool expected)
    {
        // Act
        var result = SolutionP1.DoesNotHaveDisallowedString(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("ugknbfddgicrmopn", true)]
    [InlineData("aaa", true)]
    [InlineData("jchzalrnumimnmhp", false)]
    [InlineData("haegwjzuvuyypxyu", false)]
    [InlineData("dvszwmarrgswjxmb", false)]
    public void IsNiceStringTest(string input, bool expected)
    {
        // Act
        var result = SolutionP1.IsNiceString(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("xyxy", true)]
    [InlineData("aabcdefgaa", true)]
    [InlineData("aaa", false)]
    public void Condition1Test(string input, bool expected)
    {
        // Act  
        var result = SolutionP2.Condition1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("xyx", true)]
    [InlineData("abcdefeghi", true)]
    [InlineData("aaa", true)]
    public void Condition2Test(string input, bool expected)
    {
        // Act  
        var result = SolutionP2.Condition2(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("qjhvhtzxzqqjkmpb", true)]
    [InlineData("xxyxx", true)]
    [InlineData("uurcxstgmygtbstg", false)]
    [InlineData("ieodomkazucvgmuy", false)]
    public void IsNiceString2Test(string input, bool expected)
    {
        // Act  
        var result = SolutionP2.IsNiceStringP2(input);

        // Assert
        result.Should().Be(expected);
    }
}
