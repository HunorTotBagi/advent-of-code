namespace Day12.Src;

public class CodeSolution
{
    public static List<List<char>> ReadFile(string filePath)
    {
        var lines = File.ReadAllLines(filePath);

        var result = new List<List<char>>();

        foreach (var line in lines)
        {
            var holder = new List<char>();
            foreach (var ch in line)
            {
                holder.Add(ch);
            }
            result.Add(holder);
        }
        return result;
    }

    public static HashSet<char> GetUniqueCharacter(List<List<char>> input)
    {
        var unique = new HashSet<char>();
        for (var i = 0; i < input.Count; i++)
        {
            for (var j = 0; j < input[0].Count; j++)
            {
                if (!unique.Contains(input[i][j]))
                {
                    unique.Add(input[i][j]);
                }
            }
        }

        return unique;
    }

    public static int GetArea(char flower, List<List<char>> input)
    {
        var result = 0;
        for (var i = 0; i < input.Count; i++)
        {
            for (var j = 0; j < input[0].Count; j++)
            {
                if (input[i][j] == flower)
                {
                    result++;
                }
            }
        }
        return result;
    }
    public static int GetPerimeter(char letter, List<List<char>> grid)
    {
        int rows = grid.Count;
        int cols = grid[0].Count;
        bool[,] visited = new bool[rows, cols];

        // Directions: up, down, left, right
        int[,] directions = { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };

        bool IsValid(int x, int y)
        {
            return x >= 0 && x < rows && y >= 0 && y < cols;
        }

        int FloodFillPerimeter(int x, int y)
        {
            Stack<(int, int)> stack = new Stack<(int, int)>();
            stack.Push((x, y));
            int perimeter = 0;

            while (stack.Count > 0)
            {
                var (cx, cy) = stack.Pop();
                if (visited[cx, cy])
                    continue;

                visited[cx, cy] = true;

                for (int i = 0; i < 4; i++)
                {
                    int nx = cx + directions[i, 0];
                    int ny = cy + directions[i, 1];

                    if (!IsValid(nx, ny) || grid[nx][ny] != letter)
                    {
                        // Edge of the grid or different letter contributes to the perimeter
                        perimeter++;
                    }
                    else if (!visited[nx, ny])
                    {
                        stack.Push((nx, ny));
                    }
                }
            }

            return perimeter;
        }

        int totalPerimeter = 0;

        // Iterate over the grid to find all regions of the given letter
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (grid[i][j] == letter && !visited[i, j])
                {
                    totalPerimeter += FloodFillPerimeter(i, j);
                }
            }
        }

        return totalPerimeter;
    }

    public static int Calculate(List<List<char>> input)
    {
        var result = 0;
        var flowers = GetUniqueCharacter(input);

        foreach (var flower in flowers)
        {
            var area = GetArea(flower, input);
            var perimeter = GetPerimeter(flower, input);
            result += area * perimeter;
        }

        return result;
    }

    public static int CalculateTotalPrice(List<List<char>> map)
    {
        int rows = map.Count;
        int cols = map[0].Count;
        bool[,] visited = new bool[rows, cols];
        int totalPrice = 0;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (!visited[r, c])
                {
                    (int area, int perimeter) = FloodFill(map, visited, r, c, map[r][c]);
                    totalPrice += area * perimeter;
                }
            }
        }

        return totalPrice;
    }

    static (int, int) FloodFill(List<List<char>> map, bool[,] visited, int startRow, int startCol, char plantType)
    {
        int rows = map.Count;
        int cols = map[0].Count;
        int area = 0;
        int perimeter = 0;

        Queue<(int, int)> queue = new Queue<(int, int)>();
        queue.Enqueue((startRow, startCol));
        visited[startRow, startCol] = true;

        int[] dRow = { -1, 1, 0, 0 };
        int[] dCol = { 0, 0, -1, 1 };

        while (queue.Count > 0)
        {
            var (currentRow, currentCol) = queue.Dequeue();
            area++;

            for (int i = 0; i < 4; i++)
            {
                int newRow = currentRow + dRow[i];
                int newCol = currentCol + dCol[i];

                if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols)
                {
                    if (map[newRow][newCol] == plantType && !visited[newRow, newCol])
                    {
                        queue.Enqueue((newRow, newCol));
                        visited[newRow, newCol] = true;
                    }
                    else if (map[newRow][newCol] != plantType)
                    {
                        perimeter++;
                    }
                }
                else
                {
                    perimeter++;
                }
            }
        }

        return (area, perimeter);
    }
}
