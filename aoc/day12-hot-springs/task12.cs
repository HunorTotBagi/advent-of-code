
using System;
using System.Diagnostics.Metrics;
using System.Globalization;
using Microsoft.VisualBasic;

namespace src.day12_hot_springs
{
    public class HotSpring
    {
        public (List<string>, List<List<int>>) ReadFile(string filePath)
        {
            List<string> stringsList = new List<string>();
            List<List<int>> intsList = new List<List<int>>();
            string[] lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var parts = line.Split(' ');
                stringsList.Add(parts[0]);
                List<int> intValues = parts[1].Split(',').Select(int.Parse).ToList();
                intsList.Add(intValues);
            }
            return (stringsList, intsList);
        }

        static List<string> GenerateCombinations(int n)
        {
            List<string> result = new List<string>();
            char[] combination = new char[n];
            GenerateCombinationHelper(combination, 0, result);
            return result;
        }

        static void GenerateCombinationHelper(char[] combination, int index, List<string> result)
        {
            if (index == combination.Length)
            {
                result.Add(new string(combination));
                return;
            }

            combination[index] = '.';
            GenerateCombinationHelper(combination, index + 1, result);

            combination[index] = '#';
            GenerateCombinationHelper(combination, index + 1, result);
        }

        static int CountOccurrences(string input, char target)
        {
            int count = 0;

            foreach (char c in input)
            {
                if (c == target)
                {
                    count++;
                }
            }

            return count;
        }

        static List<string> FindMatchingStrings(string pattern, List<string> stringsToCheck)
        {
            List<string> matchingStrings = new List<string>();

            foreach (var str in stringsToCheck)
            {
                if (IsMatchingPattern(pattern, str))
                {
                    matchingStrings.Add(str);
                }
            }

            return matchingStrings;
        }

        static bool IsMatchingPattern(string pattern, string str)
        {
            if (pattern.Length != str.Length)
            {
                return false;
            }

            for (int i = 0; i < pattern.Length; i++)
            {
                if (pattern[i] != '?' && pattern[i] != str[i])
                {
                    return false;
                }
            }

            return true;
        }

        public List<string> SelectStringsWithMatching(string inputString, List<int> numbers)
        {
            var result = new List<string>();

            List<string> input = GenerateCombinations(inputString.Length);

            int count = numbers.Sum();

            foreach (string s in input)
            {
                if (CountOccurrences(s, '#') == count)
                {
                    result.Add(s);
                }
            }

            return FindMatchingStrings(inputString, result);
        }

        static List<string> FindValid(List<string> strings, int[] condition)
        {
            List<string> result = new List<string>();
            foreach (string dobar in strings)
            {
                if (IsValid(dobar, condition))
                {
                    result.Add(dobar);
                }
            }

            return result;
        }

        private static bool IsValid(string dobar, int[] condition)
        {
            List<int> lista = new List<int>();
            int counter = 0;
            foreach (char c in dobar)
            {
                if (c == '#')
                {
                    counter++;
                }
                else
                {
                    if (counter != 0)
                    {
                        lista.Add(counter);
                    }
                    counter = 0;
                }
            }

            if (counter != 0 )
            {
                lista.Add(counter);
            }

            if (lista.ToList().SequenceEqual(condition))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int FinalComibinations(string input, int[] numbers)
        {
            List<string> help = SelectStringsWithMatching(input, numbers.ToList());
            List<string> result = FindValid(help, numbers);

            return result.Count;  // Return the count of valid combinations, not the filtered list count
        }

        public int GetFinalAnswer(string filePath)
        {
            int result = 0;
            (List<string> stringResult, List<List<int>> intResult) = ReadFile(filePath);

            for (int i = 0; i < stringResult.Count; i++)
            {
                result += FinalComibinations(stringResult[i], intResult[i].ToArray());
            }

            return result;
        }
    }
}