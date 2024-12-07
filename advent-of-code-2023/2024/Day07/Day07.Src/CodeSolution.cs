namespace Day07.Src;

public class CodeSolution
{
    public static (List<long> first, List<List<long>> second) ReadCalibrationFile(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var number = new List<long>();
        var data = new List<List<long>>();

        foreach (var line in lines)
        {
            var parts = line.Split(": ");
            number.Add(long.Parse(parts[0]));

            var newList = new List<long>();
            var newParts = parts[1].Split(" ");

            foreach (var element in newParts)
                newList.Add(long.Parse(element));
            data.Add(newList);
        }
        return (number, data);
    }

    public static List<string> GenerateOperatorCombinations(long n)
    {
        var result = new List<string>();
        GenerateOperatorCombinationsHelper("", n, result);
        return result;
    }

    public static void GenerateOperatorCombinationsHelper(string current, long remaining, List<string> result)
    {
        if (remaining == 0)
        {
            result.Add(current);
            return;
        }

        GenerateOperatorCombinationsHelper(current + "+", remaining - 1, result);
        GenerateOperatorCombinationsHelper(current + "*", remaining - 1, result);
    }

    public static bool IsValidCalibration(long number, List<long> input)
    {
        var length = input.Count - 1;
        var symbolCombinations = GenerateOperatorCombinations(length);

        foreach (var combination in symbolCombinations)
        {
            var answer = input[0];
            for (var i = 0; i < combination.Length; i++)
            {
                if (combination[i] == '+')
                    answer += input[i + 1];

                if (combination[i] == '*')
                    answer *= input[i + 1];
            }

            if (answer == number)
                return true;
        }
        return false;
    }

    public static long CalculateCalibration(List<long> numbers, List<List<long>> inputs)
    {
        long result = 0;

        for (var i = 0; i < numbers.Count; i++)
            if (IsValidCalibration(numbers[i], inputs[i]))
                result += numbers[i];

        return result;
    }

    public static List<string> GenerateOperatorCombinationsWithConcatenation(long n)
    {
        var result = new List<string>();
        GenerateOperatorCombinationsHelperWithConcatenation("", n, result);
        return result;
    }

    public static void GenerateOperatorCombinationsHelperWithConcatenation(string current, long remaining, List<string> result)
    {
        if (remaining == 0)
        {
            result.Add(current);
            return;
        }

        GenerateOperatorCombinationsHelperWithConcatenation(current + "+", remaining - 1, result);
        GenerateOperatorCombinationsHelperWithConcatenation(current + "*", remaining - 1, result);
        GenerateOperatorCombinationsHelperWithConcatenation(current + "|", remaining - 1, result);
    }

    public static bool IsValidCalibrationWithConcatenation(long number, List<long> input)
    {
        var length = input.Count - 1;
        var symbolCombinations = GenerateOperatorCombinationsWithConcatenation(length);

        foreach (var combination in symbolCombinations)
        {
            var answer = input[0];
            for (var i = 0; i < combination.Length; i++)
            {
                if (combination[i] == '+')
                    answer += input[i + 1];

                if (combination[i] == '*')
                    answer *= input[i + 1];

                if (combination[i] == '|')
                {
                    long numberLength = input[i + 1].ToString().Length;
                    answer *= (long)Math.Pow(10, numberLength);
                    answer += input[i + 1];
                }
            }

            if (answer == number)
                return true;
        }
        return false;
    }

    public static long CalculateCalibrationWithConcatenation(List<long> numbers, List<List<long>> inputs)
    {
        long result = 0;

        for (var i = 0; i < numbers.Count; i++)
            if (IsValidCalibrationWithConcatenation(numbers[i], inputs[i]))
                result += numbers[i];

        return result;
    }
}
