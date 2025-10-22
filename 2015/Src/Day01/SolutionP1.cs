namespace Src.Day01;

public class SolutionP1
{
    public static int GetTheFloor(string input)
    {
        var currentFloor = 0;

        foreach (var character in input)
        {
            if (character == '(')
                currentFloor++;

            if (character == ')')
                currentFloor--;
        }

        return currentFloor;
    }
}
