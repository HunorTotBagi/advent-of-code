
using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace src.day09
{
    public class Sensor
    {
        public List<long> GetNumberListBasedOnIndex(string filePath, int index)
        {
            List<string> data = ReadFileToList(filePath);

            return ExtractNumbers(data[index]);
        }
        public List<long> ExtractNumbers(string inputString)
        {
            string[] numberStrings = inputString.Split(' ');

            List<long> numbers = new List<long>();
            foreach (string numberString in numberStrings)
            {
                if (long.TryParse(numberString, out long number))
                {
                    numbers.Add(number);
                }
            }

            return numbers;
        }


        public List<string> ReadFileToList(string filePath)
        {
            List<string> linesList = new List<string>();

            string[] lines = File.ReadAllLines(filePath);
            linesList.AddRange(lines);

            return linesList;
        }

        public List<long> GetNextRowCalculation(List<long> stringRow)
        {
            List<long> result = new List<long>();

            for (int i = 0; i < stringRow.Count - 1; i++)
            {
                long diff = stringRow[i + 1] - stringRow[i];
                result.Add(diff);
            }

            return result;
        }

        public List<List<long>> GetAllDifferencesForThatRow(string filePath, int index)
        {
            List<List<long>> storage = new List<List<long>>();

            List<long> row = GetNumberListBasedOnIndex(filePath, index);

            storage.Add(row);
            long rowSum = row.Sum();

            while (rowSum != 0)
            {

                storage.Add(GetNextRowCalculation(storage[^1]));
                rowSum = storage[^1].Sum();
            }

            return storage;
        }

        public long AddStepsToAsALastElement(List<List<long>> input)
        {
            input[^1].Add(0);

            for (int i = input.Count - 1; i >= 1; i--)
            {
                input[i - 1].Add(input[i - 1].Last() + input[i].Last());
            }
            return input[0].Last();
        }

        public long CalcFinal(string filePath)
        {
            List<string> data = ReadFileToList(filePath);
            long result = 0;

            for (int i = 0; i < data.Count; i++)
            {
                List<List<long>> holder = GetAllDifferencesForThatRow(filePath, i);

                result += AddStepsToAsALastElement(holder);
            }
            return result;
        }
    }
}
