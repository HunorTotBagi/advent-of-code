namespace AdventOfCode2023.Day16
{
    public class Contraption
    {
        public int Calculate(string filePath)
        {
            var matrix = ReadFileIntoCharList(filePath);

            var que = new Queue<(int, int, int, int)>();
            var seen = new HashSet<(int, int, int, int)>();
            que.Enqueue((0, -1, 0, 1));

            while (que.Count != 0)
            {
                var (row, col, rowDirection, colDirection) = que.Dequeue();
                row += rowDirection;
                col += colDirection;

                if (row < 0 || row >= matrix.Count || col < 0 || col >= matrix[0].Count)
                    continue;

                char ch = matrix[row][col];
                var state = (row, col, rowDirection, colDirection);

                if (ch == '.' || (ch == '-' && colDirection != 0) || (ch == '|' && rowDirection != 0))
                {
                    if (!seen.Contains(state))
                    {
                        seen.Add(state);
                        que.Enqueue(state);
                    }
                }
                else if (ch == '/')
                {
                    var newState = (row, col, -colDirection, -rowDirection);
                    if (!seen.Contains(newState))
                    {
                        seen.Add(newState);
                        que.Enqueue(newState);
                    }
                }
                else if (ch == '\\')
                {
                    var newState = (row, col, colDirection, rowDirection);
                    if (!seen.Contains(newState))
                    {
                        seen.Add(newState);
                        que.Enqueue(newState);
                    }
                }
                else if (ch == '|' || ch == '-')
                {
                    var newState1 = (row, col, 1, 0);
                    var newState2 = (row, col, -1, 0);
                    if (ch == '-')
                    {
                        newState1 = (row, col, 0, 1);
                        newState2 = (row, col, 0, -1);
                    }

                    if (!seen.Contains(newState1))
                    {
                        seen.Add(newState1);
                        que.Enqueue(newState1);
                    }
                    if (!seen.Contains(newState2))
                    {
                        seen.Add(newState2);
                        que.Enqueue(newState2);
                    }
                }
            }
            return seen.Select(x => (x.Item1, x.Item2)).Distinct().Count(); 
    }

    public List<List<char>> ReadFileIntoCharList(string filePath)
        {
            List<List<char>> result = new List<List<char>>();
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                List<char> charLine = new List<char>(line);
                result.Add(charLine);
            }
            return result;
        }
    }
}