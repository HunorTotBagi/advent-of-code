



using System.Collections.Generic;

namespace src.day14
{
    public class Hunor
    {
        public int Calculate(List<List<char>> matrix)
        {
            for (int i = 0; i < matrix[0].Count; i++)
            {
                matrix = MoveOneRowNorth(matrix, i);
            }

            int total = 0;

            int len = matrix.Count;



            for (int j = 0; j < matrix[0].Count; j++)
            {
                for (int i = 0; i < matrix.Count; i++)
                {
                    if (matrix[i][j] == 'O')
                    {
                        total += len - i;
                    }
                }
            }
            return total;
        }

        public List<List<char>> MoveOneRowNorth(List<List<char>> matrix, int column)
        {
            int limit = 0;
            for (int i = 0; i < matrix.Count; i++)
            {
                if (matrix[i][column] == '#')
                {
                    limit = i;
                }
                if (matrix[i][column] == 'O')
                {
                    for (int j = i - 1; j >= limit; j--)
                    {
                        if (matrix[j][column] == '.')
                        {
                            matrix[j][column] = 'O';
                            matrix[j + 1][column] = '.';
                        }
                    }
                }
            }
            return matrix;
        }



        public List<List<char>> ReadFileIntoList(string filePath)
        {
            List<List<char>> grid = new List<List<char>>();

            // Read each line from the file
            foreach (var line in File.ReadLines(filePath))
            {
                // Convert the line to a List<char>
                List<char> row = new List<char>(line.ToCharArray());

                // Add the row to the grid
                grid.Add(row);
            }

            return grid;
        }

        static List<List<char>> RotateMatrix90Degrees(List<List<char>> matrix)
        {
            int rows = matrix.Count;
            int cols = matrix[0].Count;
            List<List<char>> rotated = new List<List<char>>();

            for (int j = 0; j < cols; j++)
            {
                List<char> newRow = new List<char>();
                for (int i = rows - 1; i >= 0; i--)
                {
                    newRow.Add(matrix[i][j]);
                }
                rotated.Add(newRow);
            }

            return rotated;
        }

        public List<List<char>> CycleRotate(List<List<char>> matrix, int numberOfCycles)
        {
            for(int i = 0; i < numberOfCycles; i++)
            {
                for (int j = 0; j < matrix[0].Count; j++)
                {
                    matrix = MoveOneRowNorth(matrix, j);
                }

                matrix = RotateMatrix90Degrees(matrix);
                for (int j = 0 ; j < matrix[0].Count; j++)
                {
                    matrix = MoveOneRowNorth(matrix, j);
                }

                matrix = RotateMatrix90Degrees(matrix);
                for (int j = 0; j < matrix[0].Count; j++)
                {
                    matrix = MoveOneRowNorth(matrix, j);
                }

                matrix = RotateMatrix90Degrees(matrix);
                for (int j = 0; j < matrix[0].Count; j++)
                {
                    matrix = MoveOneRowNorth(matrix, j);
                }
                matrix = RotateMatrix90Degrees(matrix);

            }
            return matrix;
        }

        static (int i, int j) CheckForEquivalentElements(List<List<List<char>>> outerList)
        {
            for (int i = 0; i < outerList.Count; i++)
            {
                for (int j = i + 1; j < outerList.Count; j++)
                {
                    if (outerList[i].Equals(outerList[j]))
                    {
                        return (i,j);
                    }
                }
            }
            return (66,66);
        }

        public int OnWhichCycleItRepeats(List<List<char>> matrix)
        {
            List<List<List<char>>> seen = new List<List<List<char>>>();
            List<List<List<char>>> array = new List<List<List<char>>>();

            int iter = 0;
            List<List<char>> grid = new List<List<char>>();

            array.Add(grid);

            while (true)
            {
                iter++;
                grid = CycleRotate(matrix, iter);

                if (GridIsInSeen(seen, grid))
                {
                    break;
                }
                seen.Add(grid);
                array.Add(grid);
                
            }

            //int first = GetFirstindex(array, grid);
            //grid = array[(1000000000 - first) % (iter - first) + first];

            //return Calculate(grid);

            return iter;
        }

        private static bool GridIsInSeen(List<List<List<char>>> seen, List<List<char>> grid)
        {
            for (int i = 0; i < seen.Count; i++) 
            {
                if (seen[i] == grid)
                {
                    return true;
                }
            }
            return false;
        }

        private static int GetFirstindex(List<List<List<char>>> array, List<List<char>> grid)
        {
            for (int i = 0; i < array.Count; i++)
            {
                if (array[i] == grid)
                {
                    return i;
                }
            }
            return -5;
        }

        //private string ConvertGridToString(List<List<char>> grid)
        //{
        //    return string.Join("\n", grid.Select(row => new string(row.ToArray())));
        //}

    }
}
