
using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace src.day09
{
    public class Sensor
    {
        public List<ulong> GetNumberListBasedOnIndex(string filePath, int index)
        {
            List<string> data = ReadFileToList(filePath);

            string row = data[index];

            List<ulong> result = new List<ulong>();

            result = ExtractNumbers(row);

            return result;
        }
        public List<ulong> ExtractNumbers(string input)
        {
            List<ulong> ulongList = new List<ulong>();
            Regex regex = new Regex(@"[+-]?\d+(\.\d+)?");

            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                if (ulong.TryParse(match.Value, out ulong result))
                {
                    ulongList.Add(result);
                }
                // If you want to handle potential overflow or other errors, you can add appropriate logic here.
            }

            return ulongList;
        }


        public List<string> ReadFileToList(string filePath)
        {
            List<string> linesList = new List<string>();

            string[] lines = File.ReadAllLines(filePath);
            linesList.AddRange(lines);

            return linesList;
        }

        public List<ulong> GetNextRowCalculation(List<ulong> stringRow)
        {
            List<ulong> result = new List<ulong>();

            for (int i = 0; i < stringRow.Count - 1; i++)
            {
                ulong diff = stringRow[i + 1] - stringRow[i];
                result.Add(diff);
            }

            return result;
        }

        public List<List<ulong>> GetAllDifferencesForThatRow(string filePath, int index)
        {
            List<List<ulong>> storage = new List<List<ulong>>();

            List<ulong> row = GetNumberListBasedOnIndex(filePath, index);

            storage.Add(row);

            while (storage[storage.Count - 1].Last() != 0)
            {

                storage.Add(GetNextRowCalculation(storage[storage.Count - 1]));
            }

            return storage;
        }

        public ulong AddStepsToAsALastElement(List<List<ulong>> input)
        {
            // Add a new zero to the end of the last list
            input[input.Count - 1].Add(0);

            // Iterate over the lists from the bottom up
            for (int i = input.Count - 1; i >= 1; i--)
            {
                input[i - 1].Add(input[i - 1].Last() + input[i].Last());

            }

            return input[0].Last();
        }

        public ulong CalcFinal(string filePath)
        {
            List<string> data = ReadFileToList(filePath);
            ulong result = 0;

            for (int i = 0; i < data.Count; i++)
            {
                List<List<ulong>> holder = GetAllDifferencesForThatRow(filePath, i);

                var asd = AddStepsToAsALastElement(holder);
                result += asd;
            }

            return result;
        }
    }
}
