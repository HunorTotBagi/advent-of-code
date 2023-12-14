namespace src.day14
{
    public class Hunor
    {
        public List<List<char>> SlideRocksNorthInColumn(List<List<char>> matrix, int column)
        {
            int obstaclePosition = 0;
            for (int i = 0; i < matrix.Count; i++)
            {
                if (matrix[i][column] == '#')
                {
                    obstaclePosition = i;
                }
                if (matrix[i][column] == 'O')
                {
                    for (int j = i - 1; j >= obstaclePosition; j--)
                    {
                        if (matrix[j][column] == '.')
                        {
                            matrix[j][column] = 'O';
                            matrix[j + 1][column] = '.';
                            break;
                        }
                    }
                }
            }
            return matrix;
        }

        public List<List<char>> LoadMatrixFromFile(string filePath)
        {
            List<List<char>> grid = new List<List<char>>();

            foreach (var line in File.ReadLines(filePath))
            {
                List<char> row = new List<char>(line.ToCharArray());

                grid.Add(row);
            }
            return grid;
        }

        public int CalculateTotalLoad(List<List<char>> matrix)
        {
            for (int i = 0; i < matrix[0].Count; i++)
            {
                matrix = SlideRocksNorthInColumn(matrix, i);
            }
            int totalLoad = 0;
            int rowCount = matrix.Count;

            for (int j = 0; j < matrix[0].Count; j++)
            {
                for (int i = 0; i < matrix.Count; i++)
                {
                    if (matrix[i][j] == 'O')
                        totalLoad += rowCount - i;
                }
            }
            return totalLoad;
        }
    }
}