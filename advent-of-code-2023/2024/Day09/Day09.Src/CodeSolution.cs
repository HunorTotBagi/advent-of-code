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

    public static (List<string> result, List<List<ulong>> numbers, List<List<ulong>> dots) ConvertToDotsWithData(List<ulong> input)
    {
        var result = new List<string>();
        var counter = 0;
        var mapNumbers = new List<List<ulong>>();
        var mapDots = new List<List<ulong>>();

        for (var i = 0; i < input.Count; i++)
        {
            if (i % 2 == 0)
            {
                mapNumbers.Add([(ulong)result.Count, (ulong)counter, input[i]]);

                for (ulong j = 0; j < input[i]; j++)
                    result.Add(counter.ToString());
                
                counter++;
            }
            else
            {
                if (input[i] != 0)
                    mapDots.Add([(ulong)result.Count, input[i]]);

                for (ulong j = 0; j < input[i]; j++)
                    result.Add(".");
            }
        }
        return (result, mapNumbers, mapDots);
    }

    public static List<string> SwapChunksCorrectLogic(List<ulong> input)
    {
        var (result, numbers, dots) = ConvertToDotsWithData(input);

        var i = 0;
        var j = numbers.Count - 1;
        while (0 < j && i <= dots.Count)
        {
            if (i == dots.Count - 1)
            {
                j--;
                i = 0;
            }

            var dotsLength = dots[i][1];
            var dotsIndex = dots[i][0];

            var numbersValue = numbers[j][1];
            var numbersLength = numbers[j][2];

            if (dotsLength >= numbersLength)
            {
                for (var k = dotsIndex; k < dotsIndex + numbersLength; k++)
                    result[(int)k] = numbersValue.ToString();

                if (dotsLength == numbersLength)
                    dots.RemoveAt(i);
                else
                {
                    dots[i][0] += numbersLength;
                    dots[i][1] -= numbersLength;
                }

                for (var z = numbers[j][0]; z < numbers[j][0] + numbersLength; z++)
                    result[(int)z] = ".";

                i = 0;
                j--;
            }
            else
                i++;
        }
        return result;
    }

    public static ulong CalculatePartTwo(List<ulong> input)
    {
        ulong result = 0;
        var counter = 0;
        var myString = SwapChunksCorrectLogic(input);

        foreach (var character in myString)
        {
            if (character == ".")
            {
            }
            else
                result += (ulong)(counter * int.Parse(character));

            counter++;
        }

        return result;
    }
}
