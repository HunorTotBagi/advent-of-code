
using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace src.day09
{
    public class Sensor
    {
        public List<int> GetNextRowCalculation(List<int> stringRow)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < stringRow.Count - 1; i++)
            {
                int diff = stringRow[i + 1] - stringRow[i];
                result.Add(diff);
            }
            return result;
        }

        public List<List<int>> GetAllDifferencesForThatRow(List<int> row)
        {
            List<List<int>> storage = new List<List<int>> { row };

            int rowSum = row.Sum();

            while (rowSum != 0)
            {
                storage.Add(GetNextRowCalculation(storage[^1]));
                rowSum = storage[^1].Sum();
            }

            return storage;
        }


        public int AddStepsToAsALastElement(List<List<int>> input)
        {
            input[^1].Add(0);

            for (int i = input.Count - 1; i >= 1; i--)
            {
                input[i - 1].Add(input[i - 1].Last() + input[i].Last());
            }

            return input[0][^1];
        }

        public int CalcFinal(string filePath)
        {
            List<List<int>> data = newExtractor(filePath);

            int result = 0;

            for (int i = 0; i < data.Count; i++)
            {
                List<List<int>> holder = GetAllDifferencesForThatRow(data[i]);

                result += AddStepsToAsALastElement(holder);
            }
            return result;
        }

        public List<List<int>> newExtractor(string filePath)
        {
            List<List<int>> result = ReadFile(filePath);

            return result;
        }

        static List<List<int>> ReadFile(string filePath)
        {
            List<List<int>> resultList = new List<List<int>>();

            foreach (string line in File.ReadLines(filePath))
            {
                List<int> row = line.Split(' ')
                                   .Select(value => int.TryParse(value, out int intValue) ? intValue : 0)
                                   .ToList();

                resultList.Add(row);
            }

            return resultList;
        }
    }
}
