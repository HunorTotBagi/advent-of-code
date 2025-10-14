namespace Day10.Src;

public class CodeSolution
{
    private static readonly List<(int, int)> Directions = [(1, 0), (-1, 0), (0, 1), (0, -1)];

    public static List<List<int>> ReadFile(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var result = new List<List<int>>();

        foreach (var line in lines)
        {
            var holder = new List<int>();
            foreach (var cha in line)
                holder.Add(int.Parse(cha.ToString()));

            result.Add(holder);
        }
        return result;
    }

    public static int SumTrailheadScores(List<List<int>> input)
    {
        var rows = input.Count;
        var cols = input[0].Count;
        var totalScore = 0;

        int DepthFirstSearch(int x, int y, bool[,] visited)
        {
            if (visited[x, y]) return 0;
            visited[x, y] = true;

            var score = (input[x][y] == 9) ? 1 : 0;

            foreach (var dir in Directions)
            {
                var newX = x + dir.Item1;
                var newY = y + dir.Item2;

                if (IsValidCell(newX, newY, input, visited) && input[newX][newY] == input[x][y] + 1)
                    score += DepthFirstSearch(newX, newY, visited);
            }
            return score;
        }

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                if (input[i][j] != 0) continue;
                var visited = new bool[rows, cols];
                totalScore += DepthFirstSearch(i, j, visited);
            }
        }
        return totalScore;
    }

    public static int SumTrailheadRatings(List<List<int>> input)
    {
        var rows = input.Count;
        var cols = input[0].Count;

        int CountPaths(int x, int y, bool[,] visited)
        {
            if (input[x][y] == 9) return 1;
            if (visited[x, y]) return 0;

            visited[x, y] = true;
            var pathCount = 0;

            foreach (var dir in Directions)
            {
                var newX = x + dir.Item1;
                var newY = y + dir.Item2;

                if (IsValidCell(newX, newY, input, visited) && input[newX][newY] == input[x][y] + 1)
                    pathCount += CountPaths(newX, newY, visited);
            }
            visited[x, y] = false;
            return pathCount;
        }
        var totalRating = 0;

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                if (input[i][j] != 0) continue;
                var visited = new bool[rows, cols];
                totalRating += CountPaths(i, j, visited);
            }
        }
        return totalRating;
    }

    private static bool IsValidCell(int x, int y, List<List<int>> input, bool[,] visited) =>
        x >= 0 && x < input.Count && y >= 0 && y < input[0].Count && !visited[x, y];
}
