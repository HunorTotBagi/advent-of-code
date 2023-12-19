using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day19
{
    public class WorkflowProcessor
    {
        public (string key, List<string> comparisons) ExtractWorkflowRules(string input)
        {
            var startIndex = input.IndexOf('{');
            var key = input[..startIndex];

            var endIndex = input.IndexOf('}', startIndex);
            var insideBraces = input.Substring(startIndex + 1, endIndex - startIndex - 1);
            var comparisons = new List<string>(insideBraces.Split(','));

            return (key, comparisons);
        }

        public List<int> ExtractRatingNumbers(string input)
        {
            var cleanedInput = Regex.Replace(input, "[{}xmas=]", "");
            var numberStrings = cleanedInput.Split(',');
            var numbers = new List<int>();

            foreach (var str in numberStrings)
            {
                numbers.Add(int.Parse(str));
            }
            return numbers;
        }

        public (List<string> keys, List<List<string>> comparisons) CreateWorkflowMappings(string input)
        {
            var (road, _) = ReadFileIn(input);

            var keys = new List<string>();
            var comparisons = new List<List<string>>();

            foreach (var item in road)
            {
                var (key, comparison) = ExtractWorkflowRules(item);

                keys.Add(key);
                comparisons.Add(comparison);
            }
            return (keys, comparisons);
        }

        public (string first, char second, int numbers, string nextPath) ProcessComparisonRule(string input)
        {
            var splitChar = input.Contains('<') ? '<' : '>';
            var firstSplit = input.Split(splitChar);

            var partBeforeSplit = firstSplit[0];
            var secondSplit = firstSplit[1].Split(':');

            var numberPart = int.Parse(secondSplit[0]);
            var stringAfterColon = secondSplit[1];

            return (partBeforeSplit, splitChar, numberPart, stringAfterColon);
        }

        public string MainLogic(List<string> workflowRules, List<int> partRatings)
        {
            var xmasIndices = new Dictionary<string, int>
                {
                    { "x", 0 },
                    { "m", 1 },
                    { "a", 2 },
                    { "s", 3 }
                };

            foreach (var logic in workflowRules)
            {
                if (!logic.Contains(':'))
                {
                    return logic;
                }

                var (categoryIndices, sign, number, nextPath) = ProcessComparisonRule(logic);

                var index = xmasIndices[categoryIndices];
                bool condition = sign == '<' ? partRatings[index] < number : partRatings[index] > number;

                if (condition)
                {
                    return nextPath;
                }
            }
            return "not possible";
        }

        public string DeterminePartOutcome(List<int> inputNumbers, List<string> keys, List<List<string>> comparisons)
        {
            var start = "in";

            var comparisonMap = new Dictionary<string, List<string>>();
            for (int i = 0; i < keys.Count; i++)
            {
                comparisonMap[keys[i]] = comparisons[i];
            }

            var iterationCount = 0;
            while (start != "A" && start != "R")
            {
                if (comparisonMap.ContainsKey(start))
                {
                    start = MainLogic(comparisonMap[start], inputNumbers);
                }
                iterationCount++;
            }
            return start;
        }

        public int ComputeAcceptedPartsSum(string testData0)
        {
            var acceptedPartsSum = 0;
            var (_, parts) = ReadFileIn(testData0);
            var (keys, comparisons) = CreateWorkflowMappings(testData0);

            foreach (var numbers in parts)
            {
                var inputNumbers = ExtractRatingNumbers(numbers);
                var result = DeterminePartOutcome(inputNumbers, keys, comparisons);

                if (result == "A")
                    acceptedPartsSum += inputNumbers.Sum();
            }
            return acceptedPartsSum;
        }

        public (List<string> road, List<string> parts) ReadFileIn(string filePath)
        {
            var road = new List<string>();
            var parts = new List<string>();

            foreach (var line in File.ReadLines(filePath))
            {
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("{"))
                {
                    if (line.StartsWith("{"))
                    {
                        parts.Add(line);
                    }
                    continue;
                }
                road.Add(line);
            }
            return (road, parts);
        }
    }
}