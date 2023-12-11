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

            int counter = 0;
            for (int j = 0; j < galaxy[0].Count; j++)
            {
                if (galaxy[rowIndex][j] == '.')
                {
                    counter += 1;
                }
            }
            return counter == galaxy[0].Count;
        }

        public bool EmptyCol(string filePath, int colIndex)
        {
            List<List<char>> galaxy = ReadFileToGrid(filePath);

            int counter = 0;
            for (int i = 0; i < galaxy.Count; i++)
            {
                if (galaxy[i][colIndex] == '.')
                {
                    counter += 1;
                }
            }
            return counter == galaxy.Count;
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



        //public bool EmptyCol(string filePath, int colIndex)
        //{
        //    List<List<char>> galaxy = ReadFileToGrid(filePath);

        //    int counter = 0;
        //    for (int i = 0; i < galaxy.Count; i++)
        //    {
        //        if (galaxy[i][colIndex] == '.')
        //        {
        //            counter += 1;
        //        }
        //    }
        //    return counter == galaxy.Count;
        //}

        //public int Final()
        //{
        //    int ans = 0;

        //    for (int idx1 = 0; idx1 < N; idx1++)
        //    {
        //        for (int idx2 = idx1 + 1; idx2 < N; idx2++)
        //        {
        //            int d = Dist(GetCoordinates[idx1], GetCoordinates[idx2]);
        //            ans += d;
        //        }
        //    }
        //    return ans;
        //}

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
