namespace Day01.Src;

public class CodeSolution
{
    public static (List<int> firstList, List<int> secondList) ReadLocationIdsFromFile(string filePath)
    {
        var lines = File.ReadAllLines(filePath);

        var leftList = new List<int>();
        var rightList = new List<int>();

        foreach (var line in lines)
        {
            var parts = line.Split("   ");
            leftList.Add(int.Parse(parts[0]));
            rightList.Add(int.Parse(parts[1]));
        }

        return (leftList, rightList);
    }

    public static List<int> SortLocationIds(List<int> list)
    {
       return list.OrderBy(x => x).ToList();
    }

    public static List<int> CalculateLocationDistance(List<int> list1, List<int> list2)
    {
        var result = new List<int>();

        for (var i = 0; i < list1.Count; i++)
        {
            result.Add(Math.Abs(list1[i] - list2[i]));
        }

        return result;
    }

    public static int SumLocationDistances(List<int> distances)
    {
        return distances.Sum();
    }

    public static int CalculateSimilarityScore(List<int> list1, List<int> list2)
    {
        var similarityScore = 0;

        foreach (var locationId in list1)
        {
            var locationIdCount = list2.Count(x => x == locationId);
            similarityScore += locationId * locationIdCount;
        }

        return similarityScore;
    }
}
