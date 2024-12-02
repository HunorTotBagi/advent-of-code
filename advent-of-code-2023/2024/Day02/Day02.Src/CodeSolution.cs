namespace Day02.Src;

public class CodeSolution
{
    public static List<List<int>> ReadFile(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var listOfLists = new List<List<int>>();

        foreach (var line in lines)
        {
            var row = line.Split(' ').Select(int.Parse).ToList();
            listOfLists.Add(row);
        }

        return listOfLists;
    }

    public static bool ReportIsSafe(List<int> report)
    {
        var increasing = true;
        var decreasing = true;

        for (var i = 0; i < report.Count - 1; i++)
        {
            if (report[i] >= report[i + 1])
                increasing = false;

            if (report[i] <= report[i + 1])
                decreasing = false;

            var difference = Math.Abs(report[i] - report[i + 1]);
            if (difference < 1 || difference > 3)
                return false;
        }

        return increasing || decreasing;
    }

    public static int TotalSafeReports(List<List<int>> input)
    {
        var counter = 0;

        foreach (var list in input)
        {
            if (ReportIsSafe(list))
                counter++;
        }

        return counter;
    }

    public static bool IsSafeWithOneRemoval(List<int> report)
    {
        for (var i = 0; i < report.Count; i++)
        {
            var modifiedReport = report.Where((val, index) => index != i).ToList();
            if (ReportIsSafe(modifiedReport))
            {
                return true;
            }
        }
        return false;
    }

    public static int TotalSafeReportsWithOneRemoval(List<List<int>> input)
    {
        var counter = 0;

        foreach (var list in input)
        {
            if (IsSafeWithOneRemoval(list))
                counter++;
        }

        return counter;
    }
}
