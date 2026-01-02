using System.Collections.Generic;

namespace Src.Day02;

public class SolutionP2
{
    public static long Solve(string filePath)
    {
        var input = ReadFile(filePath);
        long result = 0;

        foreach (var range in input)
        {
            var start = long.Parse(range.Split('-')[0]);
            var end = long.Parse(range.Split('-')[1]);

            for (var i = start; i <= end; i++)
                if (IsValidDigit(i))
                    result += i;
        }

        return result;
    }
    public static bool IsValidDigit(long number)
    {
        var numberAsString = number.ToString();
        var length = numberAsString.Length;

        for (var i=1; i < length; i++)
        {
            var currentDigit = numberAsString.Substring(0, i);

            var repetitions = length / i;
            var parts = new List<string>();

            if (length % i == 0)
            {
                parts = SplitIntoEqualParts(numberAsString, repetitions).ToList();

                if (parts.All(x => x == currentDigit))
                    return true;
            }
        }

        return false;
    }

    public static IEnumerable<string> SplitIntoEqualParts(string input, int parts)
    {
        int partLength = input.Length / parts;

        for (int i = 0; i < parts; i++)
        {
            yield return input.Substring(i * partLength, partLength);
        }
    }

    public static List<string> ReadFile(string filePath)
    {
        var line = File.ReadAllLines(filePath);

        var separated = line[0].Split(',');

        return separated.ToList();
    }
}
