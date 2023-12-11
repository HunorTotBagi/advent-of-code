namespace src.day07
{
    //var lines = File.ReadAllLines("data/exampleData0.txt");
    public class Hand
    {

        //List<char> CardRanks = { 'A', 'K', 'Q', 'J', 'T', '9', '8', '7', '6', '5', '4', '3', '2' };

        public Dictionary<string, int> ReadFile(string filePath)
        {
            var lines = File.ReadAllLines("C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day07-camel-cards\\data\\exampleData0.txt");

            Dictionary<string, int> data = new();

            foreach (var line in lines)
            {
                var parts = line.Split(' ');
                data[parts[0]] = int.Parse(parts[1]);
            }
            return data;
        }


        public Dictionary<char, int> CountOccurences(string card)
        {
            Dictionary<char, int> result = new();

            foreach (char c in card)
            {
                if (result.ContainsKey(c))
                {
                    result[c] += 1;
                }
                else
                {
                    result[c] = 1;
                }
            }

            return result;
        }

        public int GetCardType(string card)
        {
            Dictionary<char, int> counts = CountOccurences(card);

            if (counts.ContainsValue(5))
                return 7; // Five of a kind

            if (counts.ContainsValue(4) && counts.ContainsValue(1))
                return 6; // Four of a kind

            if (counts.ContainsValue(3) && counts.ContainsValue(2))
                return 5; // Full house

            if (counts.ContainsValue(3) && counts.ContainsValue(1))
                return 4; // Three of a kind

            if (counts.Count(kv => kv.Value == 2) == 2 && counts.ContainsValue(1))
                return 3; // Two pair

            if (counts.ContainsValue(2) && counts.ContainsValue(1))
                return 2; // One pair

            return 1;
        }
    }
}
