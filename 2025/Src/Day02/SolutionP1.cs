namespace Src.Day02;

public class SolutionP1
{
    public static List<string> ReadFile(string filePath)
    {
        var line = File.ReadAllLines(filePath);

        var separated = line[0].Split(',');

        return separated.ToList();
    }
}
