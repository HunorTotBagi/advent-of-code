namespace src.day12_hot_springs
{
    public class HotSpring
    {
        public (List<string>, List<List<int>>) ReadFile(string filePath)
        {
            List<string> stringsList = new List<string>();
            List<List<int>> intsList = new List<List<int>>();
            string[] lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var parts = line.Split(' ');
                stringsList.Add(parts[0]);
                List<int> intValues = parts[1].Split(',').Select(int.Parse).ToList();
                intsList.Add(intValues);
            }
            return (stringsList, intsList);
        }
    }
}