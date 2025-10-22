namespace Src.Day01;

public class SolutionP2
{
    public static int GetBasementPositionIndex(string input)
    {
        var charArray = input.ToCharArray();
        var currentFloor = 0;

        for (var i = 0; i < input.Length; i++)
        {
            if (charArray[i] == '(')
            {
                currentFloor++;
                if (currentFloor == -1)
                {
                    return i + 1;
                }
            }

            if (charArray[i] == ')')
            {
                currentFloor--;
                if (currentFloor == -1)
                {
                    return i + 1;
                }
            }
        }

        return currentFloor;
    }
}
