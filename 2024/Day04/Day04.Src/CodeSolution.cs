namespace Day04.Src;

public class CodeSolution
{
    private const char X = 'X';
    private const char M = 'M';
    private const char A = 'A';
    private const char S = 'S';

    public static List<List<char>> ReadFile(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var result = new List<List<char>>();

        foreach (var line in lines)
        {
            var row = new List<char>();

            foreach (var character in line)
            {
                row.Add(character);
            }

            result.Add(row);
        }

        return result;
    }

    public static int Horizontal(List<List<char>> matrix)
    {
        var counter = 0;

        for (var i = 0; i < matrix.Count; i++)
        {
            for (var j = 0; j < matrix[i].Count - 3;j++)
            {
                if (matrix[i][j] == X && matrix[i][j+1] == M && matrix[i][j+2] == A && matrix[i][j+3] == S)
                {
                    counter++;
                }
            }
        }

        return counter;
    }

    public static int HorizontalBackwards(List<List<char>> matrix)
    {
        var counter = 0;

        for (var i = 0; i < matrix.Count; i++)
        {
            for (var j = 0; j < matrix[i].Count - 3; j++)
            {
                if (matrix[i][j] == S && matrix[i][j + 1] == A && matrix[i][j + 2] == M && matrix[i][j + 3] == X)
                {
                    counter++;
                }
            }
        }

        return counter;
    }

    public static int Vertical(List<List<char>> matrix)
    {
        var counter = 0;

        for (var i = 0; i < matrix[0].Count; i++)
        {
            for (var j = 0; j < matrix.Count - 3; j++)
            {
                if (matrix[j][i] == X && matrix[j+1][i] == M && matrix[j+2][i] == A && matrix[j+3][i] == S)
                {
                    counter++;
                }
            }
        }

        return counter;
    }

    public static int VerticalBackwards(List<List<char>> matrix)
    {
        var counter = 0;

        for (var i = 0; i < matrix[0].Count; i++)
        {
            for (var j = 0; j < matrix.Count - 3; j++)
            {
                if (matrix[j][i] == S && matrix[j + 1][i] == A && matrix[j + 2][i] == M && matrix[j + 3][i] == X)
                {
                    counter++;
                }
            }
        }

        return counter;
    }

    public static int Diagonal1(List<List<char>> matrix)
    {
        var counter = 0;

        for (var i = 0; i < matrix.Count - 3; i++)
        {
            for (var j = 0; j < matrix[i].Count - 3; j++)
            {
                if (matrix[i][j] == X && matrix[i + 1][j + 1] == M && matrix[i + 2][j + 2] == A && matrix[i+3][j + 3] == S)
                {
                    counter++;
                }
            }
        }

        return counter;
    }

    public static int Diagonal1Backwards(List<List<char>> matrix)
    {
        var counter = 0;

        for (var i = 0; i < matrix.Count - 3; i++)
        {
            for (var j = 0; j < matrix[i].Count - 3; j++)
            {
                if (matrix[i][j] == S && matrix[i + 1][j + 1] == A && matrix[i + 2][j + 2] == M && matrix[i + 3][j + 3] == X)
                {
                    counter++;
                }
            }
        }

        return counter;
    }

    public static int Diagonal2(List<List<char>> matrix)
    {
        var counter = 0;

        for (var i = 0; i < matrix.Count - 3; i++)
        {
            for (var j = 0; j < matrix[i].Count - 3; j++)
            {
                if (matrix[i+3][j] == X && matrix[i + 2][j + 1] == M && matrix[i + 1][j + 2] == A && matrix[i][j + 3] == S)
                {
                    counter++;
                }
            }
        }

        return counter;
    }

    public static int Diagonal2Backwards(List<List<char>> matrix)
    {
        var counter = 0;

        for (var i = 0; i < matrix.Count - 3; i++)
        {
            for (var j = 0; j < matrix[i].Count - 3; j++)
            {
                if (matrix[i + 3][j] == S && matrix[i + 2][j + 1] == A && matrix[i + 1][j + 2] == M && matrix[i][j + 3] == X)
                {
                    counter++;
                }
            }
        }

        return counter;
    }

    public static int GetAllXmas(List<List<char>> input)
    {
        return Horizontal(input) + HorizontalBackwards(input) + Vertical(input) + VerticalBackwards(input) + 
               Diagonal1(input) + Diagonal1Backwards(input) + Diagonal2(input) + Diagonal2Backwards(input);
    }

    public static int XMas1(List<List<char>> matrix)
    {
        var counter = 0;

        for (var i = 0; i < matrix.Count - 2; i++)
        {
            for (var j = 0; j < matrix[i].Count - 2; j++)
            {
                if (matrix[i][j] == M && matrix[i][j + 2] == S &&
                    matrix[i + 1][j+1] == A &&
                    matrix[i + 2][j]== M && matrix[i + 2][j+2] == S)
                {
                    counter++;
                }
            }
        }

        return counter;
    }

    public static int XMas2(List<List<char>> matrix)
    {
        var counter = 0;

        for (var i = 0; i < matrix.Count - 2; i++)
        {
            for (var j = 0; j < matrix[i].Count - 2; j++)
            {
                if (matrix[i][j] == M && matrix[i][j + 2] == M &&
                    matrix[i + 1][j + 1] == A &&
                    matrix[i + 2][j] == S && matrix[i + 2][j + 2] == S)
                {
                    counter++;
                }
            }
        }

        return counter;
    }

    public static int XMas3(List<List<char>> matrix)
    {
        var counter = 0;

        for (var i = 0; i < matrix.Count - 2; i++)
        {
            for (var j = 0; j < matrix[i].Count - 2; j++)
            {
                if (matrix[i][j] == S && matrix[i][j + 2] == S &&
                    matrix[i + 1][j + 1] == A &&
                    matrix[i + 2][j] == M && matrix[i + 2][j + 2] == M)
                {
                    counter++;
                }
            }
        }

        return counter;
    }

    public static int XMas4(List<List<char>> matrix)
    {
        var counter = 0;

        for (var i = 0; i < matrix.Count - 2; i++)
        {
            for (var j = 0; j < matrix[i].Count - 2; j++)
            {
                if (matrix[i][j] == S && matrix[i][j + 2] == M &&
                    matrix[i + 1][j + 1] == A &&
                    matrix[i + 2][j] == S && matrix[i + 2][j + 2] == M)
                {
                    counter++;
                }
            }
        }

        return counter;
    }

    public static int Result(List<List<char>> input)
    {
        return XMas1(input) + XMas2(input) + XMas3(input) + XMas4(input);
    }
}
