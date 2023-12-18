namespace AdventOfCode2023.Day18
{
    public class LavaductLagoonCalculator
    {
        public long CalculateAreaUsingShoelaceFormula(List<long> coordinateX, List<long> coordinateY)
        {
            long totalLeft = 0;
            long totalRight = 0;

            for (int i = 0; i < coordinateX.Count - 1; i++)
            {
                totalLeft += coordinateX[i] * coordinateY[i + 1];
                totalRight += coordinateY[i] * coordinateX[i + 1];
            }

            return Math.Abs(totalLeft - totalRight) / 2;
        }

        public (List<long> cordX, List<long> cordY) ParseCoordinatesFromDigPlan(List<char> directions, List<long> numbers)
        {
            long currentX = 0;
            long currentY = 0;

            var resultX = new List<long> { currentX };
            var resultY = new List<long> { currentY };

            for (int i = 0; i < directions.Count; i++)
            {
                switch (directions[i])
                {
                    case 'R':
                        currentY += numbers[i];
                        break;
                    case 'D':
                        currentX += numbers[i];
                        break;
                    case 'L':
                        currentY -= numbers[i];
                        break;
                    case 'U':
                        currentX -= numbers[i];
                        break;
                }
                resultX.Add(currentX);
                resultY.Add(currentY);
            }
            return (resultX, resultY);
        }

        public long CalculateTotalBoundaryLength(string filePath)
        {
            var (_, numbers, _) = ParseDigPlanFromFile(filePath);

            return numbers.Sum();
        }

        public long CalculateTotalLagoonArea(List<char> directions, List<long> numbers)
        {
            var (cordinateX, cordinateY) = ParseCoordinatesFromDigPlan(directions, numbers);

            long result;
            long area = CalculateAreaUsingShoelaceFormula(cordinateX, cordinateY);
            long numberOfPointsOnBoundary = numbers.Sum();

            result = area - numberOfPointsOnBoundary / 2 + 1;

            return result + numberOfPointsOnBoundary;
        }

        public (List<char> directions, List<long> numbers, List<string> colorCodes) ParseDigPlanFromFile(string filePath)
        {
            var directions = new List<char>();
            var numbers = new List<long>();
            var colorCodes = new List<string>();

            foreach (var line in File.ReadLines(filePath))
            {
                var parts = line.Split(' ');

                directions.Add(char.Parse(parts[0]));
                numbers.Add(long.Parse(parts[1]));
                colorCodes.Add(parts[2]);
            }
            return (directions, numbers, colorCodes);
        }

        public (List<char> newDirections, List<long> newNumbers) ParseRevisedDigPlan(string filePath)
        {
            var (_, _, colorCodes) = ParseDigPlanFromFile(filePath);

            var newNumbers = new List<long>(colorCodes.Count);
            var newDirections = new List<char>(colorCodes.Count);

            foreach (var colorCode in colorCodes)
            {
                switch (colorCode[7])
                {
                    case '0':
                        newDirections.Add('R');
                        break;
                    case '1':
                        newDirections.Add('D');
                        break;
                    case '2':
                        newDirections.Add('L');
                        break;
                    case '3':
                        newDirections.Add('U');
                        break;
                }
                newNumbers.Add(HexToDecimal(colorCode.Substring(2, 5)));
            }
            return (newDirections, newNumbers);
        }

        private long HexToDecimal(string hexValue)
        {
            return Convert.ToInt32(hexValue, 16);
        }
    }
}