namespace Src.Day03;

public class SolutionP1
{
    public static int CalculateSantasWork(string s)
    {
        var currX = 0;
        var currY = 0;
        var seen = new HashSet<(int x, int y)> { (currX, currY) };

        foreach (var c in s)
        {
            if (c == '^')
            {
                currY++;
                seen.Add((currX, currY));
            }

            if (c == 'v')
            {
                currY--;
                seen.Add((currX, currY));
            }

            if (c == '>')
            {
                currX++;
                seen.Add((currX, currY));
            }


            if (c == '<')
            {
                currX--;
                seen.Add((currX, currY));
            }
        }

        return seen.Count;
    }
}
