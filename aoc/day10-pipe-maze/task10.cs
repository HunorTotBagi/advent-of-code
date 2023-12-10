namespace src.day10
{
    public class Pipe
    {
        public List<List<char>> ReadTextFile(string filePath)
        {
            List<List<char>> grid = new List<List<char>>();

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                List<char> row = new List<char>();

                foreach (char symbol in line)
                {
                    row.Add(symbol);
                }
                grid.Add(row);
            }

            return grid;
        }

        public List<List<int>> CreateMatrixWithZeros(string filePath)
        {
            List<List<char>> data = ReadTextFile(filePath);
            List<List<int>> matrix = new List<List<int>>();

            for (int i = 0; i < data.Count; i++)
            {
                List<int> row = new List<int>();

                for (int j = 0; j < data[0].Count; j++)
                {
                    row.Add(0);
                }
                matrix.Add(row);
            }
            return matrix;
        }

        public List<List<int>> ProcessStartTile(int currentIteration, List<List<int>> inputMatrix, string filePath)
        {
            List<List<char>> matrix = ReadTextFile(filePath);

            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix[0].Count; j++)
                {
                    if (matrix[i][j] == 'S')
                    {
                        // TODO: fix this

                        ProcessLeft(currentIteration, inputMatrix, matrix, i, j, 'F');
                        ProcessRight(currentIteration, inputMatrix, matrix, i, j, '-');
                        //AddTop(currentIteration, inputMatrix, matrix, i, j, '|');
                        //AddDown(currentIteration, inputMatrix, matrix, i, j, '|');
                        break;
                    }
                }
            }
            return inputMatrix;
        }

        private static bool IndexesAreWithinBounds(List<List<char>> matrix, int i, int j)
        {
            return 0 <= i && i < matrix.Count && 0 <= j && j < matrix[0].Count;
        }

        private static void ProcessLeft(int currentIteration, List<List<int>> inputMatrix, List<List<char>> matrix, int i, int j, char pipe)
        {
            if (IndexesAreWithinBounds(matrix, i, j - 1))
            {
                if (matrix[i][j - 1] == pipe && inputMatrix[i][j - 1] == 0)
                {
                    inputMatrix[i][j - 1] = currentIteration + 1;
                }
            }
        }

        private static void ProcessRight(int currentIteration, List<List<int>> inputMatrix, List<List<char>> matrix, int i, int j, char pipe)
        {
            if (IndexesAreWithinBounds(matrix, i, j + 1))
            {
                if (matrix[i][j + 1] == pipe && inputMatrix[i][j + 1] == 0)
                {
                    inputMatrix[i][j + 1] = currentIteration + 1;
                }
            }
        }

        private static void ProcessTop(int currentIteration, List<List<int>> inputMatrix, List<List<char>> matrix, int i, int j, char pipe)
        {
            if (IndexesAreWithinBounds(matrix, i - 1, j))
            {
                if (matrix[i - 1][j] == pipe && inputMatrix[i - 1][j] == 0)
                {
                    inputMatrix[i - 1][j] = currentIteration + 1;
                }
            }
        }

        private static void ProcessDown(int currentIteration, List<List<int>> inputMatrix, List<List<char>> matrix, int i, int j, char pipe)
        {
            if (IndexesAreWithinBounds(matrix, i + 1, j))
            {
                if (matrix[i + 1][j] == pipe && inputMatrix[i + 1][j] == 0)
                {
                    inputMatrix[i + 1][j] = currentIteration + 1;
                }
            }
        }

        public List<List<int>> ProcessEveryPipeCheck(List<List<int>> inputMatrix, int currentIteration, string filePath)
        {
            List<List<char>> matrix = ReadTextFile(filePath);

            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix[0].Count; j++)
                {
                    if (inputMatrix[i][j] == currentIteration)
                    {
                        if (matrix[i][j] == 'L')
                        {
                            ProcessRight(currentIteration, inputMatrix, matrix, i, j, '-');
                            ProcessRight(currentIteration, inputMatrix, matrix, i, j, 'J');
                            ProcessRight(currentIteration, inputMatrix, matrix, i, j, '7');

                            ProcessTop(currentIteration, inputMatrix, matrix, i, j, '|');
                            ProcessTop(currentIteration, inputMatrix, matrix, i, j, '7');
                            ProcessTop(currentIteration, inputMatrix, matrix, i, j, 'F');
                        }

                        if (matrix[i][j] == 'J')
                        {
                            ProcessLeft(currentIteration, inputMatrix, matrix, i, j, '-');
                            ProcessLeft(currentIteration, inputMatrix, matrix, i, j, 'L');
                            ProcessLeft(currentIteration, inputMatrix, matrix, i, j, 'F');

                            ProcessTop(currentIteration, inputMatrix, matrix, i, j, '|');
                            ProcessTop(currentIteration, inputMatrix, matrix, i, j, '7');
                            ProcessTop(currentIteration, inputMatrix, matrix, i, j, 'F');
                        }

                        if (matrix[i][j] == '7')
                        {
                            ProcessLeft(currentIteration, inputMatrix, matrix, i, j, '-');
                            ProcessLeft(currentIteration, inputMatrix, matrix, i, j, 'L');
                            ProcessLeft(currentIteration, inputMatrix, matrix, i, j, 'F');

                            ProcessDown(currentIteration, inputMatrix, matrix, i, j, '|');
                            ProcessDown(currentIteration, inputMatrix, matrix, i, j, 'J');
                            ProcessDown(currentIteration, inputMatrix, matrix, i, j, 'L');
                        }

                        if (matrix[i][j] == 'F')
                        {
                            ProcessRight(currentIteration, inputMatrix, matrix, i, j, '-');
                            ProcessRight(currentIteration, inputMatrix, matrix, i, j, 'J');
                            ProcessRight(currentIteration, inputMatrix, matrix, i, j, '7');

                            ProcessDown(currentIteration, inputMatrix, matrix, i, j, '|');
                            ProcessDown(currentIteration, inputMatrix, matrix, i, j, 'J');
                            ProcessDown(currentIteration, inputMatrix, matrix, i, j, 'L');
                        }

                        if (matrix[i][j] == '|')
                        {
                            ProcessTopForVerticalPipe(inputMatrix, currentIteration, matrix, i, j);
                            ProcessDownForVerticalPipe(inputMatrix, currentIteration, matrix, i, j);
                        }

                        if (matrix[i][j] == '-')
                        {
                            ProcessLeftForHorizontalPipe(inputMatrix, currentIteration, matrix, i, j);
                            ProcessRightForHorizontalPipe(inputMatrix, currentIteration, matrix, i, j);
                        }
                    }
                }
            }
            return inputMatrix;
        }

        private static void ProcessRightForHorizontalPipe(List<List<int>> inputMatrix, int currentIteration, List<List<char>> matrix, int i, int j)
        {
            if (IndexesAreWithinBounds(matrix, i, j + 1))
            {
                if ((matrix[i][j + 1] == 'J' || matrix[i][j + 1] == '7' || matrix[i][j + 1] == '-') && inputMatrix[i][j + 1] == 0)
                {
                    inputMatrix[i][j + 1] = currentIteration + 1;
                }
            }
        }

        private static void ProcessLeftForHorizontalPipe(List<List<int>> inputMatrix, int currentIteration, List<List<char>> matrix, int i, int j)
        {
            if (IndexesAreWithinBounds(matrix, i, j - 1))
            {
                if ((matrix[i][j - 1] == 'L' || matrix[i][j - 1] == 'F' || matrix[i][j - 1] == '-') && inputMatrix[i][j - 1] == 0)
                {
                    inputMatrix[i][j - 1] = currentIteration + 1;
                }
            }
        }

        private static void ProcessDownForVerticalPipe(List<List<int>> inputMatrix, int currentIteration, List<List<char>> matrix, int i, int j)
        {
            if (IndexesAreWithinBounds(matrix, i + 1, j))
            {
                if ((matrix[i + 1][j] == 'J' || matrix[i + 1][j] == 'L' || matrix[i + 1][j] == '|') && inputMatrix[i + 1][j] == 0)
                {
                    inputMatrix[i + 1][j] = currentIteration + 1;
                }
            }
        }

        private static void ProcessTopForVerticalPipe(List<List<int>> inputMatrix, int currentIteration, List<List<char>> matrix, int i, int j)
        {
            if (IndexesAreWithinBounds(matrix, i - 1, j))
            {
                if ((matrix[i - 1][j] == '7' || matrix[i - 1][j] == 'F' || matrix[i - 1][j] == '|') && inputMatrix[i - 1][j] == 0)
                {
                    inputMatrix[i - 1][j] = currentIteration + 1;
                }
            }
        }

        public int GetNumberOfSteps(string filePath)
        {
            List<List<int>> zeroMatrix = CreateMatrixWithZeros(filePath);

            int currentIteration = 0;
            List<List<int>> inputMatrix = ProcessStartTile(currentIteration, zeroMatrix, filePath);
            currentIteration += 1;

            while (true)
            {
                if (ThatNumberOccursOnlyOneTime(inputMatrix, currentIteration))
                    break;

                inputMatrix = ProcessEveryPipeCheck(inputMatrix, currentIteration, filePath);
                currentIteration += 1;
            }
            return currentIteration;
        }

        public List<List<int>> GetStepsToFarthestPoint(string filePath)
        {
            List<List<int>> zeroMatrix = CreateMatrixWithZeros(filePath);

            int currentIteration = 0;
            List<List<int>> inputMatrix = ProcessStartTile(currentIteration, zeroMatrix, filePath);

            currentIteration += 1;
            while (true)
            {
                if (ThatNumberOccursOnlyOneTime(inputMatrix, currentIteration))
                    break;

                inputMatrix = ProcessEveryPipeCheck(inputMatrix, currentIteration, filePath);
                currentIteration += 1;
            }
            return inputMatrix;
        }

        public bool ThatNumberOccursOnlyOneTime(List<List<int>> inputMatrix, int currentIteration)
        {
            int counter = 0;

            for (int i = 0; i < inputMatrix.Count; i++)
            {
                for (int j = 0; j < inputMatrix[0].Count; j++)
                {
                    if (inputMatrix[i][j] == currentIteration)
                    {
                        counter += 1;
                    }
                }
            }

            if (counter == 1) return true;

            return false;
        }

        public int GetNumberOfTilesEnclosed(string realFilePath)
        {
            List<List<int>> matrixWithNumbers = GetStepsToFarthestPoint(realFilePath);
            List<List<char>> realMatrix = ReadTextFile(realFilePath);

            int row = matrixWithNumbers.Count;
            int columns = matrixWithNumbers[0].Count;

            int numberOfPointsEnclosed = 0;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (matrixWithNumbers[i][j] == 0 && realMatrix[i][j] != 'S')
                    {
                        numberOfPointsEnclosed += CheckIfPointIsInside(realMatrix, matrixWithNumbers, i, j);
                    }
                }
            }
            return numberOfPointsEnclosed;
        }

        private int CheckIfPointIsInside(List<List<char>> realMatrix, List<List<int>> matrixWithNumbers, int i, int j)
        {
            int columns = realMatrix[0].Count;

            int numberOfCrossings = 0;

            for (int k = j; k < columns; k++)
            {
                if (matrixWithNumbers[i][k] != 0)
                {
                    if (realMatrix[i][k] == '|' || realMatrix[i][k] == 'J' || realMatrix[i][k] == 'L')
                        numberOfCrossings += 1;
                }
            }

            if (numberOfCrossings % 2 == 0) return 0;

            return 1;
        }
    }
}