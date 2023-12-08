namespace test.day03_gear_ratios
{
    public class Schematic
    {
        public List<string> ExtendSchematicWithDots(string filePath)
        {
            List<string> matrix = ReadFileToList(filePath);

            int rows = matrix.Count;
            int cols = matrix[0].Length;

            List<string> extendedMatrix = new List<string>(rows + 2);

            extendedMatrix.Add(new string('.', cols + 2));

            for (int i = 0; i < rows; i++)
            {
                extendedMatrix.Add("." + matrix[i] + ".");
            }

            extendedMatrix.Add(new string('.', cols + 2));

            return extendedMatrix;
        }

        public int SummUpAllNumbersInSchematic(string filePath)
        {
            List<string> documents = ReadFileToList(filePath);

            return SumNumberGroupsInGrid(documents);
        }

        static int SumNumberGroupsInGrid(List<string> grid)
        {
            int sum = 0;

            foreach (var row in grid)
            {
                string[] numberGroups = row.Split(new[] { '*', '.', '+', '$', '#' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var group in numberGroups)
                {
                    if (int.TryParse(group, out int groupValue))
                    {
                        sum += groupValue;
                    }
                }
            }
            return sum;
        }

        public bool IsTheNumberFirst(List<string> extendedSchema, int i, int j)
        {
            if (extendedSchema[i - 1][j] == '.' &&
                extendedSchema[i - 1][j - 1] == '.' &&
                extendedSchema[i][j - 1] == '.' &&
                extendedSchema[i + 1][j - 1] == '.' &&
                extendedSchema[i + 1][j] == '.')
            {
                return true;
            }
            return false;
        }

        public bool IsTheNumberMiddle(List<string> extendedSchema, int i, int j)
        {
            if (extendedSchema[i - 1][j] == '.' && extendedSchema[i + 1][j] == '.')
            {
                return true;
            }
            return false;
        }

        public bool IsTheNumberLast(List<string> extendedSchema, int i, int j)
        {
            if (extendedSchema[i - 1][j] == '.' &&
                extendedSchema[i - 1][j + 1] == '.' &&
                extendedSchema[i][j + 1] == '.' &&
                extendedSchema[i + 1][j + 1] == '.' &&
                extendedSchema[i + 1][j] == '.')
            {
                return true;
            }
            return false;
        }

        public int IsAPartNumber(List<string> extendedSchema)
        {
            int rows = extendedSchema.Count;
            int columns = extendedSchema[0].Length;

            for (int i = 1; i < rows - 1; i++)
            {
                for (int j = 1; j < columns - 1; j++)
                {
                    if (IsTheNumberFirst(extendedSchema, i, j))
                    {
                        int k = 0;
                        while (char.IsDigit(extendedSchema[i][j + 1]))
                        {
                            if (IsTheNumberMiddle(extendedSchema, i, j + k + 1))
                            {
                                return 1;
                            }
                            else
                            {
                                return 0;
                            }
                        }
                    }
                }
            }
            return 1;
        }

        public List<int> GetLenghtOfAllNumbers(string filePath)
        {
            List<string> data = ReadFileToList(filePath);
            int rows = data.Count;
            int columns = data[0].Length;
            int counter = 0;
            List<int> result = new List<int>();

            for (int i = 1; i < rows - 1; i++)
            {
                for (int j = 1; j < columns - 1; j++)
                {
                    if (char.IsDigit(data[i][j]))
                    {
                        counter += 1;
                    }
                    else
                    {
                        if (counter != 0)
                        {
                            result.Add(counter);
                        }
                        counter = 0;
                    }
                }
            }

            return result;
        }

        public bool Dimension1(string filePath, int i, int j)
        {
            List<string> matrix = ReadFileToList(filePath);

            if (IsTheNumberFirst(matrix, i, j) && IsTheNumberLast(matrix, i, j))
            {
                return true;
            }
            return false;
        }

        public bool Dimension2(string filePath, int i, int j)
        {
            List<string> matrix = ReadFileToList(filePath);

            if (IsTheNumberFirst(matrix, i, j - 1) && IsTheNumberLast(matrix, i, j))
            {
                return true;
            }
            return false;
        }

        public bool Dimension3(string filePath, int i, int j)
        {
            List<string> matrix = ReadFileToList(filePath);

            if (IsTheNumberFirst(matrix, i, j - 2) && IsTheNumberMiddle(matrix, i, j - 1) && IsTheNumberLast(matrix, i, j))
            {
                return true;
            }
            return false; ;
        }

        public int GetFinalResult(string filePath)
        {
            List<string> linesList = ReadFileToList(filePath);

            int row = linesList.Count();
            int col = linesList[0].Length;

            int totalSum = SummUpAllNumbersInSchematic(filePath);

            int counter = 0;

            for (int i = 1; i < row - 1; i++)
            {
                for (int j = 1; j < col - 1; j++)
                {
                    if (char.IsDigit(linesList[i][j]))
                    {
                        counter++;

                        if (!char.IsDigit(linesList[i][j + 1]))
                        {
                            if (counter == 1 && Dimension1(filePath, i, j))
                            {
                                totalSum -= int.Parse(linesList[i][j].ToString());
                                counter = 0;
                            }

                            if (counter == 2 && Dimension2(filePath, i, j))
                            {
                                totalSum -= int.Parse(linesList[i][j].ToString());
                                counter = 0;
                            }

                            if (counter == 3 && Dimension3(filePath, i, j))
                            {
                                totalSum = totalSum - int.Parse(linesList[i][j].ToString());
                                counter = 0;
                            }
                            counter = 0;
                        }
                    }
                }
            }
            return totalSum;
        }

        public List<string> ReadFileToList(string filePath)
        {
            List<string> linesList = new List<string>();

            string[] lines = File.ReadAllLines(filePath);
            linesList.AddRange(lines);

            return linesList;
        }

    }
}
