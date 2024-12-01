namespace Day02.Src;

public class CodeSolution
{
    public static int[] ReadFile(string filePath)
    {
        var lines = File.ReadAllLines(filePath);

        var array1 = new int[lines.Length];
        var array2 = new int[lines.Length];

        for (var i = 0; i < lines.Length; i++)
        {
            var parts = lines[i].Split([' ', '\t'], StringSplitOptions.RemoveEmptyEntries);

            array1[i] = int.Parse(parts[0]);
            array2[i] = int.Parse(parts[1]);
        }

        return array1;
    }
}
