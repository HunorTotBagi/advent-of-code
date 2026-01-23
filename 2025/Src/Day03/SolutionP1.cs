namespace Src.Day03;

public class SolutionP1
{
    public static int Solve(string filePath)
    {
        var items = ReadFile(filePath);
        var result = 0;

        foreach (var item in items)
            result += ExtractJoltage(item);

        return result;
    }

    public static int ExtractJoltage(string input)
    {
        var suffixMax = new char[input.Length];
        suffixMax[^1] = input[^1];

        for (var i = input.Length - 2; i >= 0; i--)
            suffixMax[i] = input[i] > suffixMax[i + 1] ? input[i] : suffixMax[i + 1];

        var best = 0;

        for (var i = 0; i < input.Length - 1; i++)
        {
            var tensChar = input[i];
            var onesChar = suffixMax[i + 1];

            var value = (tensChar - '0') * 10 + (onesChar - '0');

            if (value > best)
                best = value;
        }

        return best;
    }

    public static List<string> ReadFile(string filePath)
    {
        return File.ReadAllLines(filePath).ToList();
    }
}
