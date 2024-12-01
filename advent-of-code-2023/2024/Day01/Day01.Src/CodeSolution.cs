namespace Day01.Src;

public class CodeSolution
{
    public (int[] array1, int[] array2) GetArraysFromFile(string filePath)
    {
        var lines = File.ReadAllLines(filePath);

        var leftNumbers = new int[lines.Length];
        var rightNumbers = new int[lines.Length];

        for (var i = 0; i < lines.Length; i++)
        {
            var parts = lines[i].Split([' ', '\t'], StringSplitOptions.RemoveEmptyEntries);

            leftNumbers[i] = int.Parse(parts[0]);
            rightNumbers[i] = int.Parse(parts[1]);
        }

        return (leftNumbers, rightNumbers);
    }

    public int[] SortTheArray(int[] array)
    {
       return array.OrderBy(x => x).ToArray();
    }

    public int[] CalculateDistance(int[] arr1, int[] arr2)
    {
        var result = new int[arr1.Length];

        for (var i = 0; i < arr1.Length; i++)
        {
            result[i] = Math.Abs(arr1[i] - arr2[i]);
        }

        return result;
    }

    public int SumItUp(int[] arr)
    {
        return arr.Sum();
    }

    public object GetSimilarityScore(int[] array1, int[] array2)
    {
        var result = 0;

        foreach (var number in array1)
        {
            var occurrence = array2.Count(x => x == number);
            result += number * occurrence;
        }

        return result;
    }
}
