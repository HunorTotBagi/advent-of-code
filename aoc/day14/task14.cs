

namespace src.day14
{
    public class Hunor
    {
        public int Calculate(List<List<char>> matrix)
        {
            for (int i = 0; i < matrix[0].Count; i++)
            { 
                matrix = MoveOneRowNorth(matrix, i);
            }

            int total = 0;

            int len  = matrix.Count;



            for (int j = 0; j < matrix[0].Count; j++)
            {
                for (int i = 0; i < matrix.Count; i++)
                {
                    if (matrix[i][j] == 'O')
                    {
                        total += len - i;
                    }
                }
            }
            return total;
        }

        public List<List<char>> MoveOneRowNorth(List<List<char>> matrix, int column)
        {
            int limit = 0;
            for (int i = 0; i < matrix.Count; i++)
            {
                if (matrix[i][column] == '#')
                {
                    limit = i;
                }
                if (matrix[i][column] == 'O')
                {
                    for (int j = i-1; j >= limit; j--)
                    {
                        if (matrix[j][column] == '.')
                        {
                            matrix[j][column] = 'O';
                            matrix[j+1][column] = '.';
                        }
                    }
                }
            }
            return matrix;
        }

        public List<List<char>> ReadFileIntoList(string filePath)
        {
            List<List<char>> grid = new List<List<char>>();

            // Read each line from the file
            foreach (var line in File.ReadLines(filePath))
            {
                // Convert the line to a List<char>
                List<char> row = new List<char>(line.ToCharArray());

                // Add the row to the grid
                grid.Add(row);
            }

            return grid;
        }
    }
}
