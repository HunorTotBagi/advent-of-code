

namespace AdventOfCode2023.Day18
{
    public class LavaductLagoonCalculator
    {
        public double CalculateAreaUsingShoelaceFormula(List<int> coordinateX, List<int> coordinateY)
        {
            double totalLeft = 0;
            double totalRight = 0;

            for (int i = 0; i < coordinateX.Count - 1; i++)
            {
                totalLeft += coordinateX[i] * coordinateY[i + 1];
                totalRight += coordinateY[i] * coordinateX[i + 1];
            }

            return (Math.Abs(totalLeft - totalRight) / 2);
        }

        public (List<int> cordX, List<int> cordY) ParseCoordinatesFromDigPlan(string filePath)
        {
            (List<char> directions, List<int> numbers, List<string> colorCodes) = ParseDigPlanFromFile(filePath);

            int currentX = 0;
            int currentY = 0;

            List<int> resultX = new List<int> { currentX };
            List<int> resultY = new List<int> { currentY };

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

        public double CalculateTotalBoundaryLength(string filePath)
        {
            (List<char> directions, List<int> numbers, List<string> colorCodes) = ParseDigPlanFromFile(filePath);

            return numbers.Sum();   
        }

        public double CalculateTotalLagoonArea(string filePath)
        {
            (List<int> cordX, List<int> cordY) = ParseCoordinatesFromDigPlan(filePath);

            double result;
            double area = CalculateAreaUsingShoelaceFormula(cordX, cordY);
            double numberOfPointsOnBoundary = CalculateTotalBoundaryLength(filePath);
            
            result = area - numberOfPointsOnBoundary / 2 + 1;

            return result + numberOfPointsOnBoundary;
        }

        public (List<char> directions, List<int> numbers, List<string> colorCodes) ParseDigPlanFromFile(string filePath)
        {
            var directions = new List<char>();
            var numbers = new List<int>();
            var colorCodes = new List<string>();

            foreach (var line in File.ReadLines(filePath))
            {
                var parts = line.Split(' ');

                directions.Add(char.Parse(parts[0]));
                numbers.Add(int.Parse(parts[1]));
                colorCodes.Add(parts[2]);
            }
            return (directions, numbers, colorCodes);
        }
    }
}