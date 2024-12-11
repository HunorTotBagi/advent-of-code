namespace Day11.Src;

public class CodeSolution
{
    private static readonly Dictionary<(ulong, ulong), ulong> Memo = new();

    public static List<ulong> ReadFile(string filePath)
    {
        var lines = File.ReadAllLines(filePath);

        var result = new List<ulong>();

        foreach (var ch in lines[0].Split(" "))
        {
            result.Add(ulong.Parse(ch));
        }
        return result;
    }

    private static ulong CountStones(ulong stone, ulong blinks)
    {
        if (blinks == 0) return 1;
        if (Memo.ContainsKey((stone, blinks)))
            return Memo[(stone, blinks)];

        ulong result = 0;

        if (stone == 0)
            result = CountStones(1, blinks - 1);

        else if (stone.ToString().Length % 2 == 0)
        {
            var (first, second) = SplitEvenNumber(stone);
            result = CountStones(first, blinks - 1) + CountStones(second, blinks - 1);
        }
        else
        {
            var multiplied = stone * 2024;
            result = CountStones(multiplied, blinks - 1);
        }

        Memo[(stone, blinks)] = result;
        return result;
    }

    public static (ulong first, ulong second) SplitEvenNumber(ulong input)
    {
        var stringRep = input.ToString();
        var length = stringRep.Length;

        var first = stringRep.Substring(0, length/2);
        var second = stringRep.Substring( length / 2, length/2);

        return (ulong.Parse(first), RemoveLeadingZeros(second));
    }

    public static ulong RemoveLeadingZeros(string input)
    {
        var array = input.ToCharArray();
        ulong result = 0;

        if (input[0] != 0)
            return ulong.Parse(input);

        for (var i = 0; i < array.Length - 1; i++)
        {
            if (array[i] == 0 && array[i+1] != 0)
            {
                var helper = "";
                for (var j = i + 1; j < array.Length; j++)
                    helper += input[j];

                result = ulong.Parse(helper);
            }
        }
        return result;
    }

    public static ulong CalculateStoneCountAfterBlinks(List<ulong> input, ulong blinks)
    {
        ulong totalStones = 0;

        foreach (var stone in input)
            totalStones += CountStones(stone, blinks);

        return totalStones;
    }
}
