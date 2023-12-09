
using System;
using System.Linq;
using System.Reflection;

namespace src.day09
{
    public class Sensor
    {
        public List<ulong> GetNumberListBasedOnIndex(string filePath, ulong index)
        {
            List<string> data = ReadFileToList(filePath);

            string row = data[(int)index];

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

        public List<List<ulong>> GetAllDifferencesForThatRow(string filePath, ulong index)
        {
            List<List<ulong>> storage = new List<List<ulong>>();

            List<ulong> row = GetNumberListBasedOnIndex(filePath, index);

            storage.Add(row);

            while (storage[storage.Count - 1][2] != 0)
            {

                storage.Add(GetNextRowCalculation(storage[storage.Count - 1]));
            }

            return storage;
        }
    }
}
