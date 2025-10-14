using System.Text.RegularExpressions;

namespace Day02.Src;

public class Solution
{
    public int GetGameId(string input)
    {
        Match match = Regex.Match(input, @"\d+");

        if (match.Success)
        {
            if (int.TryParse(match.Value, out int result))
            {
                return result;
            }
        }
        return -1;
    }

    public string GetCubesString(string input)
    {
        return input.Substring(8);
    }

    public string GetCubesWithoutEmptySpaces(string input)
    {
        string cubeString = GetCubesString(input);
        return cubeString.Replace(" ", string.Empty);
    }

    public List<string> GetCubesStringSegments(string input)
    {
        List<string> result = new List<string>();

        string cubesWithoutEmptySapces = GetCubesWithoutEmptySpaces(input);

        string[] segmentArray = cubesWithoutEmptySapces.Split(';');

        for (int i = 0; i < segmentArray.Length; i++)
        {
            result.Add(segmentArray[i].Trim());
        }
        return result;
    }

    public string GetSegmentByIndex(string input, int index)
    {
        List<string> cubesStringSegments = GetCubesStringSegments(input);
        return cubesStringSegments[index];
    }

    public Dictionary<string, int> CreateDictionaryOutOfSegment(string input, int segmentIndex)
    {
        Dictionary<string, int> resultDictionary = new Dictionary<string, int>()
            {
                {"red", 0 },
                {"green", 0 },
                {"blue", 0 }
            };

        string firstSegment = GetSegmentByIndex(input, segmentIndex);

        string[] parts = firstSegment.Split(',');

        foreach (string part in parts)
        {
            string color = "";
            int value = 0;

            for (int i = 0; i < part.Length; i++)
            {
                if (char.IsDigit(part[i]))
                {
                    value = value * 10 + int.Parse(part[i].ToString());
                }
                else
                {
                    color += part[i];
                }
            }

            if (color == "red")
            {
                resultDictionary["red"] = value;
            }
            else if (color == "green")
            {
                resultDictionary["green"] = value;
            }
            else if (color == "blue")
            {
                resultDictionary["blue"] = value;
            }
        }

        return resultDictionary;
    }

    public bool IsGameSegmentPossible(string input, int index, Dictionary<string, int> availableCubes)
    {
        Dictionary<string, int> createdDictionary = CreateDictionaryOutOfSegment(input, index);

        string[] colorsToCheck = { "red", "green", "blue" };

        foreach (string color in colorsToCheck)
        {
            if (createdDictionary.TryGetValue(color, out int createdDictionaryValue) && availableCubes.TryGetValue(color, out int loadedBagValue))
            {
                if (createdDictionaryValue > loadedBagValue)
                    return false;
            }
        }
        return true;
    }

    public int IsGamePossible(string input, Dictionary<string, int> availableCubes)
    {
        List<string> cubesStringSegments = GetCubesStringSegments(input);

        for (int i = 0; i < cubesStringSegments.Count; i++)
        {
            if (!IsGameSegmentPossible(input, i, availableCubes))
            {
                return 0;
            }
        }
        return GetGameId(input);
    }

    public List<int> GetMaximumValuePerColor(string input)
    {
        List<int> result = new List<int>();

        int red = 0;
        int green = 0;
        int blue = 0;

        List<string> stringSegments = GetCubesStringSegments(input);

        for (int i = 0; i < stringSegments.Count; i++)
        {
            Dictionary<string, int> storage = CreateDictionaryOutOfSegment(input, i);

            if (storage["red"] > red)
            {
                red = storage["red"];
            }
            if (storage["green"] > green)
            {
                green = storage["green"];
            }
            if (storage["blue"] > blue)
            {
                blue = storage["blue"];
            }
        }

        result.Add(red);
        result.Add(green);
        result.Add(blue);

        return result;
    }

    public int CalculatePowerOfCubes(string input)
    {
        List<int> maxColorValues = GetMaximumValuePerColor(input);
        int result = 1;

        for (int i = 0; i < maxColorValues.Count; i++)
        {
            result *= maxColorValues[i];
        }
        return result;
    }

    public int CalculateSumOfCubePowers(string filePath)
    {
        List<string> gameLines = ReadFileToList(filePath);

        int result = 0;

        foreach (string lines in gameLines)
        {
            result += CalculatePowerOfCubes(lines);
        }
        return result;
    }

    public List<string> ReadFileToList(string filePath)
    {
        List<string> linesList = new List<string>();

        string[] lines = File.ReadAllLines(filePath);
        linesList.AddRange(lines);

        return linesList;
    }
}
