namespace Src.Day02;

public class SolutionP1
{
    public static bool IsValidDigit(int number)
    {
        var numberAsString = number.ToString();

        if (numberAsString.Length %2 != 0)
            return false;

        var firstHalf = numberAsString[..(numberAsString.Length / 2)];
        var secondHalf = numberAsString[(numberAsString.Length / 2)..];

        if (firstHalf == secondHalf)
            return true;

        return false;
    }

    public static List<string> ReadFile(string filePath)
    {
        var line = File.ReadAllLines(filePath);

        var separated = line[0].Split(',');

        return separated.ToList();
    }
}
