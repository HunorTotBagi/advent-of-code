using System.Text;

namespace Src.Day10;

public class SolutionP1
{
    public static int Calc(string input)
    {
        var i = 0;
        var result = input;
        while (i < 40)
        {
            result = Transform(result);
            i++;
        }

        return result.Length;
    }
    public static string Transform(string input)
    {
        var result = new StringBuilder(input.Length * 2);

        var counter = 0;
        var current = input[0];

        var j = 0;
        while (j < input.Length)
        {
            while (j < input.Length && input[j] == current)
            {
                counter++;
                j++;
            }

            result.Append(counter);
            result.Append(current);

            if (j < input.Length)
            {
                current = input[j];
                counter = 0;
            }
        }

        return result.ToString();
    }
}
