namespace Src.Day05;

public class SolutionP2
{
    public static int GetResult(string filePath)
    {
        var lines = new List<string>(File.ReadAllLines(filePath));

        var counter = 0;
        foreach (var line in lines)
        {
            if (IsNiceStringP2(line))
                counter++;
        }

        return counter;
    }


    public static bool IsNiceStringP2(string input)
    {
        return Condition1(input) && Condition2(input);
    }


    public static bool Condition1(string input)
    {
        var charArray = input.ToCharArray();

        for (var i = 0; i < charArray.Length-1; i++)
        {
            for (var j = i+2; j < charArray.Length - 1; j++)
            {
                if (charArray[j] == charArray[i] && charArray[j + 1] == charArray[i + 1])
                    return true;
            }
        }

        return false;
    }

    public static bool Condition2(string input)
    {
        var charArray = input.ToCharArray();

        for (var i = 0; i < charArray.Length - 2; i++)
        {
            if (charArray[i] == charArray[i + 2])
                return true;
        }

        return false;
    }
}
