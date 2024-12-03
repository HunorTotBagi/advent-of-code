namespace Day04.Src;

public class CodeSolution
{
    public static List<string> ReadFile(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var result = new List<string>();

        foreach (var line in lines)
        {
            var part = line.Split(" ");
        }

        return result;
    }
}
