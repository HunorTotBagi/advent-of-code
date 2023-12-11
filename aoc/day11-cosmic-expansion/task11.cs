namespace src.day11_cosmic_expansion
{
    public class GalacticUniverse
    {
        private readonly List<List<char>> galacticGrid;

        public List<List<ulong>> GetGalaxyCoordinates()
        {
            List<List<ulong>> coordinates = new List<List<ulong>>();

            for (int i = 0; i < galacticGrid.Count; i++)
            {
                for (int j = 0; j < galacticGrid[0].Count; j++)
                {
                    if (galacticGrid[i][j] == '#')
                    {
                        coordinates.Add(new List<ulong> { (ulong)i, (ulong)j });
                    }
                }
            }
            return coordinates;
        }

        public bool IsRowEmpty(ulong rowIndex)
        {
            int rowIndexInt = (int)rowIndex;
            return galacticGrid[rowIndexInt].All(cell => cell == '.');
        }

        public bool IsColumnEmpty(ulong colIndex)
        {
            int colIndexInt = (int)colIndex;
            return galacticGrid.All(row => row[colIndexInt] == '.');
        }

        public ulong CalculateDistanceBetweenGalaxies(List<ulong> firstPoint, List<ulong> secondPoint, ulong orderOfExpansion)
        {
            ulong x1 = firstPoint[0], y1 = firstPoint[1];
            ulong x2 = secondPoint[0], y2 = secondPoint[1];

            (x1, x2) = (Math.Min(x1, x2), Math.Max(x1, x2));
            (y1, y2) = (Math.Min(y1, y2), Math.Max(y1, y2));

            ulong totalDistance = 0;
            for (ulong i = x1; i < x2; i++)
            {
                totalDistance += 1 + (IsRowEmpty(i) ? orderOfExpansion - 1 : 0);
            }

            for (ulong j = y1; j < y2; j++)
            {
                totalDistance += 1 + (IsColumnEmpty(j) ? orderOfExpansion - 1 : 0);
            }
            return totalDistance;
        }

        public ulong CalculateTotalDistance(ulong orderOfExpansion)
        {
            ulong result = 0;

            List<List<ulong>> coordinates = GetGalaxyCoordinates();
            int numCoordinates = coordinates.Count;

            for (int i = 0; i < numCoordinates; i++)
            {
                for (int j = i + 1; j < numCoordinates; j++)
                {
                    result += CalculateDistanceBetweenGalaxies(coordinates[i], coordinates[j], orderOfExpansion);
                }
            }
            return result;
        }

        public List<List<char>> ReadFileToGalacticGrid(string filePath)
        {
            List<List<char>> grid = new List<List<char>>();

            foreach (string line in File.ReadLines(filePath))
            {
                grid.Add(new List<char>(line));
            }
            return grid;
        }

        public GalacticUniverse()
        {
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../aoc/day11-cosmic-expansion/data/inputExample.txt";
            galacticGrid = ReadFileToGalacticGrid(filePath);
        }
    }
}