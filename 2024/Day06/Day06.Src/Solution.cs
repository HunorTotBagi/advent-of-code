namespace Day06.Src;

public class Solution
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
                    return (i, j);
            }
        }
        return (-1, -1);
    }

    public static int CountVisitedPlaces(int i, int j, List<List<char>> input)
    {
        var dirRow = -1;
        var dirCol = 0;
        var seenPositions = new HashSet<Tuple<int, int>>();

        while (true)
        {
            seenPositions.Add(Tuple.Create(i, j));
            if (i + dirRow < 0 || i + dirRow >= input.Count || j + dirCol < 0 || j + dirCol >= input[0].Count)
                break;

            if (input[i + dirRow][j + dirCol] == '#')
            {
                var temp = dirCol;
                dirCol = -dirRow;
                dirRow = temp;
            }
            else
            {
                i += dirRow;
                j += dirCol;
            }
        }
        return seenPositions.Count;
    }

    public static bool GuardIsLooping(int i, int j, List<List<char>> input)
    {
        var dirRow = -1;
        var dirCol = 0;
        var seenPositions = new HashSet<Tuple<int, int, int, int>>();

        while (true)
        {
            seenPositions.Add(Tuple.Create(i, j, dirRow, dirCol));
            if (i + dirRow < 0 || i + dirRow >= input.Count || j + dirCol < 0 || j + dirCol >= input[0].Count)
                break;

            if (input[i + dirRow][j + dirCol] == '#')
            {
                var temp = dirCol;
                dirCol = -dirRow;
                dirRow = temp;
            }
            else
            {
                i += dirRow;
                j += dirCol;
            }

            if (seenPositions.Contains(Tuple.Create(i, j, dirRow, dirCol)))
                return true;
        }
        return false;
    }

    public static int CountInfiniteLoops(int x, int y, List<List<char>> input)
    {
        var count = 0;
        
        for (var i = 0; i < input.Count; i++)
        {
            for (var j = 0; j < input[0].Count; j++)
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
