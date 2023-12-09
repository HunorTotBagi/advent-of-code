
using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace src.day09
{
    public class Sensor
    {
        public List<int> GetNumberListBasedOnIndex(string filePath, int index)
        {
            List<string> data = ReadFileToList(filePath);

            return ExtractNumbers(data[index]);
        }
        public List<int> ExtractNumbers(string inputString)
        {
            string[] numberStrings = inputString.Split(' ');

            List<int> numbers = new List<int>();
            foreach (string numberString in numberStrings)
            {
                if (int.TryParse(numberString, out int number))
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

        public List<List<int>> GetAllDifferencesForThatRow(string filePath, List<int> row)
        {
            List<List<int>> storage = new List<List<int>>();

            storage.Add(row);
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
            return input[0].Last();
        }

        public int CalcFinal(string filePath)
        {
            List<List<int>> data = newExtractor(filePath);
            
            int result = 0;

            for (int i = 0; i < data.Count; i++)
            {
                List<List<int>> holder = GetAllDifferencesForThatRow(filePath, data[i]);

                result += AddStepsToAsALastElement(holder);
            }
            return result;
        }

        public List<List<int>> newExtractor(string filePath)
        {
            List<List<int>> dataList = ReadDataFromFile(filePath);

            return dataList;
        }

        static List<List<int>> ReadDataFromFile(string filePath)
        {
            List<List<int>> dataList = new List<List<int>>();

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            List<int> values = new List<int>();

                            string[] tokens = line.Split(' ');
                            foreach (string token in tokens)
                            {
                                if (int.TryParse(token, out int value))
                                {
                                    values.Add(value);
                                }
                                else
                                {
                                    // Handle the case where a non-integer value is encountered.
                                    Console.WriteLine("Invalid data format: " + token);
                                }
                            }

                            dataList.Add(values);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, e.g., file not found, access denied, etc.
                Console.WriteLine("Error reading file: " + ex.Message);
            }

            return dataList;
        }
    }
}
