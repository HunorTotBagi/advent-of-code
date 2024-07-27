namespace AdventOfCode2023.Day21
{
    public class StepCounterSolver
    {
        public const char startingPointChar = 'S';
        public const char gardenPlot = '.';
        public const char markedTiles = 'O';

        public int CountReachableGardenPlots(string filePath, int numberOfSteps)
        {
            var total = 0;
            var matrix = SimulateElfMovement(filePath, numberOfSteps);

            for (int i = 0; i < matrix.Count(); i++)
            {
                for (int j = 0; j < matrix[0].Count(); j++)
                {
                    if (matrix[i][j] == 'O')
                    {
                        total++;
                    }
                }
            }
            return total;
        }

        public List<List<char>> SimulateElfMovement(string filePath, int numberOfSteps)
        {
            var matrix = ReadFileIntoCharGrid(filePath);

            matrix = InitializeGardenGrid(matrix, filePath);

            for (int i = 0; i < numberOfSteps - 1; i++)
            {
                matrix = ExpandGardenReach(matrix);
            }
            return matrix;
        }

        public List<List<char>> InitializeGardenGrid(List<List<char>> inputMatrix, string filePath)
        {
            var (realX, realY) = FindStartingPoint(filePath);

            MarkPositionIfEmpty(inputMatrix, realX + 1, realY);
            MarkPositionIfEmpty(inputMatrix, realX - 1, realY);
            MarkPositionIfEmpty(inputMatrix, realX, realY + 1);
            MarkPositionIfEmpty(inputMatrix, realX, realY - 1);

            inputMatrix[realX][realY] = '.';

            return inputMatrix;
        }

        public List<List<char>> ExpandGardenReach(List<List<char>> inputMatrix)
        {
            var cordX = new List<int>();
            var cordY = new List<int>();

            CollectMarkedTileCoordinates(inputMatrix, cordX, cordY);

            for (int i = 0; i < cordX.Count; i++)
            {
                MarkAdjacentGardenPlots(inputMatrix, cordX, cordY, i);
            }

            return inputMatrix;
        }

        public (int realX, int realY) FindStartingPoint(string filePath)
        {
            var matrix = ReadFileIntoCharGrid(filePath);

            for (int row = 0; row < matrix.Count; row++)
            {
                for (int col = 0; col < matrix[0].Count; col++)
                {
                    if (matrix[row][col] == startingPointChar)
                    {
                        return (row, col);
                    }
                }
            }
            return (-1, -1);
        }

        private static void MarkPositionIfEmpty(List<List<char>> inputMatrix, int x, int y)
        {
            if (0 <= x && x < inputMatrix.Count() && 0 <= y && y < inputMatrix[0].Count())
            {
                if (inputMatrix[x][y] == gardenPlot)
                {
                    inputMatrix[x][y] = markedTiles;
                }
            }
        }

        private static void MarkAdjacentGardenPlots(List<List<char>> inputMatrix, List<int> cordX, List<int> cordY, int i)
        {
            MarkPositionIfEmpty(inputMatrix, cordX[i] + 1, cordY[i]);
            MarkPositionIfEmpty(inputMatrix, cordX[i] - 1, cordY[i]);
            MarkPositionIfEmpty(inputMatrix, cordX[i], cordY[i] + 1);
            MarkPositionIfEmpty(inputMatrix, cordX[i], cordY[i] - 1);

            inputMatrix[cordX[i]][cordY[i]] = '.';
        }

        private static void CollectMarkedTileCoordinates(List<List<char>> inputMatrix, List<int> cordX, List<int> cordY)
        {
            for (int i = 0; i < inputMatrix.Count; i++)
            {
                for (int j = 0; j < inputMatrix[i].Count; j++)
                {
                    if (inputMatrix[i][j] == 'O')
                    {
                        cordX.Add(i);
                        cordY.Add(j);
                    }
                }
            }
        }

        public int GetCount(string filePath, int numberOfSteps)
        {
            var total = 0;
            var matrix = SimulateElfMovement(filePath, numberOfSteps);

            for (int i = 0; i < matrix.Count(); i++)
            {
                for (int j = 0; j < matrix[0].Count(); j++)
                {
                    if (matrix[i][j] == 'O')
                    {
                        total++;
                    }
                }
            }
            return total;
        }

        public List<List<char>> ReadFileIntoCharGrid(string filePath)
        {
            List<List<char>> grid = new List<List<char>>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    List<char> row = new List<char>(line);
                    grid.Add(row);
                }
            }
            return grid;
        }
    }
}