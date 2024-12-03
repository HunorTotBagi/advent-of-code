using System.Text.RegularExpressions;

namespace Day03.Src;

public class CodeSolution
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

    public static (List<int> x, List<int> y) GetNumbers(List<string> input)
    {
        var pattern = @"mul\((\d+),(\d+)\)";

        var array1 = new List<int>();
        var array2 = new List<int>();

        foreach (var mul in input)
        {
            var match = Regex.Match(mul, pattern);
            array1.Add(int.Parse(match.Groups[1].Value));
            array2.Add(int.Parse(match.Groups[2].Value));
        }

        return (array1, array2);
    }

    public static int Calculate(List<int> first, List<int> second)
    {
        var result = 0;
        for (var i = 0; i < first.Count; i++)
        {
            result += first[i] * second[i];
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
