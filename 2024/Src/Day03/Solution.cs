using System.Text.RegularExpressions;

namespace Src.Day03;

public class Solution
{
    public static List<string> ReadFile(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var result = new List<string>();
        var pattern = @"mul\(\d+,\d+\)";

        foreach (var line in lines)
        {
            var matches = Regex.Matches(line, pattern);
            foreach (Match match in matches)
            {
                result.Add(match.Value);
            }
        }

        return result;
    }

    public static (List<int> firstList, List<int> secondList) GetNumbers(List<string> input)
    {
        var pattern = @"mul\((\d+),(\d+)\)";

        var firstList = new List<int>();
        var secondList = new List<int>();

        foreach (var mul in input)
        {
            var match = Regex.Match(mul, pattern);
            firstList.Add(int.Parse(match.Groups[1].Value));
            secondList.Add(int.Parse(match.Groups[2].Value));
        }

        return (firstList, secondList);
    }

    public static int Calculate(List<int> firstList, List<int> secondList)
    {
        var result = 0;
        for (var i = 0; i < firstList.Count; i++)
        {
            result += firstList[i] * secondList[i];
        }

        return result;
    }

    public static List<string> ReadCorruptedFile(string filePath)
    {
        var lines = File.ReadAllLines(filePath);

        var pattern = @"mul\(\d+,\d+\)|do\(\)|don't\(\)";
        var result = new List<string>();

        foreach (var line in lines)
        {
            var matches = Regex.Matches(line, pattern);
            foreach (Match match in matches)
            {
                result.Add(match.Value);
            }
        }

        return result;
    }

    public static List<string> ScanList(List<string> input)
    {
        var tracker = true;
        var result = new List<string>();

        foreach (var element in input)
        {
            if (element.StartsWith("mul") && tracker)
                result.Add(element);

            if (element == "don't()")
                tracker = false;

            else if (element == "do()")
                tracker = true;
        }

        return result;
    }
}
