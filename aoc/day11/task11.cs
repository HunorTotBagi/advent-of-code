namespace src.day11
{
    public class Galaxy
    {

        public List<List<int>> GetCoordinates(string filePath)
        {
            List<List<char>> galaxy = ReadFileToGrid(filePath);

            List<List<int>> coordinates = new();

            for (int i = 0; i < galaxy.Count; i++)
            {
                for (int j = 0; j < galaxy[0].Count; j++)
                {
                    if (galaxy[i][j] == '#')
                    {
                        coordinates.Add(new List<int> { i, j });
                    }
                }
            }
            return coordinates;
        }

        public bool EmptyRow(string filePath, int rowIndex)
        {
            List<List<char>> galaxy = ReadFileToGrid(filePath);

            int count = galaxy[rowIndex].Count(cell => cell == '.');
            return count == galaxy[rowIndex].Count;
        }

        public bool EmptyCol(string filePath, int colIndex)
        {
            List<List<char>> galaxy = ReadFileToGrid(filePath);

            int count = galaxy.Count(row => row[colIndex] == '.');
            return count == galaxy.Count;
        }

        public int GetDistanceBetweenTwoPoints(string filePath, List<int> a, List<int> b)
        {
            int i1 = a[0], j1 = a[1];
            int i2 = b[0], j2 = b[1];

            (i1, i2) = (Math.Min(i1, i2), Math.Max(i1, i2));
            (j1, j2) = (Math.Min(j1, j2), Math.Max(j1, j2));

            int ans = 0;
            for (int i = i1; i < i2; i++)
            {
                ans += 1;
                if (EmptyRow(filePath, i))
                {
                    ans += 1;
                }
            }
            for (int j = j1; j < j2; j++)
            {
                ans += 1;
                if (EmptyCol(filePath, j))
                {
                    ans += 1;
                }
            }
            return ans;
        }

        public int GetFinal(string filePath)
        {
            int result = 0;

            List<List<int>> coordinates = GetCoordinates(filePath);

            for (int i = 0; i < coordinates.Count; i++)
            {
                for (int j = 0; j < coordinates.Count; j++)
                {
                    if (j < i)
                    {
                        result += GetDistanceBetweenTwoPoints(filePath, coordinates[i], coordinates[j]);
                    }
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


    }
}
