namespace Day15.Src;

public class Solution
{
    public static List<List<char>> ReadMap(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var result = new List<List<char>>();

        foreach (var line in lines)
        {
            var holder = new List<char>();
            foreach (var character in line)
            {
                holder.Add(character);
            }
            result.Add(holder);
        }
        return result;
    }

    public static List<char> ReadMoves(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var result = new List<char>();

        foreach (var line in lines)
        {
            foreach (var c in line)
                result.Add(c);
        }
        return result;
    }

    public static (int x, int y) FindAtSign(List<List<char>> map)
    {
        for (var i = 0; i < map.Count; i++)
        {
            for (var j = 0; j < map[0].Count; j++)
            {
                if (map[i][j] == '@') return (i, j);
            }
        }
        return (-1,-1);
    }

    public static int CountStonesInThatDirection(List<List<char>> map, char move, int x, int y)
    {
        var counter = 0;
        if (move == '>')
        {
            while (map[x][y+1] == 'O')
            {
                counter++;
                y++;
            }
        }

        if (move == '<')
        {
            while (map[x][y-1] == 'O')
            {
                counter++;
                y--;
            }
        }

        if (move == 'v')
        {
            while (map[x+1][y] == 'O')
            {
                counter++;
                x++;
            }
        }

        if (move == '^')
        {
            while (map[x-1][y] == 'O')
            {
                counter++;
                x--;
            }
        }
        return counter;
    }

    public static List<List<char>> MoveStonesByOnePlace(List<List<char>> map, int x, int y, int numberOfStones, char direction)
    {
        if (direction == '<')
        {
            for (var k = y - numberOfStones - 1; k < y; k++)
            {
                map[x][k] = map[x][k + 1];
                map[x][k + 1] = '.';
            }
        }

        if (direction == '>')
        {
            for (var k = y + numberOfStones + 1; k > y; k--)
            {
                map[x][k] = map[x][k - 1];
                map[x][k - 1] = '.';
            }
        }

        if (direction == 'v')
        {
            for (var k = x + numberOfStones + 1; k > x; k--)
            {
                map[k][y] = map[k-1][y];
                map[k-1][y] = '.';
            }
        }

        if (direction == '^')
        {
            for (var k = x - numberOfStones - 1; k < x; k++)
            {
                map[k][y] = map[k + 1][y];
                map[k + 1][y] = '.';
            }
        }

        return map;
    }

    public static List<List<char>> ApplyAllMoves(List<List<char>> map, List<char> moves)
    {
        var (x,y)= FindAtSign(map);
        foreach (var move in moves)
        {
            if (move == '<')
            {
                if (map[x][y-1] == '#')
                    continue;

                if (map[x][y - 1] == '.')
                {
                    map[x][y - 1] = '@';
                    map[x][y] = '.';
                    y--;
                    continue;
                }
                    

                if (map[x][y - 1] == 'O')
                {
                    var numberOfStones = CountStonesInThatDirection(map, move, x, y);

                    if (map[x][y - numberOfStones - 1] == '.')
                    {
                        map = MoveStonesByOnePlace(map, x, y, numberOfStones, move);
                        y--;
                        continue;
                    }
                }
            }

            if (move == '^')
            {
                if (map[x-1][y] == '#')
                    continue;

                if (map[x - 1][y] == '.')
                {
                    map[x - 1][y] = '@';
                    map[x][y] = '.';
                    x--;
                    continue;
                }
                    

                if (map[x - 1][y] == 'O')
                {
                    var numberOfStones = CountStonesInThatDirection(map, move, x, y);

                    if (map[x - numberOfStones - 1][y] == '.')
                    {
                        map = MoveStonesByOnePlace(map, x, y, numberOfStones, move);
                        x--;
                        continue;
                    }
                        
                }
            }

            if (move == '>')
            {
                if (map[x][y + 1] == '#')
                {
                    continue;
                }

                if (map[x][y + 1] == '.')
                {
                    map[x][y + 1] = '@';
                    map[x][y] = '.';
                    y++;
                    continue;
                }
                
                if (map[x][y + 1] == 'O')
                {
                    var numberOfStones = CountStonesInThatDirection(map, move, x, y);

                    if (map[x][y + numberOfStones + 1] == '.')
                    {
                        map = MoveStonesByOnePlace(map, x, y, numberOfStones, move);
                        y++;
                        continue;   
                    }
                }
            }

            if (move == 'v')
            {
                if (map[x+1][y] == '#')
                    continue;

                if (map[x + 1][y] == '.')
                {
                    map[x + 1][y] = '@';
                    map[x][y] = '.';
                    x++;
                    continue;
                }
                
                if (map[x + 1][y] == 'O')
                {
                    var numberOfStones = CountStonesInThatDirection(map, move, x, y);

                    if (map[x + numberOfStones + 1][y] == '.')
                    {
                        map = MoveStonesByOnePlace(map, x, y, numberOfStones, move);
                        x++;
                    }
                }
            }
        }

        return map;
    }

    public static int CalculateGps(List<List<char>> map)
    {
        var sum = 0;

        for (var i = 0; i < map.Count; i++)
        {
            for (var j = 0; j < map[i].Count; j++)
            {
                if (map[i][j] == 'O')
                    sum += i * 100 + j;
            }
        }
        return sum;
    }
}
