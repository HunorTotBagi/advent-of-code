namespace Src.Day01;

public class SolutionP1
{
    public static int Solve(string filePath)
    {
        var instructions = ReadFile(filePath);

        var position = 50;
        var countAtZero = 0;

        foreach (var (direction, distance) in instructions)
        {
            var steps = distance % 100;

            if (direction == 'R')
                position = (position + steps) % 100;

            else if (direction == 'L')
                position = (position - steps + 100) % 100;

            if (position == 0)
                countAtZero++;
        }

        return countAtZero;
    }



    public static List<(char, int)> ReadFile(string filePath)
    {
        var result = new List<(char, int)>();
        var lines = File.ReadAllLines(filePath);

        foreach (var line in lines)
        {
            var direction = line[0];
            var distance = int.Parse(line[1..]);

            result.Add((direction, distance));
        }

        return result;
    }
}
