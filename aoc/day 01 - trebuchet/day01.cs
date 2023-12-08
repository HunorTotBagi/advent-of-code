namespace aoc
{
    public class Document
    {
        public List<string> typedList = new List<string> { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        public List<string> typedListReverse = new List<string> { "eno", "owt", "eerht", "ruof", "evif", "xis", "neves", "thgie", "enin" };

        public List<char> numbersList = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public string GetFirstNumberFromLeft(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    for (int j = 0; j < numbersList.Count; j++)
                    {
                        if (input[i] == numbersList[j])
                        {
                            return input[i].ToString();
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < typedList.Count; j++)
                    {
                        int length = typedList[j].Length;

                        if (input.Length - i >= typedList[j].Length)
                        {
                            if (input.Substring(i, length) == typedList[j])
                            {
                                return numbersList[j].ToString();
                            }
                        }

                    }
                }
            }

            return "error";
        }

        public string CalculateFirstReverse(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    for (int j = 0; j < numbersList.Count; j++)
                    {
                        if (input[i] == numbersList[j])
                        {
                            return input[i].ToString();
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < typedListReverse.Count; j++)
                    {
                        int length = typedListReverse[j].Length;

                        if (input.Length - i >= typedListReverse[j].Length)
                        {
                            if (input.Substring(i, length) == typedListReverse[j])
                            {
                                return numbersList[j].ToString();
                            }
                        }

                    }
                }
            }

            return "error";
        }

        public string ReverseString(string inputString)
        {
            char[] charArray = inputString.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public int GetNumber(string input)
        {
            string first = GetFirstNumberFromLeft(input);
            string last = CalculateFirstReverse(ReverseString(input));

            return int.Parse(first + last);
        }

        public int SummAllUp(string filePath)
        {
            List<string> data = ReadFileToList(filePath);

            int result = 0;

            foreach (string line in data)
            {
                result += GetNumber(line);
            }

            return result;
        }

        public List<string> ReadFileToList(string filePath)
        {
            List<string> linesList = new List<string>();

            string[] lines = File.ReadAllLines(filePath);
            linesList.AddRange(lines);

            return linesList;
        }
    }
}