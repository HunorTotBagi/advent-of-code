namespace src.day10
{
    public class Pipe
    {
        public List<int> GetIndexOfStartingPosition(string filePath)
        {
            List<List<char>> matrix = ReadTextFile(filePath);

            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix[0].Count; j++)
                {
                    if (matrix[i][j] == 'S')
                    {
                        return new List<int> { i, j};
                    }
                }
            }
            return new List<int> { -1, -1 };
        }

        public List<List<char>> ReadTextFile(string filePath)
        {
            List<List<char>> grid = new List<List<char>>();

            try
            {
                // Read all lines from the file
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    // Create a list to hold characters in each line
                    List<char> row = new List<char>();

                    // Iterate through characters in the line and add them to the list
                    foreach (char symbol in line)
                    {
                        row.Add(symbol);
                    }

                    // Add the list of characters to the grid
                    grid.Add(row);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return grid;
        }

        static List<List<int>> CreateZeroMatrix(int rows, int columns)
        {
            List<List<int>> matrix = new List<List<int>>();

            for (int i = 0; i < rows; i++)
            {
                List<int> row = new List<int>();

                for (int j = 0; j < columns; j++)
                {
                    // Add zero to each element in the row
                    row.Add(0);
                }

                // Add the row to the matrix
                matrix.Add(row);
            }

            return matrix;
        }

        public List<List<int>> CreateZeroMatrixForPipe(string filePath)
        {
            List<List<char>> matrix = ReadTextFile(filePath);

            int rows = matrix.Count;
            int columns = matrix[0].Count;

            return CreateZeroMatrix(rows, columns);
        }
    }
}
