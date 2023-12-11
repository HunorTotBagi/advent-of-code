namespace src.day11
{
    public class Hunor
    {
        public List<List<char>> ExpanGalaxy(string filePath0)
        {
            List<List<char>> matrix = ExpandRows(filePath0);

            List<List<char>> result = new List<List<char>>();

            for (int i = 0; i < matrix.Count; i++)
            {
                result.Add(new List<char>());
            }

            for (int j = 0; j < matrix[0].Count; j++)
            {
                int counter = 0;
                for (int i = 0; i < matrix.Count; i++)
                {
                    if (matrix[i][j] == '.')
                    {
                        counter++;
                    }
                }
                if (counter == matrix.Count)
                {
                    for (int i = 0; i < matrix.Count; i++)
                    {
                        result[i].Add('.');
                        result[i].Add('.');
                    }
                }
                else
                {
                    for (int i = 0; i < matrix.Count; i++)
                    {
                        result[i].Add(matrix[i][j]);
                    }
                }
            }

            return result; // Added return statement
        }

        public List<List<char>> ExpandRows(string filePath0)
        {
            List<List<char>> matrix = ReadFileToGrid(filePath0);

            List<List<char>> result = new();

            List<char> madeUpRows = new();

            for (int i = 0; i < matrix.Count; i++)
            {
                madeUpRows.Add('.');
            }

            for (int i = 0; i < matrix.Count; i++)
            {
                int counter = 0;
                for (int j = 0; j < matrix[0].Count; j++)
                {
                    if (matrix[i][j] == '.')
                    {
                        counter++;
                    }
                }
                if (counter == matrix[0].Count)
                {
                    result.Add(madeUpRows);
                    result.Add(madeUpRows);
                }
                else
                {
                    result.Add(matrix[i]);
                }
            }

            return result;
        }

        public List<List<char>> ReadFileToGrid(string filePath)
        {
            List<List<char>> grid = new List<List<char>>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        List<char> row = new List<char>(line.ToCharArray());
                        grid.Add(row);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading the file: {ex.Message}");
            }

            return grid;
        }

        public int GetShortestPath(int[] start, int[] end)
        {
            return Math.Abs(start[0] - end[0]) + Math.Abs(start[1] - end[1]);
        }

        public List<List<int>> GetAllCoordinates(string filePath0)
        {
            List<List<char>> galaxy = ExpanGalaxy(filePath0);

            List<List<int>> result = new();

            for (int i = 0; i < galaxy.Count; i++)
            {
                for (int j = 0; j < galaxy[0].Count; j++)
                {
                    if (galaxy[i][j] == '#')
                    {
                        result.Add(new List<int> { i, j });
                    }
                }
            }
            return result;
        }

        public int GetSum(string filePath0)
        {
            List<List<int>> GetAllCoordinates(string filePath0)
        }
    }


}
