namespace Src.Day11;

public class SolutionP1
{
    public static string FinalAnswer(string input)
    {
        while (!IsPasswordGood(input))
            input = GenerateNextPassword(input);

        return input;
    }

    public static string GenerateNextPassword(string input)
    {
        var chars = input.ToCharArray();
        var i = chars.Length - 1;

        while (i >= 0)
        {
            if (chars[i] == 'z')
            {
                chars[i] = 'a';
                i--;
            }
            else
            {
                chars[i]++;
                return new string(chars);
            }
        }

        return 'a' + new string(chars);
    }

    public static bool IsPasswordGood(string input)
    {
        return PasswordContainsThreeIncreasingLetters(input) &&
               PasswordDoesNotContainForbiddenLetters(input) &&
               PasswordContainsTwoDifferentNonOverlappingPairsOfLetters(input);
    }

    public static bool PasswordContainsThreeIncreasingLetters(string input)
    {
        for (var i = 0; i < input.Length - 2; i++)
        {
            var first = input[i] - '0';
            var second = input[i+1] - '0';
            var third = input[i+2] - '0';

            if (second - first == 1 && third - second == 1)
                return true;
        }

        return false;
    }

    public static bool PasswordDoesNotContainForbiddenLetters(string input)
    {
        if (input.Contains("i"))
            return false;
        if (input.Contains("o"))
            return false;
        if (input.Contains("l"))
            return false;

        return true;
    }

    public static bool PasswordContainsTwoDifferentNonOverlappingPairsOfLetters(string input)
    {
        var counter = 0;
        var seen = new HashSet<char>();

        for (var i = 0; i < input.Length - 1; i++)
        {
            if (input[i] == input[i + 1])
            {
                seen.Add(input[i]);
                counter++;
            }
        }

        return counter >= 2 && seen.Count >= 2;
    }
}
