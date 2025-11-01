namespace Src.Day11;

public class SolutionP2
{
    public static string TheSecondNextValidPassword(string input)
    {
        var result = SolutionP1.FinalAnswer(input);

        return SolutionP1.FinalAnswer(SolutionP1.GenerateNextPassword(result));
    }
}
