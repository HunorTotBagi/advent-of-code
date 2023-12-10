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
                        return new List<int> { i, j };
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

        public List<List<int>> CreateZeroMatrixForPipe(string filePath)
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

        public List<List<int>> CallForS(int currentIteration, List<List<int>> inputMatrix, string filePath)
        {
            List<List<char>> matrix = ReadTextFile(filePath);

            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix[0].Count; j++)
                {
                    if (matrix[i][j] == 'S')
                    {
                        AddLeft(currentIteration, inputMatrix, matrix, i, j, 'F');
                        AddRight(currentIteration, inputMatrix, matrix, i, j, '-');
                        //AddTop(currentIteration, inputMatrix, matrix, i, j, '|');
                        //AddDown(currentIteration, inputMatrix, matrix, i, j, '|');
                        break;
                    }
                }
            }
            return inputMatrix;
        }

        private static bool IndexesInMatrixBound(List<List<char>> matrix, int i, int j)
        {
            int rows = matrix.Count;
            int columns = matrix[0].Count;
            if (0 <= i && i < rows && 0 <= j && j < columns)
            {
                return true;
            }
            return false;
        }

        private static void AddLeft(int currentIteration, List<List<int>> inputMatrix, List<List<char>> matrix, int i, int j, char pipe)
        {
            if (IndexesInMatrixBound(matrix, i, j - 1))
            {
                if (matrix[i][j - 1] == pipe && inputMatrix[i][j - 1] == 0)
                {
                    inputMatrix[i][j - 1] = currentIteration + 1;
                }
            }
        }

        private static void AddRight(int currentIteration, List<List<int>> inputMatrix, List<List<char>> matrix, int i, int j, char pipe)
        {
            if (IndexesInMatrixBound(matrix, i, j + 1))
            {
                if (matrix[i][j + 1] == pipe && inputMatrix[i][j + 1] == 0)
                {
                    inputMatrix[i][j + 1] = currentIteration + 1;
                }
            }
        }

        private static void AddTop(int currentIteration, List<List<int>> inputMatrix, List<List<char>> matrix, int i, int j, char pipe)
        {
            if (IndexesInMatrixBound(matrix, i - 1, j))
            {
                if (matrix[i - 1][j] == pipe && inputMatrix[i - 1][j] == 0)
                {
                    inputMatrix[i - 1][j] = currentIteration + 1;
                }
            }
        }

        private static void AddDown(int currentIteration, List<List<int>> inputMatrix, List<List<char>> matrix, int i, int j, char pipe)
        {
            if (IndexesInMatrixBound(matrix, i + 1, j))
            {
                if (matrix[i + 1][j] == pipe && inputMatrix[i + 1][j] == 0)
                {
                    inputMatrix[i + 1][j] = currentIteration + 1;
                }
            }
        }

        public List<List<int>> CallEveryPipeCheck(List<List<int>> inputMatrix, int currentIteration, string filePath)
        {
            List<List<char>> matrix = ReadTextFile(filePath);

            int rows = matrix.Count;
            int columns = matrix[0].Count;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (inputMatrix[i][j] == currentIteration)
                    {
                        if (matrix[i][j] == 'L')
                        {
                            AddRight(currentIteration, inputMatrix, matrix, i, j, '-');
                            AddRight(currentIteration, inputMatrix, matrix, i, j, 'J');
                            AddRight(currentIteration, inputMatrix, matrix, i, j, '7');
                            AddTop(currentIteration, inputMatrix, matrix, i, j, '|');
                            AddTop(currentIteration, inputMatrix, matrix, i, j, '7');
                            AddTop(currentIteration, inputMatrix, matrix, i, j, 'F');
                        }

                        if (matrix[i][j] == 'J')
                        {
                            AddLeft(currentIteration, inputMatrix, matrix, i, j, '-');
                            AddLeft(currentIteration, inputMatrix, matrix, i, j, 'L');
                            AddLeft(currentIteration, inputMatrix, matrix, i, j, 'F');
                            AddTop(currentIteration, inputMatrix, matrix, i, j, '|');
                            AddTop(currentIteration, inputMatrix, matrix, i, j, '7');
                            AddTop(currentIteration, inputMatrix, matrix, i, j, 'F');
                        }

                        if (matrix[i][j] == '7')
                        {
                            AddLeft(currentIteration, inputMatrix, matrix, i, j, '-');
                            AddLeft(currentIteration, inputMatrix, matrix, i, j, 'L');
                            AddLeft(currentIteration, inputMatrix, matrix, i, j, 'F');
                            AddDown(currentIteration, inputMatrix, matrix, i, j, '|');
                            AddDown(currentIteration, inputMatrix, matrix, i, j, 'J');
                            AddDown(currentIteration, inputMatrix, matrix, i, j, 'L');
                        }

                        if (matrix[i][j] == 'F')
                        {
                            AddRight(currentIteration, inputMatrix, matrix, i, j, '-');
                            AddRight(currentIteration, inputMatrix, matrix, i, j, 'J');
                            AddRight(currentIteration, inputMatrix, matrix, i, j, '7');
                            AddDown(currentIteration, inputMatrix, matrix, i, j, '|');
                            AddDown(currentIteration, inputMatrix, matrix, i, j, 'J');
                            AddDown(currentIteration, inputMatrix, matrix, i, j, 'L');
                        }

                        if (matrix[i][j] == '|')
                        {
                            if (IndexesInMatrixBound(matrix, i - 1, j))
                            {
                                if ((matrix[i - 1][j] == '7' || matrix[i - 1][j] == 'F' || matrix[i - 1][j] == '|') && inputMatrix[i - 1][j] == 0)
                                {
                                    inputMatrix[i - 1][j] = currentIteration + 1;
                                }
                            }
                            // Top


                            // Down
                            if (IndexesInMatrixBound(matrix, i + 1, j))
                            {
                                if ((matrix[i + 1][j] == 'J' || matrix[i + 1][j] == 'L' || matrix[i + 1][j] == '|') && inputMatrix[i + 1][j] == 0)
                                {
                                    inputMatrix[i + 1][j] = currentIteration + 1;
                                }
                            }


                        }

                        if (matrix[i][j] == '-')
                        {
                            // Left
                            if (IndexesInMatrixBound(matrix, i, j - 1))
                            {
                                if ((matrix[i][j - 1] == 'L' || matrix[i][j - 1] == 'F' || matrix[i][j - 1] == '-') && inputMatrix[i][j - 1] == 0)
                                {
                                    inputMatrix[i][j - 1] = currentIteration + 1;
                                }
                            }

                            // Right
                            if (IndexesInMatrixBound(matrix, i, j + 1))
                            {
                                if ((matrix[i][j + 1] == 'J' || matrix[i][j + 1] == '7' || matrix[i][j + 1] == '-') && inputMatrix[i][j + 1] == 0)
                                {
                                    inputMatrix[i][j + 1] = currentIteration + 1;
                                }
                            }


                        }
                    }
                }
            }

            return inputMatrix;
        }

        public int GetNumberOfSteps(string filePath)
        {
            List<List<int>> zeroMatrix = CreateZeroMatrixForPipe(filePath);

            int currentIteration = 0;
            List<List<int>> inputMatrix = CallForS(currentIteration, zeroMatrix, filePath);

            currentIteration += 1;
            while (true)
            {
                if (ThatNumberIsNotInMatrix(inputMatrix, currentIteration))
                {
                    break;
                }
                inputMatrix = CallEveryPipeCheck(inputMatrix, currentIteration, filePath);
                currentIteration += 1;


            }
            return currentIteration;
        }

        public List<List<int>> GetTraversedPath(string filePath)
        {
            List<List<int>> zeroMatrix = CreateZeroMatrixForPipe(filePath);

            int currentIteration = 0;
            List<List<int>> inputMatrix = CallForS(currentIteration, zeroMatrix, filePath);

            currentIteration += 1;
            while (true)
            {
                if (ThatNumberIsNotInMatrix(inputMatrix, currentIteration))
                {
                    break;
                }
                inputMatrix = CallEveryPipeCheck(inputMatrix, currentIteration, filePath);
                currentIteration += 1;


            }
            return inputMatrix;
        }

        public bool ThatNumberIsNotInMatrix(List<List<int>> inputMatrix, int currentIteration)
        {
            int row = inputMatrix.Count;
            int column = inputMatrix[0].Count;

            int counter = 0;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (inputMatrix[i][j] == currentIteration)
                    {
                        counter += 1;
                    }
                }
            }

            if (counter == 1)
            {
                return true;
            }
            return false;
        }

        public int GetNumberOfTilesEnclosed(string realFilePath)
        {
            List<List<int>> matrixWithNumbers = GetTraversedPath(realFilePath);
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
                    {
                        numberOfCrossings += 1;
                    }
                }
            }

            if (numberOfCrossings % 2 == 0)
            {
                return 0;
            }
            return 1;
        }
    }
}
