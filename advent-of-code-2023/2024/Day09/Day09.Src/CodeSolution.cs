
namespace Day09.Src;

public class CodeSolution
{
    public static List<ulong> ReadFile(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var grid1 = new List<ulong>();

        foreach (var line in lines)
        {
            foreach (var c in line)
            {
                if (char.IsDigit(c))
                {
                    grid1.Add(ulong.Parse(c.ToString()));
                }
            }
        }
        return grid1;
    }

    public static List<string> ConvertToDots(List<ulong> input)
    {
        var result = new List<string>();
        var counter = 0;

        for (var i = 0; i < input.Count; i++)
        {
            if (i % 2 == 0)
            {
                for (ulong j = 0; j < input[i]; j++)
                    result.Add(counter.ToString());
                counter++;
            }
            else
            {
                for (ulong j = 0; j < input[i]; j++)
                    result.Add(".");
            }
        }
        return result;
    }

    public static ulong CountTheDots(List<ulong> input)
    {
        var asd = ConvertToDots(input);
        ulong result = 0;
        foreach (var chara in asd)
        {
            if (chara == ".")
                result++;
        }
        return result;
    }

    public static List<string> SwapDots(List<ulong> input)
    {
        var myString = ConvertToDots(input);

        for (var j = myString.Count - 1; j > 0; j--)
        {
            if (myString[j] != ".")
            {
                for (var i = 0; i < j; i++)
                {
                    if (myString[i] == ".")
                    {
                        myString[i] = myString[j];
                        myString[j] = ".";
                        break;
                    }
                }
                
            }
        }

        return myString;
    }

    public static ulong CalculatePartOne(List<ulong> input)
    {
        ulong result = 0;
        var counter = 0;

        var myString = SwapDots(input);

        foreach (var character in myString)
        {
            if (character == ".")
            {
                break;
            }
            result += (ulong)(counter * int.Parse(character));
            counter++;
        }

        return result;
    }

    public static int CalculatePartTwo(int data)
    {
        return 5;
    }
}
