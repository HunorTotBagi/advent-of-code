namespace Src.Day06;

public class SolutionP1
{
    public static int Calculate(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var grid = new int[1000, 1000];

        foreach (var line in lines)
        {
            var (command, cord1, cord2) = ExtractCommands(line);

            if (command == "turn on")
                for (var i = cord1[0]; i <= cord2[0]; i++)
                for (var j = cord1[1]; j <= cord2[1]; j++)
                    grid[i, j] = 1;

            else if (command == "toggle")
                for (var i = cord1[0]; i <= cord2[0]; i++)
                for (var j = cord1[1]; j <= cord2[1]; j++)
                {
                    if (grid[i, j] == 1)
                        grid[i, j] = 0;

                    else if (grid[i, j] == 0)
                        grid[i, j] = 1;
                }

            else if (command == "turn off")
                for (var i = cord1[0]; i <= cord2[0]; i++)
                for (var j = cord1[1]; j <= cord2[1]; j++)
                    grid[i, j] = 0;
        }

        var count = 0;
        for (var i = 0; i < 1000; i++)
            for (var j = 0; j < 1000; j++)
                if (grid[i, j] == 1)
                    count++;

        return count;
    }


    public static (string command, int[] first, int[] second) ExtractCommands(string s)
    {
        var s1 = s.Split(" through ");
        var secondCord = s1[1].Split(",");

        var y1 = int.Parse(secondCord[0]);
        var y2 = int.Parse(secondCord[1]);

        var firstPart = s1[0].Split(",");
        var zz = firstPart[0].Split(" ");

        var command = "";
        if (zz.Length == 3)
            command = zz[0] + " " + zz[1];
        else
            command = zz[0];

        var x1 = int.Parse(zz[^1]);
        var x2 = int.Parse(firstPart[^1]);

        var first = new[] { x1, x2 };
        var second = new[] { y1, y2 };

        return (command, first, second);
    }
}
