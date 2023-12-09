
using System;
using System.Linq;
using System.Reflection;

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
            List<ulong> result = new List<ulong>();

            // Split the input string based on whitespace
            string[] numberStrings = input.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            // Convert each string to ulong and add to the result list
            foreach (string numberString in numberStrings)
            {
                if (ulong.TryParse(numberString, out ulong number))
                {
                    result.Add(number);
                }
                else
                {
                    Console.WriteLine($"Failed to parse '{numberString}' as ulong.");
                }
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

            while (SumOfLastRow(storage) != 0)
            {

                storage.Add(GetNextRowCalculation(storage[storage.Count - 1]));
            }

            return storage;
        }

        private static ulong SumOfLastRow(List<List<ulong>> storage)
        {
            ulong result = 0;
            for (int i = 0; i < storage.Count; i++)
            {
                for (int j = 0; j < storage[i].Count; j++)
                {
                    result += storage[i][j];    
                }
            }

            return result;
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
