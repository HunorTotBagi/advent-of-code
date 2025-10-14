namespace Day14.Src;

public class Solution
{
    public static List<List<char>> LoadMatrixFromFile(string filePath)
    {
        var lines = File.ReadLines(filePath);
        var grid = new List<List<char>>();

        foreach (var line in lines)
        {
            var row = new List<char>(line.ToCharArray());
            grid.Add(row);
        }
        return grid;
    }

    public static List<List<char>> SlideRocksNorthInColumn(List<List<char>> matrix, int column)
    {
        var rowCount = matrix.Count;

        for (var i = 1; i < rowCount; i++)
        {
            if (matrix[i][column] == 'O')
            {
                var currentRow = i;

                while (currentRow > 0 && matrix[currentRow - 1][column] == '.')
                {
                    matrix[currentRow - 1][column] = 'O';
                    matrix[currentRow][column] = '.';
                    currentRow--;
                }
            }
        }
        return matrix;
    }

    public static int CalculateTotalLoad(List<List<char>> matrix)
    {
        var totalLoad = 0;
        var rowCount = matrix.Count;

        for (var col = 0; col < matrix[0].Count; col++)
            matrix = SlideRocksNorthInColumn(matrix, col);

        for (var row = 0; row < rowCount; row++)
        {
            for (var col = 0; col < matrix[row].Count; col++)
            {
                if (matrix[row][col] == 'O')
                    totalLoad += rowCount - row;
            }
        }
        return totalLoad;
    }
}