namespace Src.Day05;

public class SolutionP1
{
    public static int GetResult(string filePath)
    {
        var lines = new List<string>(File.ReadAllLines(filePath));
        var counter = 0;

        foreach (var line in lines)
        {
            if (IsNiceString(line))
                counter++;
        }

        return counter;
    }

    public static bool IsNiceString(string input)
    {
        return ContainsAtLeastThreeVowel(input) && 
               ContainsAtLeastOneLetterThatAppearsTwice(input) &&
               DoesNotHaveDisallowedString(input);
    }

    public static bool ContainsAtLeastThreeVowel(string input)
    {
        var vowelCounter = 0;
        foreach (var c in input)
        {
            if (c == 'a' || c == 'o' || c == 'e' || c == 'i' || c == 'u')
                vowelCounter++;

            if (vowelCounter == 3)
                return true;
        }

        return false;
    }

    public static bool ContainsAtLeastOneLetterThatAppearsTwice(string input)
    {
        var charArray = input.ToCharArray();

        for (var i = 0; i < charArray.Length - 1; i++)
        {
            if (charArray[i] == charArray[i + 1])
                return true;
        }

        return false;
    }

    public static bool DoesNotHaveDisallowedString(string input)
    {
        var charArray = input.ToCharArray();

        for (var i = 0; i < charArray.Length - 1; i++)
        {
            if (charArray[i] == 'a' & charArray[i+1]=='b'
                || charArray[i] == 'c' & charArray[i + 1] == 'd'
                || charArray[i] == 'p' & charArray[i + 1] == 'q'
                || charArray[i] == 'x' & charArray[i + 1] == 'y')
                return false;
        }

        return true;
    }
}
