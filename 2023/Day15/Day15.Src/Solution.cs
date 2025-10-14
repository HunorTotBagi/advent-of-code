using System.Text.RegularExpressions;

namespace Day15.Src;

public class Solution
{
    public int GetAsciiValue(char inputCharacter)
    {
        return Convert.ToInt32(inputCharacter);
    }

    public int SumOfHashValues(List<string> input)
    {
        int result = 0;
        foreach (string sequence in input)
        {
            result += GetHashValue(sequence);
        }
        return result;
    }

    public int GetBoxIndex(string input)
    {
        return GetHashValue(ExtractStringUpToSymbol(input));
    }

    public string ExtractStringUpToSymbol(string input)
    {
        int indexOfSymbol = 0;

        if (ContainsEqualSymbol(input))
            indexOfSymbol = input.IndexOf('=');

        else if (ContainsMinusSymbol(input))
            indexOfSymbol = input.IndexOf('-');

        return input.Substring(0, indexOfSymbol);
    }

    public int GetHashValue(string input)
    {
        int currentValue = 0;
        foreach (char c in input)
        {
            currentValue += GetAsciiValue(c);
            currentValue *= 17;
            currentValue %= 256;
        }
        return currentValue;
    }

    public bool ContainsEqualSymbol(string input)
    {
        return input.Contains('=');
    }

    public bool ContainsMinusSymbol(string input)
    {
        return input.Contains('-');
    }

    public List<List<string>> InitializeEmptyBoxes()
    {
        List<List<string>> mainList = new List<List<string>>();

        for (int i = 0; i < 256; i++)
        {
            mainList.Add(new List<string>());
        }

        return mainList;
    }

    public List<List<string>> ArrangeLensesInBoxes(List<string> input)
    {
        List<List<string>> lensBoxes = InitializeEmptyBoxes();

        foreach (string stepCommand in input)
        {
            int boxIndex = GetBoxIndex(stepCommand);
            if (ContainsEqualSymbol(stepCommand))
            {
                bool noLens = true;
                for (int i = 0; i < lensBoxes[boxIndex].Count; i++)
                {
                    if (ExtractStringUpToSymbol(lensBoxes[boxIndex][i]) == ExtractStringUpToSymbol(stepCommand))
                    {
                        lensBoxes[boxIndex][i] = stepCommand;
                        noLens = false;
                    }
                }
                if (noLens)
                {
                    lensBoxes[boxIndex].Add(stepCommand);
                }

            }
            if (ContainsMinusSymbol(stepCommand))
            {
                foreach (string item in lensBoxes[boxIndex])
                {
                    if (ExtractStringUpToSymbol(item) == ExtractStringUpToSymbol(stepCommand))
                    {
                        lensBoxes[boxIndex].Remove(item);
                        break;
                    }
                }
            }
        }
        return lensBoxes;
    }

    public int ExtractNumber(string input)
    {
        string pattern = @"[-=](\d+)";

        string number = "";
        Match match = Regex.Match(input, pattern);
        if (match.Success)
        {
            number = match.Groups[1].Value;
        }
        return int.Parse(number);
    }

    public int CalculateTotalFocusingPower(List<string> input)
    {
        List<List<string>> box = ArrangeLensesInBoxes(input);

        int total = 0;

        for (int i = 0; i < box.Count; i++)
        {
            for (int j = 0; j < box[i].Count; j++)
            {
                int realBoxIndex = i + 1;
                int slot = j + 1;
                int focalLength = ExtractNumber(box[i][j]);

                total += realBoxIndex * slot * focalLength;
            }
        }
        return total;
    }

    public List<string> ReadInitializationSequence(string testData0)
    {
        string text = File.ReadAllText(testData0);
        List<string> resultList = new List<string>(text.Split(','));

        return resultList;
    }
}