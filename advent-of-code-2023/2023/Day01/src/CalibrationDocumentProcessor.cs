namespace src;

public class CalibrationDocumentProcessor
{
    public List<string> wordNumberList = ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];
    public List<string> reversedWordNumberList = ["eno", "owt", "eerht", "ruof", "evif", "xis", "neves", "thgie", "enin"];
    public List<char> digitCharList = ['1', '2', '3', '4', '5', '6', '7', '8', '9'];

    public string ExtractFirstNumber(string line, List<string> numberWords)
    {
        for (int i = 0; i < line.Length; i++)
        {
            if (char.IsDigit(line[i]))
            {
                return line[i].ToString();
            }
            else
            {
                foreach (var typedValue in numberWords)
                {
                    if (line.Length - i >= typedValue.Length && line.Substring(i, typedValue.Length) == typedValue)
                    {
                        var index = numberWords.IndexOf(typedValue);
                        return digitCharList[index].ToString();
                    }
                }
            }
        }
        return "error";
    }

    public string ReverseString(string inputString)
    {
        return new string(inputString.ToCharArray().Reverse().ToArray());
    }

    public int GetNumber(string input)
    {
        var first = ExtractFirstNumber(input, wordNumberList);
        var last = ExtractFirstNumber(ReverseString(input), reversedWordNumberList);

        return int.Parse(first + last);
    }

    public int SumCalibrationValues(string filePath)
    {
        var totalSum = 0;
        var data = ReadLinesFromFile(filePath);

        foreach (string line in data)
        {
            totalSum += GetNumber(line);
        }
        return totalSum;
    }

    public List<string> ReadLinesFromFile(string filePath)
    {
        return File.ReadAllLines(filePath).ToList();
    }
}
