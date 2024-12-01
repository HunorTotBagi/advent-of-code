namespace Day01.Src;

public class CodeSolution
{
    public (int[] arr1, int[] arr2) GetArraysFromFile()
    {
        var filePath = "C:\\Users\\htotbagi\\Downloads\\advent-of-code\\advent-of-code-2023\\2024\\Day01\\Day01.Src\\Data\\testData.txt";
        var lines = File.ReadAllLines(filePath);

        // Create the arrays
        int[] leftNumbers = new int[lines.Length];
        int[] rightNumbers = new int[lines.Length];

        // Process each line
        for (int i = 0; i < lines.Length; i++)
        {
            // Split the line into two parts
            string[] parts = lines[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            // Parse the numbers and assign to the arrays
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

        for (var i = 0; i < array1.Length; i++)
        {
            var occurrence = array2.Count(x => x == array1[i]);
            result += array1[i] * occurrence;
        }

        return result;
    }
}
