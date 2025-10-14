using Day11.Src;
using FluentAssertions;

namespace Day11.Test;

public class GalacticUniverseTests
{
    Solution newUniverse = CreateUniverse();

    [Fact]
    public void Should_get_galaxy_coordinates()
    {
        // Arrange
        List<List<ulong>> expected = new List<List<ulong>>
            {
                new List<ulong> { 0, 3}, new List<ulong> { 1, 7},new List<ulong> { 2, 0},
                new List<ulong> { 4, 6}, new List<ulong> { 5, 1},new List<ulong> { 6, 9},
                new List<ulong> { 8, 7}, new List<ulong> { 9, 0},new List<ulong> { 9, 4},
            };

        // Act
        List<List<ulong>> result = newUniverse.GetGalaxyCoordinates();

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData(3)]
    [InlineData(7)]
    public void IsRowEmpty_should_return_true(ulong row)
    {
        // Act
        bool result = newUniverse.IsRowEmpty(row);

        // Assert
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData(2)]
    [InlineData(5)]
    [InlineData(8)]
    public void IsColumnEmpty_should_return_true(ulong col)
    {
        // Act
        bool result = newUniverse.IsColumnEmpty(col);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Should_return_distance_between_galaxies()
    {
        // Arrange
        ulong orderOfExpansion = 2;
        List<ulong> first = new List<ulong> { 0, 3 };
        List<ulong> second = new List<ulong> { 1, 7 };

        // Act
        ulong result = newUniverse.CalculateDistanceBetweenGalaxies(first, second, orderOfExpansion);

        // Assert
        result.Should().Be(6);
    }

    [Theory]
    [InlineData(2, 374)]
    [InlineData(10, 1030)]
    [InlineData(100, 8410)]
    public void Should_return_total_distance(ulong orderOfExpansion, ulong expected)
    {
        // Act
        ulong result = newUniverse.CalculateTotalDistance(orderOfExpansion);

        // Assert
        result.Should().Be(expected);
    }

    private static Solution CreateUniverse()
    {
        return new Solution();
    }
}