namespace src.day11
{
    public class Galaxy
    {
        private List<List<char>> galaxy;

        public Galaxy()
        {
            galaxy = ReadFileToGrid("C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day11\\data\\realData.txt");
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

        public bool EmptyRow(ulong rowIndex)
        {
            int rowIndexInt = (int)rowIndex;
            return galaxy[rowIndexInt].All(cell => cell == '.');
        }

        public bool EmptyCol(ulong colIndex)
        {
            int colIndexInt = (int)colIndex;
            return galaxy.All(row => row[colIndexInt] == '.');
        }

        public ulong GetDistanceBetweenTwoPoints(List<ulong> a, List<ulong> b)
        {
            ulong i1 = a[0], j1 = a[1];
            ulong i2 = b[0], j2 = b[1];

            (i1, i2) = (Math.Min(i1, i2), Math.Max(i1, i2));
            (j1, j2) = (Math.Min(j1, j2), Math.Max(j1, j2));

            ulong ans = 0;
            for (ulong i = i1; i < i2; i++)
            {
                ans += 1;
                if (EmptyRow(i))
                {
                    ans += 1;
                }
            }
            for (ulong j = j1; j < j2; j++)
            {
                ans += 1;
                if (EmptyCol(j))
                {
                    ans += 1;
                }
            }
            return ans;
        }

        public ulong GetFinal()
        {
            ulong result = 0;

            List<List<ulong>> coordinates = GetCoordinates();

            for (int i = 0; i < coordinates.Count; i++)
            {
                for (int j = i + 1; j < coordinates.Count; j++)
                {
                    result = result + GetDistanceBetweenTwoPoints(coordinates[i], coordinates[j]);
                }
            }

            return result;
        }

        public List<List<ulong>> GetCoordinates()
        {
            List<List<ulong>> coordinates = new List<List<ulong>>();

            for (int i = 0; i < galaxy.Count; i++)
            {
                for (int j = 0; j < galaxy[0].Count; j++)
                {
                    if (galaxy[i][j] == '#')
                    {
                        coordinates.Add(new List<ulong> { (ulong)i, (ulong)j });
                    }
                }
            }
            return coordinates;
        }
    }
}
