namespace Src.Day02;

public class SolutionP1
{
    public static int CalculateAll(string filePath)
    {
        var lines = File.ReadAllLines(filePath);

        var result = 0;
        foreach (var line in lines)
        {
            result += SqFeet(Splitter(line));
        }

        return result;
    }

    public static int CalcSquareFeet(int[] input)
    {
        var l = input[0];
        var w = input[1];
        var h = input[2];
        return 2 * l * w + 2 * w * h + 2 * h * l;
    }

    public static int[] Splitter(string s)
    {
        var result = new int[3];
        var numbers = s.Split('x');
        result[0] = int.Parse(numbers[0]);
        result[1] = int.Parse(numbers[1]);
        result[2] = int.Parse(numbers[2]);

        return result;
    }

    public static int GetTheSmallestSide(int[] input)
    {
        var side1 = input[0] * input[1];
        var side2 = input[0] * input[2];
        var side3 = input[1] * input[2];

        return Math.Min(Math.Min(side1, side2), side3);
    }

    public static int SqFeet(int[] input)
    {
        return CalcSquareFeet(input) + GetTheSmallestSide(input);
    }
}
