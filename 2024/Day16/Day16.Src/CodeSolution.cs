namespace Day16.Src;

public class CodeSolution
{
    public static List<List<char>> ReadFile(string filePath)
    {
        var lines = File.ReadAllLines(filePath);

        return lines.Select(line => line.ToList()).ToList();
    }

    public static (int x, int y) FindStartingPosition(List<List<char>> input)
    {
        for (var i = 0; i < input.Count; i++)
        {
            for (var j = 0; j < input[0].Count; j++)
            {
                if (input[i][j] == 'S') return (i, j);
            }
        }
        return (-1, -1);
    }

    public static int FindLowestScore(List<List<char>> maze)
    {
        var directions = new (int dx, int dy)[] { (0, 1), (1, 0), (0, -1), (-1, 0) };
        var start = FindStartingPosition(maze);
        var queue = new PriorityQueue<(int x, int y, int dir, int score), int>();
        var visited = new HashSet<(int x, int y, int dir)>();

        queue.Enqueue((start.x, start.y, 0, 0), 0);
        visited.Add((start.x, start.y, 0));

        while (queue.Count > 0)
        {
            var (x, y, dir, score) = queue.Dequeue();

            if (maze[x][y] == 'E')
                return score;

            var newX = x + directions[dir].dx;
            var newY = y + directions[dir].dy;

            if (IsWithinBounds(newX, newY, maze) && maze[newX][newY] != '#' && !visited.Contains((newX, newY, dir)))
            {
                queue.Enqueue((newX, newY, dir, score + 1), score + 1);
                visited.Add((newX, newY, dir));
            }

            for (var turn = -1; turn <= 1; turn += 2)
            {
                var newDir = (dir + turn + 4) % 4;
                if (!visited.Contains((x, y, newDir)))
                {
                    queue.Enqueue((x, y, newDir, score + 1000), score + 1000);
                    visited.Add((x, y, newDir));
                }
            }
        }
        return -1;
    }

    private static bool IsWithinBounds(int x, int y, List<List<char>> maze)
    {
        return x >= 0 && x < maze.Count && y >= 0 && y < maze[0].Count;
    }

    public static int FindBestPathTiles(List<List<char>> maze)
    {
        var directions = new (int dx, int dy)[] { (0, 1), (1, 0), (0, -1), (-1, 0) };
        var start = FindStartingPosition(maze);
        var queue = new PriorityQueue<(int x, int y, int dir, int score, List<(int, int)> path), int>();
        var bestPaths = new HashSet<(int x, int y)>();
        var visitedScores = new Dictionary<(int x, int y, int dir), int>();

        queue.Enqueue((start.x, start.y, 0, 0, [(start.x, start.y)]), 0);

        var lowestScore = int.MaxValue;

        while (queue.Count > 0)
        {
            var (x, y, dir, score, path) = queue.Dequeue();

            if (maze[x][y] == 'E')
            {
                if (score < lowestScore)
                {
                    lowestScore = score;
                    bestPaths.Clear();
                }
                if (score == lowestScore)
                {
                    foreach (var tile in path)
                    {
                        bestPaths.Add(tile);
                    }
                }
                continue;
            }

            var newX = x + directions[dir].dx;
            var newY = y + directions[dir].dy;

            if (IsWithinBounds(newX, newY, maze) && maze[newX][newY] != '#')
            {
                var nextScore = score + 1;
                if (!visitedScores.TryGetValue((newX, newY, dir), out var existingScore) || nextScore <= existingScore)
                {
                    visitedScores[(newX, newY, dir)] = nextScore;
                    var newPath = new List<(int, int)>(path) { (newX, newY) };
                    queue.Enqueue((newX, newY, dir, nextScore, newPath), nextScore);
                }
            }

            for (var turn = -1; turn <= 1; turn += 2)
            {
                var newDir = (dir + turn + 4) % 4;
                var turnScore = score + 1000;

                if (!visitedScores.TryGetValue((x, y, newDir), out var turnExistingScore) || turnScore <= turnExistingScore)
                {
                    visitedScores[(x, y, newDir)] = turnScore;
                    queue.Enqueue((x, y, newDir, turnScore, [..path]), turnScore);
                }
            }
        }
        return bestPaths.Count;
    }
}
