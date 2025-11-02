namespace Src.Day14;

public class SolutionP1
{
    public static int Calc(string filePath, int seconds)
    {
        var lines = File.ReadAllLines(filePath);

        var speeds = new List<int>();
        var activeTimes = new List<int>();
        var restTimes = new List<int>();

        foreach (var line in lines)
        {
            var (speed, activeTime, restTime) = ExtractInfo(line);

            speeds.Add(speed);
            activeTimes.Add(activeTime);
            restTimes.Add(restTime);
        }

        var max = int.MinValue;

        for (var i = 0; i < speeds.Count; i++)
        {
            var current = GetDistance(speeds[i], activeTimes[i], restTimes[i], seconds);
            if (current > max)
                max = current;
        }

        return max;
    }

    public static (int speed, int activeTime, int restTime) ExtractInfo(string input)
    {
        var a = input.Split(" seconds, but then must rest for ");
        var b = a[1].Split(" ");
        var c = a[0].Split(" ");

        var speed = int.Parse(c[3]);
        var activeTime = int.Parse(c[6]);
        var restTime = int.Parse(b[0]);

        return (speed, activeTime, restTime);
    }

    public static int GetDistance(int speed, int activeTime, int restTime, int targetSeconds)
    {
        var cycle = activeTime + restTime;
        var cycles = targetSeconds / cycle;
        var remainder = targetSeconds % cycle;

        return cycles * speed * activeTime + speed * Math.Min(activeTime, remainder);
    }
}
