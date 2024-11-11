using Day05.Src;
using FluentAssertions;

namespace Day05.Test;

public class AlamacTests
{
    public string filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day05.Src/Data/exampleAlamac.txt";
    Alamac newAlamac = CreateAlamac();

    [Theory]
    [InlineData("exampleAlamac.txt", new ulong[] { 79, 14, 55, 13 })]
    [InlineData("realAlamac.txt", new ulong[] { 1514493331, 295250933, 3793791524, 105394212, 828589016,
                                                    654882197 , 658370118 , 49359719 , 4055197159, 59237418,
                                                    314462259 , 268880047 , 2249227634 , 74967914 , 2370414906 ,
                                                    38444198 , 3291001718 ,  85800943 , 2102534948 , 5923540})]
    public void Should_return_all_seeds(string fileName, IEnumerable<ulong> expected)
    {
        // Arrange
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../Day05.Src/Data/", fileName);

        // Act
        List<ulong> result = newAlamac.GetAllSeeds(filePath);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return new object[] { "seed-to-soil map:", new List<List<ulong>> { new List<ulong> { 50, 98, 2 }, new List<ulong> { 52, 50, 48 } } };
        yield return new object[] { "soil-to-fertilizer map:", new List<List<ulong>> { new List<ulong> { 0, 15, 37 }, new List<ulong> { 37, 52, 2 }, new List<ulong> { 39, 0, 15 } } };
        yield return new object[] { "humidity-to-location map:", new List<List<ulong>> { new List<ulong> { 60, 56, 37 }, new List<ulong> { 56, 93, 4 } } };
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Should_return_list_of_all_mappings_based_on_mapping_name(string mappingName, List<List<ulong>> expectedMappings)
    {
        // Act
        List<List<ulong>> result = newAlamac.GetAllMappings(filePath, mappingName);

        // Assert
        result.Should().BeEquivalentTo(expectedMappings);
    }

    [Theory]
    [InlineData(79, 81, "seed-to-soil map:")]
    [InlineData(81, 81, "soil-to-fertilizer map:")]
    [InlineData(81, 81, "fertilizer-to-water map:")]
    [InlineData(81, 74, "water-to-light map:")]
    [InlineData(74, 78, "light-to-temperature map:")]
    [InlineData(78, 78, "temperature-to-humidity map:")]
    [InlineData(78, 82, "humidity-to-location map:")]


    public void Should_return_first_pass(ulong input, ulong expected, string mappingName)
    {
        // Act
        ulong result = newAlamac.GetSoil(filePath, input, mappingName);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(79, 82)]
    [InlineData(14, 43)]
    [InlineData(55, 86)]
    [InlineData(13, 35)]
    public void Should_return_location_for_seeds(ulong seedNumber, ulong expected)
    {
        // Act
        ulong result = newAlamac.GetSeedLoaction(seedNumber, filePath);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("exampleAlamac.txt", 35)]
    [InlineData("realAlamac.txt", 579439039)]
    public void Should_return_lowest_location_number(string fileName, ulong expected)
    {
        // Arrange
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../../Day05.Src/Data/", fileName);

        // Act
        ulong result = newAlamac.GetLowestLocationNumber(filePath);

        // Assert
        result.Should().Be(expected);
    }

    private static Alamac CreateAlamac()
    {
        return new Alamac();
    }
}