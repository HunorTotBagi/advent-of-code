namespace Src.Day02;

public class SolutionP2
{
    public static int CalculateAll(string filePath)
    {
        var lines = File.ReadAllLines(filePath);

        var result = 0;
        foreach (var line in lines)
        {
            var inputLine = Splitter(line);

            result += CalculateRibbon(inputLine) + CalculateRibbonBow(inputLine);
        }

        return result;
    }

    public static int CalculateRibbon(int[] input)
    {
        var l = input[0];
        var w = input[1];

        return l+l+w+w;
    }

    public static int CalculateRibbonBow(int[] input)
    {
        var l = input[0];
        var w = input[1];
        var h = input[2];

        return l * w * h;
    }

    public static int[] Splitter(string s)
    {
        var result = new int[3];
        var numbers = s.Split('x');
        result[0] = int.Parse(numbers[0]);
        result[1] = int.Parse(numbers[1]);
        result[2] = int.Parse(numbers[2]);

        Array.Sort(result);
        return result;
    }
}
