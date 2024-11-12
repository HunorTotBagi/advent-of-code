namespace Day05.Src;

public class Alamac
{
    public List<ulong> GetAllSeeds(string filePath)
    {
        string seedsLine = File.ReadAllText(filePath).Split('\n').FirstOrDefault(line => line.Contains("seeds:"));
        return ExtractNumbers(seedsLine);
    }

    public List<ulong> ExtractNumbers(string input)
    {
        return input?.Split(' ')
                     .Where(word => ulong.TryParse(word, out _))
                     .Select(ulong.Parse)
                     .ToList() ?? new List<ulong>();
    }

    public List<string> ReadFileToList(string filePath)
    {
        List<string> linesList = new List<string>();

        try
        {
            string[] lines = File.ReadAllLines(filePath);
            linesList.AddRange(lines);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return linesList;
    }

    public List<List<ulong>> GetAllMappings(string filePath, string mappingName)
    {
        List<List<ulong>> result = new List<List<ulong>>();

        string[] lines = File.ReadAllLines(filePath);

        ulong mappingIndex = (ulong)Array.IndexOf(lines, mappingName);

        for (ulong i = mappingIndex + 1; i < (ulong)lines.Length && !string.IsNullOrWhiteSpace(lines[i]); i++)
        {
            List<ulong> mappingValues = lines[i].Split(' ').Select(ulong.Parse).ToList();
            result.Add(mappingValues);
        }

        return result;
    }

    public List<ulong> GenerateULongList(ulong start, ulong end)
    {
        List<ulong> resultList = new List<ulong>();

        for (ulong i = start; i <= end; i++)
        {
            resultList.Add(i);
        }

        return resultList;
    }

    public ulong GetSeedLoaction(ulong seedNumber, string filePath)
    {
        var soil = GetSoil(filePath, seedNumber, "seed-to-soil map:");
        var fertilizer = GetSoil(filePath, soil, "soil-to-fertilizer map:");
        var water = GetSoil(filePath, fertilizer, "fertilizer-to-water map:");
        var light = GetSoil(filePath, water, "water-to-light map:");
        var temperature = GetSoil(filePath, light, "light-to-temperature map:");
        var humidity = GetSoil(filePath, temperature, "temperature-to-humidity map:");

        return GetSoil(filePath, humidity, "humidity-to-location map:");
    }

    public ulong GetValueFromMapping(List<ulong> mapping, ulong index)
    {
        return mapping[(int)index];
    }

    public ulong GetLowestLocationNumber(string filePath)
    {
        List<ulong> allSeeds = GetAllSeeds(filePath);

        List<ulong> result = new List<ulong>();

        foreach (ulong seedNumber in allSeeds)
        {
            ulong res = GetSeedLoaction(seedNumber, filePath);
            result.Add(res);
        }

        return result.Min();
    }

    public ulong GetSoil(string filePath, ulong input, string mappingName)
    {
        List<List<ulong>> numbers = GetAllMappings(filePath, mappingName);

        for (int i = 0; i < numbers.Count; i++)
        {
            var a = numbers[i][0];
            var b = numbers[i][1];
            var c = numbers[i][2];
            if (b <= input && input < b + c)
            {
                return input - b + a;
            }
        }
        return input;
    }
}
