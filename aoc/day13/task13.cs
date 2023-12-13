

namespace src.day13
{
    public class Hunor
    {
        public int GetColumnsReflection(List<List<char>> matrix)
        {
            int res = 0;
            for (int i = 0; i < matrix[0].Count - 1; i++)
            {
                res += PoklapanjeColumn(i, matrix);
            }
            return res;
        }
        private int PoklapanjeColumn(int i, List<List<char>> matrix)
        {
            int secondCounter = 0;
            int k = 0;
            for (int j = i; j < matrix[0].Count; j++)
            {
                if (0 <= j - 2 * k && j + 1 < matrix[0].Count)
                {
                    secondCounter++;
                    if (!ColumnEqual(matrix, j - 2 * k, j + 1))
                    {
                        return 0;
                    }
                    else
                    {
                        k++;
                    }
                }
            }
            if (k == secondCounter)
            {
                return i + 1;
            }
            return 0;
        }

        private bool ColumnEqual(List<List<char>> matrix, int col1, int col2)
        {
            for (int i = 0; i < matrix.Count; i++)
            {
                if (matrix[i][col1] != matrix[i][col2])
                    return false;
            }
            return true;
        }

        public int GetReflectionRow(List<List<char>> matrix)
        {
            int res = 0;
            for (int i = 0; i < matrix.Count - 1; i++)
            {
                res += Poklapanje(i, matrix);
            }
            return res;
        }

        private int Poklapanje(int i, List<List<char>> matrix)
        {
            int secondCounter = 0;
            int k = 0;
            for (int j = i; j < matrix.Count; j++)
            {
                if (0 <= j - 2 * k && j + 1 < matrix.Count)
                {
                    secondCounter++;
                    if (!matrix[j - 2 * k].SequenceEqual(matrix[j + 1]))
                    {
                        return 0;
                    }
                    else
                    {
                        k++;
                    }
                }
            }
            if (k == secondCounter)
            {
                return i + 1;
            }
            return 0;
        }

        public static List<List<char>> Transpose(List<List<char>> matrix)
        {
            if (matrix == null || matrix.Count == 0 || matrix[0].Count == 0)
                return new List<List<char>>();

            int rowCount = matrix.Count;
            int colCount = matrix[0].Count;

            // Initialize the transposed matrix with the required capacity
            var transposed = new List<List<char>>(colCount);
            for (int i = 0; i < colCount; i++)
            {
                transposed.Add(new List<char>(rowCount));
            }

            // Transpose the matrix
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
