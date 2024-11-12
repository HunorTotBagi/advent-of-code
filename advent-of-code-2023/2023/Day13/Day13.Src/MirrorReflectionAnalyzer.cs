namespace Day13.Src;

public class MirrorReflectionAnalyzer
{
    public int CalculateVerticalReflectionScore(List<List<char>> matrix)
    {
        return CalculateHorizontalReflectionScore(TransposeMatrix(matrix));
    }

    public int CalculateHorizontalReflectionScore(List<List<char>> grid)
    {
        for (int rowIndex = 1; rowIndex < grid.Count; rowIndex++)
        {
            List<string> topHalf = grid.Take(rowIndex).Select(chars => new string(chars.ToArray())).Reverse().ToList();
            List<string> bottomHalf = grid.Skip(rowIndex).Select(chars => new string(chars.ToArray())).ToList();

            int shortestHalfLength = Math.Min(topHalf.Count, bottomHalf.Count);
            topHalf = topHalf.Take(shortestHalfLength).ToList();
            bottomHalf = bottomHalf.Take(shortestHalfLength).ToList();

            if (Enumerable.SequenceEqual(topHalf, bottomHalf))
                return rowIndex;
        }

        return 0;
    }

    public static List<List<char>> TransposeMatrix(List<List<char>> matrix)
    {
        if (matrix == null || matrix.Count == 0 || matrix[0].Count == 0)
            return new List<List<char>>();

        var rowCount = matrix.Count;
        var columnCount = matrix[0].Count;

        var transposedMatrix = new List<List<char>>(columnCount);
        for (int i = 0; i < columnCount; i++)
        {
            transposedMatrix.Add(new List<char>(rowCount));
        }

        for (var row = 0; row < rowCount; row++)
        {
            for (var col = 0; col < columnCount; col++)
            {
                transposedMatrix[col].Add(matrix[row][col]);
            }
        }

        return transposedMatrix;
    }

    public List<List<List<char>>> ConvertFileToMatrixBlocks(string filePath)
    {
        var matrixBlocks = new List<List<List<char>>>();
        var currentBlock = new List<List<char>>();

        foreach (var line in File.ReadLines(filePath))
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                if (currentBlock.Count > 0)
                {
                    matrixBlocks.Add(currentBlock);
                    currentBlock = new List<List<char>>();
                }
            }
            else
            {
                var charList = new List<char>(line);
                currentBlock.Add(charList);
            }
        }

        if (currentBlock.Count > 0)
        {
            matrixBlocks.Add(currentBlock);
        }

        return matrixBlocks;
    }

    public int CalculateReflectionScore(string filePath)
    {
        List<List<List<char>>> matrices = ConvertFileToMatrixBlocks(filePath);

        var totalScore = 0;

        foreach (var matrix in matrices)
        {
            var verticalScore = CalculateVerticalReflectionScore(matrix);
            var horizontalScore = CalculateHorizontalReflectionScore(matrix);

            totalScore += verticalScore + 100 * horizontalScore;
        }

        return totalScore;
    }
}