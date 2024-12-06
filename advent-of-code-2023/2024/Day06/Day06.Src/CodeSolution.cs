namespace Day06.Src;

public class CodeSolution
{
    public static List<List<char>> ReadFile(string filePath)
    {
        var lines = File.ReadAllLines(filePath);

        var listOfChars = new List<List<char>>();

        foreach (var line in lines)
        {
            listOfChars.Add(new List<char>(line));
        }

        return listOfChars;
    }

    public static (int first, int second) FindGuardPosition(List<List<char>> input)
    {
        for (var i = 0; i < input.Count; i++)
        {
            for (var j = 0; j < input[0].Count; j++)
            {
                if (input[i][j] == '^' || input[i][j] == '<' || input[i][j] == 'v' || input[i][j] == '>')
                {
                    return (i, j);
                }
            }
        }
        return (-1, -1);
    }

    public static int Count(int i, int j, List<List<char>> input)
    {
        var directionRow = -1;
        var directionColumn = 0;

        var seenPositions = new HashSet<Tuple<int, int>>();

        while (true)
        {
            seenPositions.Add(Tuple.Create(i, j));
            if (i + directionRow < 0 || i + directionRow >= input.Count || j + directionColumn < 0 || j + directionColumn >= input[0].Count)
                break;

            if (input[i + directionRow][j + directionColumn] == '#')
            {
                var temp = directionColumn;
                directionColumn = -directionRow;
                directionRow = temp;
            }
            else
            {
                i += directionRow;
                j += directionColumn;
            }
        }
        return seenPositions.Count;
    }

    public static bool GuardIsLooping(int i, int j, List<List<char>> input)
    {
        var directionRow = -1;
        var directionColumn = 0;

        var seenPositions = new HashSet<Tuple<int, int, int, int>>();

        while (true)
        {
            seenPositions.Add(Tuple.Create(i, j, directionRow, directionColumn));
            if (i + directionRow < 0 || i + directionRow >= input.Count || j + directionColumn < 0 || j + directionColumn >= input[0].Count)
                break;

            if (input[i + directionRow][j + directionColumn] == '#')
            {
                var temp = directionColumn;
                directionColumn = -directionRow;
                directionRow = temp;
            }
            else
            {
                i += directionRow;
                j += directionColumn;
            }
            if (seenPositions.Contains(Tuple.Create(i, j, directionRow, directionColumn)))
            {
                return true;
            }
        }

        return false;
    }

    public static int CountLoops(int x, int y, List<List<char>> input)
    {
        var count = 0;
        var rows = input.Count;
        var cols = input[0].Count;
        
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                if (input[i][j] != '.') continue;
                input[i][j] = '#';

                if (GuardIsLooping(x, y, input))
                    count++;

                input[i][j] = '.';
            }
        }
        return count;
    }
}
