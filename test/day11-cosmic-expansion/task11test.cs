using FluentAssertions;
using src.day11;
using Xunit;

namespace test.day11
{
    public class task11test
    {
        Galaxy newGalaxy = CreateGalaxy();

        [Fact]
        public void Should_Get_coordinates()
        {
            // Arrange
            List<List<ulong>> expected = new List<List<ulong>>
            {
                new List<ulong> { 0, 3}, new List<ulong> { 1, 7},new List<ulong> { 2, 0},
                new List<ulong> { 4, 6}, new List<ulong> { 5, 1},new List<ulong> { 6, 9},
                new List<ulong> { 8, 7}, new List<ulong> { 9, 0},new List<ulong> { 9, 4},
            };

            // Act
            List<List<ulong>> result = newGalaxy.GetCoordinates();

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(7)]
        public void Should_return_bool_on_index_row(ulong row)
        {
            bool result = newGalaxy.EmptyRow(row);

            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(8)]
        public void Should_return_bool_on_index_col(ulong col)
        {
            bool result = newGalaxy.EmptyCol(col);

            result.Should().BeTrue();
        }

        [Fact]
        public void Should()
        {
            List<ulong> first = new List<ulong> { 0,3};
            List<ulong> second = new List<ulong> { 1, 7 };
            ulong expansion = 2;

            ulong result = newGalaxy.GetDistanceBetweenTwoPoints(first, second, expansion);

            result.Should().Be(6);
        }

        [Fact]
        public void Final()
        {
            ulong result = newGalaxy.GetFinal(2);

            result.Should().Be(374);
        }

        private static Galaxy CreateGalaxy()
        {
            return new Galaxy();
        }
    }
}