namespace Day12.Src;

public class Solution
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

    public static List<HashSet<(int, int)>> FloodFill(List<List<char>> grid)
    {
        var rows = grid.Count;
        var cols = grid[0].Count;

        var regions = new List<HashSet<(int, int)>>();
        var seen = new HashSet<(int, int)>();

        for (var r = 0; r < rows; r++)
        {
            for (var c = 0; c < cols; c++)
            {
                if (seen.Contains((r, c))) continue;
                seen.Add((r, c));

                var region = new HashSet<(int, int)> { (r, c) };
                var queue = new Queue<(int, int)>();
                queue.Enqueue((r, c));
                var crop = grid[r][c];

                while (queue.Count > 0)
                {
                    var (cr, cc) = queue.Dequeue();

                    foreach (var (nr, nc) in new (int, int)[]
                                 { (cr - 1, cc), (cr + 1, cc), (cr, cc - 1), (cr, cc + 1) })
                    {
                        if (nr < 0 || nc < 0 || nr >= rows || nc >= cols) continue;
                        if (grid[nr][nc] != crop) continue;
                        if (region.Contains((nr, nc))) continue;

                        region.Add((nr, nc));
                        queue.Enqueue((nr, nc));
                    }
                }

                seen.UnionWith(region);
                regions.Add(region);
            }
        }
        return regions;
    }
}
