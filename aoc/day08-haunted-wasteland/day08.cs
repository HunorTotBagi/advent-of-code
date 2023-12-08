namespace src.day08_haunted_wasteland
{
    public class Network
    {
        public List<string> ReadFileToList(string filePath)
        {
            List<string> linesList = new List<string>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                linesList.AddRange(lines);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return linesList;
        }

        public string GetDirections(string filePath)
        {
            string firstLine = File.ReadLines(filePath).First();
            return firstLine;
        }

        public List<List<string>> GetNodes(string filePath)
        {
            List<List<string>> result = new List<List<string>>();
            List<string> data = ReadFileToList(filePath);

            for (int i = 2; i < data.Count; i++)
            {
                List<string> helper = new List<string>
                {
                    data[i].Substring(0, 3),
                    data[i].Substring(7, 3),
                    data[i].Substring(12, 3)
                };

                result.Add(helper);
            }

            return result;
        }

        public string GetNextDestionation(int index, string input, string filePath)
        {
            List<List<string>> data = GetNodes(filePath);

            if (input == "L")
            {
                return data[index][1];
            }
            else
            {
                return data[index][2];
            }
        }

        public string GetFinalLocation(string nextIteration, string filePath)
        {
            List<List<string>> data = GetNodes(filePath);
            string directions = GetDirections(filePath);

            for (int i = 0; i < directions.Length; i++)
            {
                string direction = char.ToString(directions[i]);

                for (int j = 0; j < data.Count; j++)
                {
                    if (nextIteration == data[j][0])
                    {
                        nextIteration = GetNextDestionation(j, direction, filePath);
                        break;
                    }
                }
            }

            return nextIteration;
        }

        public int GetNumberOfSteps(string filePath)
        {
            List<List<string>> data = GetNodes(filePath);

            string startLocation = "AAA";
            string destinationEnd = "ZZZ";

            string directions = GetDirections(filePath);

            int length = directions.Length;
            string currentLocation = startLocation;

            int iterations = 1;
            while (currentLocation != destinationEnd)
            {
                if (iterations == 1)
                {
                    currentLocation = GetFinalLocation(startLocation, filePath);
                }
                else
                {
                    currentLocation = GetFinalLocation(currentLocation, filePath);
                }

                if (currentLocation == destinationEnd)
                {
                    break;
                }

                iterations++;
            }

            int result = length * iterations;
            return result;
        }

        public int GetNumberOfStepsPart2(string startLocation, string filePath)
        {
            List<List<string>> data = GetNodes(filePath);

            string directions = GetDirections(filePath);

            int length = directions.Length;
            string currentLocation = startLocation;

            int iterations = 1;
            while (currentLocation[2] != 'Z')
            {
                if (iterations == 1)
                {
                    currentLocation = GetFinalLocation(startLocation, filePath);
                }
                else
                {
                    currentLocation = GetFinalLocation(currentLocation, filePath);
                }

                if (currentLocation[2] == 'Z')
                {
                    break;
                }

                iterations++;
            }

            int result = length * iterations;
            return result;
        }

        public ulong GetGCD(ulong a, ulong b)
        {
            while (b != 0)
            {
                ulong temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public ulong GetLCM(ulong firstNumber, ulong secondNumber)
        {
            return firstNumber * secondNumber / GetGCD(firstNumber, secondNumber);
        }

        public List<string> GetNodesThatEndOnA(string filePath)
        {
            List<List<string>> data = GetNodes(filePath);

            List<string> result = new List<string>();

            for (int i = 0; i < data.Count; i++)
            {
                if (data[i][0][2] == 'A')
                {
                    result.Add(data[i][0]);
                }
            }

            return result;
        }

        public List<int> GetIndividualNumbers(string filePath)
        {
            List<string> data = GetNodesThatEndOnA(filePath);
            List<int> result = new List<int>();

            foreach (string node in data)
            {
                result.Add(GetNumberOfStepsPart2(node, filePath));
            }

            return result;
        }

        public ulong GetLCMFinalAnswer(string filePath)
        {
            List<int> numbers = GetIndividualNumbers(filePath);

            ulong lcmResult = (ulong)numbers[0];

            for (int i = 1; i < numbers.Count; i++)
            {
                lcmResult = (ulong)GetLCM(lcmResult, (ulong)numbers[i]);
            }

            return lcmResult;
        }
    }
}