
namespace src.day13
{
    public class Hunor
    {
        public int GetReflectionIndex(List<List<char>> matrix)
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
            int k = 0;
            for (int j = i; j < matrix.Count - 1; j++)
            {
                if (0 <= i - 2 * k && i + 1 < matrix.Count)
                {
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
            return i + 1;
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
    }
}
