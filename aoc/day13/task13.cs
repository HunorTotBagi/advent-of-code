namespace src.day13
{
    public class Hunor
    {
        public int GetColumnsReflection(List<List<char>> matrix)
        {
            return GetReflectionRow(Transpose(matrix));
        }

        public int GetReflectionRow(List<List<char>> grid)
        {
            for (int r = 1; r < grid.Count; r++)
            {
                List<string> above = grid.Take(r).Select(chars => new string(chars.ToArray())).Reverse().ToList();
                List<string> below = grid.Skip(r).Select(chars => new string(chars.ToArray())).ToList();

                int minLength = Math.Min(above.Count, below.Count);
                above = above.Take(minLength).ToList();
                below = below.Take(minLength).ToList();

                if (Enumerable.SequenceEqual(above, below))
                    return r;
            }

            return 0;
        }

        public static List<List<char>> Transpose(List<List<char>> matrix)
        {
            if (matrix == null || matrix.Count == 0 || matrix[0].Count == 0)
                return new List<List<char>>();

            int rowCount = matrix.Count;
            int colCount = matrix[0].Count;

            var transposed = new List<List<char>>(colCount);
            for (int i = 0; i < colCount; i++)
            {
                transposed.Add(new List<char>(rowCount));
            }

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    transposed[col].Add(matrix[row][col]);
                }
            }

            return transposed;
        }


        public List<List<List<char>>> ReadFileIntoBlocks(string filePath)
        {
            var blocks = new List<List<List<char>>>();
            var currentBlock = new List<List<char>>();

            foreach (var line in File.ReadLines(filePath))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    if (currentBlock.Count > 0)
                    {
                        blocks.Add(currentBlock);
                        currentBlock = new List<List<char>>();
                    }
                }
                else
                {
                    var charList = new List<char>(line);
                    currentBlock.Add(charList);
                }
            }

            if (currentBlock.Count > 0)
            {
                blocks.Add(currentBlock);
            }

            return blocks;
        }

        public int Final(string realData)
        {
            List<List<List<char>>> matrix = ReadFileIntoBlocks(realData);

            int result = 0;

            for (int row = 0; row < matrix.Count; row++)
            {
                int colRes = GetColumnsReflection(matrix[row]);
                int rowRes = GetReflectionRow(matrix[row]);

                result += colRes + 100 * rowRes;
            }

            return result;

        }
    }
}
