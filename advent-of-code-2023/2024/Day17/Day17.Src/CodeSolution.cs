namespace Day17.Src;

public class CodeSolution
{
    public static List<int> ReadFileRegister(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var result = new List<int>();

        foreach (var line in lines)
        {
            if (line.Contains("Register"))
            {
                var parts = line.Split(": ");
                if (parts.Length == 2 && int.TryParse(parts[1], out int value))
                {
                    result.Add(value);
                }
            }
        }

        return result;
    }

    public static List<int> ReadFileProgram(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var result = new List<int>();

        foreach (var line in lines)
        {
            if (line.Contains("Program"))
            {
                var parts = line.Split(": ");
                if (parts.Length == 2)
                {
                    var commas = parts[1].Split(",");
                    foreach (var character in commas)
                    {
                        if (int.TryParse(character, out int value))
                        {
                            result.Add(value);
                        }
                    }
                }
            }
        }

        return result;
    }

    public static string CalcAll(List<int> register, List<int> program)
    {
        var a = register[0];
        var b = register[1];
        var c = register[2];

        var output = new List<int>();
        var pointer = 0;

        while (pointer < program.Count)
        {
            int ins = program[pointer];
            int operand = program[pointer + 1];

            switch (ins)
            {
                case 0: // adv
                    a = a / (1 << Combo(operand, a, b, c));
                    break;
                case 1: // bxl
                    b = b ^ operand;
                    break;
                case 2: // bst
                    b = Combo(operand, a, b, c) % 8;
                    break;
                case 3: // jnz
                    if (a != 0)
                    {
                        pointer = operand;
                        continue;
                    }
                    break;
                case 4: // bxc
                    b = b ^ c;
                    break;
                case 5: // out
                    output.Add(Combo(operand, a, b, c) % 8);
                    break;
                case 6: // bdv
                    b = a / (1 << Combo(operand, a, b, c));
                    break;
                case 7: // cdv
                    c = a / (1 << Combo(operand, a, b, c));
                    break;
                default:
                    throw new Exception($"Unrecognized instruction: {ins}");
            }

            pointer += 2;
        }

        // Return output as comma-separated string
        return ConvertToString(output);
    }

    public static int Combo(int operand, int a, int b, int c)
    {
        if (0 <= operand && operand <= 3) return operand;
        if (operand == 4) return a;
        if (operand == 5) return b;
        if (operand == 6) return c;
        if (operand == 7) throw new Exception("Operand 7 is reserved and invalid.");
        throw new Exception($"Unrecognized combo operand {operand}");
    }

    public static string ConvertToString(List<int> input)
    {
        var result = "";
        foreach (var character in input)
        {
            result += character;
        }
        return result;
    }
}
