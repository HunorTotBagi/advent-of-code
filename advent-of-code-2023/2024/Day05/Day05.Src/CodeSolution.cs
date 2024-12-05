namespace Day05.Src;

public class CodeSolution
{
    public static List<List<int>> ReadFileRules(string filePath)
    {
        var lines = File.ReadAllLines(filePath);

        var listOfNumber = new List<List<int>>();

        foreach (var line in lines)
        {
            var numbers = new List<int>();
            var parts = line.Split("|");

            numbers.Add(int.Parse(parts[0]));
            numbers.Add(int.Parse(parts[1]));

            listOfNumber.Add(numbers);
        }
        return listOfNumber;
    }

    public static List<List<int>> ReadFileRows(string filePath)
    {
        var lines = File.ReadAllLines((filePath));

        var listOfNumbers = new List<List<int>>();

        foreach (var line in lines)
        {
            var numbers = new List<int>();
            var parts = line.Split(",");

            foreach (var part in parts)
            {
                numbers.Add(int.Parse(part));
            }

            listOfNumbers.Add(numbers);
        }
        return listOfNumbers;
    }

    public static bool IsPairInRules(int first, int second, List<List<int>> rules)
    {
        for (var i = 0; i < rules.Count; i++)
        {
            if (rules[i][0] == first && rules[i][1] == second)
            {
                return true;
            }
        }
        return false;

    }

    public static bool IsRowCorrect(List<int> row, List<List<int>> rules)
    {
        for (var i = 0; i < row.Count - 1; i++)
        {
            for (var j = i + 1; j < row.Count; j++)
            {
                if (!IsPairInRules(row[i], row[j], rules))
                    return false;
            }
        }
        return true;
    }

    public static int CountCorrectRows(List<List<int>> rows, List<List<int>> rules)
    {
        var sum = 0;

        foreach (var row in rows)
        {
            if (IsRowCorrect(row, rules))
            {
                sum += row[row.Count / 2];
            }
        }
        return sum;
    }

    public static List<int> SwapWhileNotFound(List<int> row, List<List<int>> rules)
    { 
        while (!IsRowCorrect(row, rules))
        {
            for (var i = 0; i < row.Count - 1; i++)
            {
                for (var j = i + 1; j < row.Count; j++)
                {
                    var boolean = IsPairInRules(row[i], row[j], rules);
                    if (!boolean)
                    {
                        (row[i], row[j]) = (row[j], row[i]);
                    }
                }
            }
        }
        return row;
    }

    public static int CalculateFalseSwapped(List<int> row, List<List<int>> rules)
    {
        while (!IsRowCorrect(row, rules))
        {
            for (var i = 0; i < row.Count - 1; i++)
            {
                for (var j = i + 1; j < row.Count; j++)
                {
                    var boolean = IsPairInRules(row[i], row[j], rules);
                    if (!boolean)
                    {
                        (row[i], row[j]) = (row[j], row[i]);
                    }
                }
            }
        }
        return row[row.Count / 2];
    }

    public static int CountFalseSwappedRows(List<List<int>> rows, List<List<int>> rules)
    {
        var sum = 0;

        foreach (var row in rows)
        {
            if (!IsRowCorrect(row, rules))
            {
                sum += CalculateFalseSwapped(row, rules);
            }
        }

        return sum;
    }
}
