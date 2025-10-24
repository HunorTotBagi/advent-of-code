namespace Src.Day03;

public class SolutionP2
{
    public static int CalculateSantasAndRobotsWork(string s)
    {
        var charArray = s.ToCharArray();

        var santaX = 0;
        var santaY = 0;

        var robotX = 0;
        var robotY = 0;

        var seen = new HashSet<(int x, int y)> { (0, 0) };

        for (var i = 0; i < charArray.Length; i++)
        {
            if (i % 2 == 0)
            {
                if (charArray[i] == '^')
                {
                    santaY++;
                    seen.Add((santaX, santaY));
                }

                else if (charArray[i] == 'v')
                {
                    santaY--;
                    seen.Add((santaX, santaY));
                }

                else if (charArray[i] == '>')
                {
                    santaX++;
                    seen.Add((santaX, santaY));
                }


                else if (charArray[i] == '<')
                {
                    santaX--;
                    seen.Add((santaX, santaY));
                }
            }
            else
            {
                if (charArray[i] == '^')
                {
                    robotY++;
                    seen.Add((robotX, robotY));
                }

                else if (charArray[i] == 'v')
                {
                    robotY--;
                    seen.Add((robotX, robotY));
                }

                else if (charArray[i] == '>')
                {
                    robotX++;
                    seen.Add((robotX, robotY));
                }


                else if (charArray[i] == '<')
                {
                    robotX--;
                    seen.Add((robotX, robotY));
                }
            }
        }

        return seen.Count;
    }
}