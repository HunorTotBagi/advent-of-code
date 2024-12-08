namespace Day08.Src;

public class CodeSolution
{
    public static List<List<char>> ReadGridFromFile(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var grid = new List<List<char>>();

        foreach (var line in lines)
        {
            var lineChars = new List<char>();
            foreach (var letter in line)
            {
                lineChars.Add(letter);
            }
            grid.Add(lineChars);
        }
        return grid;
    }

    public static bool IsPointInBounds(List<int> antenna1, List<List<char>> antenna2)
    {
        return 0 <= antenna1[0] && antenna1[0] < antenna2.Count && 0 <= antenna1[1] && antenna1[1] < antenna2[0].Count;
    }

    public static HashSet<char> GetUniqueAntennas(List<List<char>> input)
    {
        var result = new HashSet<char>();

        foreach (var row in input)
        {
            for (var j = 0; j < input[0].Count; j++)
            {
                if (row[j] == '.') continue;
                result.Add(row[j]);
            }
        }
        return result;
    }

    public static List<List<int>> FindAllAntennaPositions(char character, List<List<char>> input)
    {
        var result = new List<List<int>>();

        for (var i = 0; i < input.Count; i++)
        {
            for (var j = 0; j < input[0].Count; j++)
            {
                if (input[i][j] == character)
                    result.Add([i,j]);
            }
        }
        return result;
    }

    public static List<List<int>> GenerateAntinodePositions(List<int> first, List<int> second)
    {
        var left = Math.Abs(first[0] - second[0]);
        var right = Math.Abs(first[1] - second[1]);
        var result = new List<List<int>>();

        if (first[1] < second[1])
        {
            result.Add([ first[0] - left, first[1] - right ]);
            result.Add([ second[0] + left, second[1] + right ]);
        }
        else
        {
            result.Add([ second[0] + left, second[1] - right ]);
            result.Add([ first[0] - left, first[1] + right ]);
        }
        return result;
    }

    public static int Calculate(List<List<char>> input)
    {
        var antinodePositions = new HashSet<(int, int)>();
        var uniqueAntennaFrequencies = GetUniqueAntennas(input);

        foreach (var character in uniqueAntennaFrequencies)
        {
            var indexesOfChar = FindAllAntennaPositions(character, input);

            for (var i = 0; i < indexesOfChar.Count; i++)
            {
                for (var j = i + 1; j < indexesOfChar.Count; j++)
                {
                    var antidotes = GenerateAntinodePositions(indexesOfChar[i], indexesOfChar[j]);

                    foreach (var antidote in antidotes)
                        if (IsPointInBounds(antidote, input))
                            antinodePositions.Add((antidote[0], antidote[1]));
                }
            }
        }
        return antinodePositions.Count;
    }

    public static List<List<int>> GenerateAntinodePositionsOverload(List<int> first, List<int> second, List<List<char>> input)
    {
        var left = Math.Abs(first[0] - second[0]);
        var right = Math.Abs(first[1] - second[1]);
        var res = new List<List<int>> { first, second };

        if (first[1] < second[1])
        {
            var i = 1;
            while (IsPointInBounds([ first[0] - i * left, first[1] - i * right ], input))
            {
                res.Add([first[0] - i*left, first[1] - i*right]);
                i++;
            }

            var j = 1;
            while (IsPointInBounds([ second[0] + j * left, second[1] + j * right ], input))
            {
                res.Add([ second[0] + j*left, second[1] + j*right]);
                j++;
            }

        }
        else
        {
            var i = 1;
            while (IsPointInBounds([ second[0] + i * left, second[1] - i * right], input))
            {
                res.Add([ second[0] + i*left, second[1] - i*right ]);
                i++;
            }

            var j = 1;
            while (IsPointInBounds([ first[0] - j * left, first[1] + j * right ], input))
            {
                res.Add([ first[0] - j*left, first[1] + j*right ]);
                j++;
            }
        }
        return res;
    }

    public static int CalculateAdvanced(List<List<char>> input)
    {
        var antiNodes = new HashSet<(int, int)>();
        var uniqueCharacters = GetUniqueAntennas(input);

        foreach (var character in uniqueCharacters)
        {
            var indexesOfChar = FindAllAntennaPositions(character, input);

            for (var i = 0; i < indexesOfChar.Count; i++)
            {
                for (var j = i + 1; j < indexesOfChar.Count; j++)
                {
                    var antidotes = GenerateAntinodePositionsOverload(indexesOfChar[i], indexesOfChar[j], input);

                    foreach (var ad in antidotes)
                    {
                        if (IsPointInBounds(antidotes[0], input))
                            antiNodes.Add((ad[0], ad[1]));
                    }
                }
            }
        }
        return antiNodes.Count;
    }
}
