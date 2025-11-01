namespace Src.Day09;

public class SolutionP1
{
    public static int Calc(string filePath)
    {
        var distances = new Dictionary<(string, string), int>();
        var cities = new HashSet<string>();

        foreach (var line in File.ReadLines(filePath))
        {
            var (from, to, d) = Split(line);
            cities.Add(from);
            cities.Add(to);
            distances[Canonical(from, to)] = d;
        }

        var cityList = cities.ToList();
        var best = int.MaxValue;

        foreach (var perm in Permute(cityList))
        {
            var sum = 0;
            var ok = true;

            for (var i = 0; i < perm.Count - 1; i++)
            {
                if (!distances.TryGetValue(Canonical(perm[i], perm[i + 1]), out var w))
                {
                    ok = false; // missing edge (shouldn’t happen in this puzzle)
                    break;
                }

                sum += w;

                if (sum >= best)
                {
                    ok = false; // prune early
                    break;
                }
            }

            if (ok && sum < best)
                best = sum;
        }

        return best;
    }

    public static (string from, string to, int distance) Split(string input)
    {
        var firstSplit = input.Split(" = ");
        var secondSplit = firstSplit[0].Split(" to ");
        return (secondSplit[0], secondSplit[1], int.Parse(firstSplit[1]));
    }

    public static (string, string) Canonical(string a, string b) =>
        string.CompareOrdinal(a, b) <= 0 ? (a, b) : (b, a);

    public static IEnumerable<List<string>> Permute(List<string> items)
    {
        var arr = items.ToArray();
        foreach (var p in PermuteRec(arr, 0))
            yield return p.ToList();
    }

    public static IEnumerable<string[]> PermuteRec(string[] arr, int start)
    {
        if (start == arr.Length)
        {
            yield return (string[])arr.Clone();
            yield break;
        }

        for (var i = start; i < arr.Length; i++)
        {
            (arr[start], arr[i]) = (arr[i], arr[start]);
            foreach (var p in PermuteRec(arr, start + 1))
                yield return p;
            (arr[start], arr[i]) = (arr[i], arr[start]);
        }
    }
}
