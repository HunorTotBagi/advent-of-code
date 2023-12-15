

using System.Text.RegularExpressions;

namespace advent_of_code_LATEST
{
    public class Hunor
    {
        public int ConvertToAscii(char input)
        {
            int asciiCode = Convert.ToInt32(input);
            return asciiCode;
        }

        public int Final(List<string> input)
        {
            int result = 0;
            foreach (string s in input)
            {
                result += HASHAlgo(s);
            }
            return result;
        }

        public static string ExtractUpToSign(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            int indexOfEqual = input.IndexOf('=');
            int indexOfDash = input.IndexOf('-');

            // Check if neither '=' nor '-' is found
            if (indexOfEqual == -1 && indexOfDash == -1)
            {
                return input;
            }

            // If one of them is not found, use the other
            if (indexOfEqual == -1)
            {
                return input.Substring(0, indexOfDash);
            }
            if (indexOfDash == -1)
            {
                return input.Substring(0, indexOfEqual);
            }

            // If both are found, use the smallest index
            int minIndex = Math.Min(indexOfEqual, indexOfDash);
            return input.Substring(0, minIndex);
        }

        public int GetBoxIndex(string input)
        {
            return HASHAlgo(ExtractUpToSign(input));
        }

        public int HASHAlgo(string input)
        {
            int currentValue = 0;
            foreach (char c in input)
            {
                currentValue += ConvertToAscii(c);
                currentValue *= 17;
                currentValue = currentValue % 256;
            }

            return currentValue;
        }

        public List<string> ReadFile(string testData0)
        {
            string text = File.ReadAllText(testData0);
            List<string> resultList = new List<string>(text.Split(','));

            return resultList;
        }

        public bool HaveEqual(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            return input.Contains('=');
        }

        public bool HaveMinus(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            return input.Contains('-');
        }

        public List<List<string>> CreateEmptyBox()
        {
            List<List<string>> mainList = new List<List<string>>();

            // Initialize each index from 0 to 255
            for (int i = 0; i < 256; i++)
            {
                mainList.Add(new List<string>());
            }

            return mainList;
        }

        public List<List<string>> PutInBox(List<string> input)
        {
            List<List<string>> box = CreateEmptyBox();

            foreach (string inputItem in input)
            {
                int boxIndex = GetBoxIndex(inputItem);
                if (HaveEqual(inputItem))
                {
                    bool noLens = true;
                    for (int i = 0; i < box[boxIndex].Count; i++)
                    {
                        if (ExtractUpToSign(box[boxIndex][i]) == ExtractUpToSign(inputItem))
                        {
                            box[boxIndex][i] = inputItem;
                            noLens = false;
                        }
                    }
                    if (noLens)
                    {
                        box[boxIndex].Add(inputItem);
                    }

                }
                if (HaveMinus(inputItem))
                {
                    foreach (string item in box[boxIndex])
                    {
                        if (ExtractUpToSign(item) == ExtractUpToSign(inputItem))
                        {
                            box[boxIndex].Remove(item);
                            break;
                        }
                    }
                }
            }

            return box;
        }

        public int FinalResult(List<string> input)
        {
            List<List<string>> box = PutInBox(input);

            int total = 0;

            for (int i = 0;i < box.Count;i++)
            {
                for (int j = 0;j < box[i].Count; j++)
                {
                    int realBoxIndex = i + 1;
                    int slot = j + 1;
                    int focalLength = ExtractNumber(box[i][j]);

                    total += realBoxIndex * slot * focalLength;
                }
            }

            return total;
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
    }
}