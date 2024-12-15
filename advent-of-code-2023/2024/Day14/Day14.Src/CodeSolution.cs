namespace Day14.Src;

public class CodeSolution
{
    public static (List<List<int>> positions, List<List<int>> veloc) ReadFile(string filePath)
    {
        var lines = File.ReadAllLines(filePath);

        var positions = new List<List<int>>();
        var velocities = new List<List<int>>();

        foreach (var line in lines)
        {
            var parts = line.Split(' ');

            var partsPosition = parts[0].Split("p=");
            var partsPositionComma = partsPosition[1].Split(",");
            var position = new List<int>();

            position.Add(int.Parse(partsPositionComma[0]));
            position.Add(int.Parse(partsPositionComma[1]));

            positions.Add(position);

            var partsVelocity = parts[1].Split("v=");
            var partsVelocityComma = partsVelocity[1].Split(",");
            var velocity = new List<int>();

            velocity.Add(int.Parse(partsVelocityComma[0]));
            velocity.Add(int.Parse(partsVelocityComma[1]));

            velocities.Add(velocity);
        }
        return (positions, velocities);
    }

    public static List<int> MoveRobotOneSecond(int boundX, int boundY, List<int> pos, List<int> vel)
    {
        var x = pos[0];
        var y = pos[1];

        var xVel = vel[0];
        var yVel = vel[1];

        if (x + xVel > boundX)
            x = x + xVel - boundX;
        else if (x + xVel < 0)
            x = x + xVel + boundX;
        else
            x += xVel;

        if (y + yVel < 0)
            y = y + yVel + boundY;
        else if (y + yVel > boundY)
            y = y + yVel - boundY;
        else
            y += yVel;

        return [x,y];
    }

    private static int Modulo(int x, int m) =>
        (x % m + m) % m;

    public static List<List<int>> Calculate(int seconds, int boundX, int boundY, List<List<int>> pos, List<List<int>> vel)
    {
        var result = new List<List<int>>();

        for (var i = 0; i < pos.Count; i++)
        {
            var px = pos[i][0];
            var py = pos[i][1];
            var vx = vel[i][0];
            var vy = vel[i][1];

            var x = Modulo((px + vx * seconds),boundX);
            var y = Modulo((py + vy * seconds),boundY);

            result.Add([x,y]);
        }
        return result;
    }

    public static int Quadrants(int boundX, int boundY, List<List<int>> positions)
    {
        var xHalf = boundX / 2;
        var yHalf = boundY / 2;

        int q1 = 0, q2 = 0, q3 = 0, q4 = 0;

        foreach (var position in positions)
        {
            if (position[0] < xHalf && position[1] < yHalf)
                q1++;
            else if (position[0] > xHalf && position[1] < yHalf)
                q2++;
            else if (position[0] > xHalf && position[1] > yHalf)
                q3++;
            else if (position[0] < xHalf && position[1] > yHalf)
                q4++;
        }

        return q1 * q2 * q3 * q4;
    }

    public static int CalculateSecondPart(int boundX, int boundY, List<List<int>> pos, List<List<int>> vel)
    {
        var minimum = double.PositiveInfinity;
        var bestIteration = 0;

        for (var seconds = 0; seconds < boundX * boundY; seconds++)
        {
            var result = new List<List<int>>();

            for (var i = 0; i < pos.Count; i++)
            {
                var px = pos[i][0];
                var py = pos[i][1];
                var vx = vel[i][0];
                var vy = vel[i][1];

                var x = Modulo((px + vx * seconds), boundX);
                var y = Modulo((py + vy * seconds), boundY);

                result.Add([x, y]);
            }

            var value = Quadrants(boundX, boundY, result);

            if (value < minimum)
            {
                minimum = value;
                bestIteration = seconds;
            }
        }
        return bestIteration;
    }
}
