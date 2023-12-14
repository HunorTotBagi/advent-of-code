namespace src.day06_wait_for_it
{
    public class Race
    {
        public List<ulong> GetRaceTimesFromFile(string filePath)
        {
            string startsWith = "Time:";
            List<ulong> timeValues = ExtractRaceTimeValues(filePath, startsWith);
            return timeValues;
        }

        public List<ulong> GetRaceDistancesFromFile(string filePath)
        {
            string startsWith = "Distance:";
            List<ulong> timeValues = ExtractRaceTimeValues(filePath, startsWith);
            return timeValues;
        }

        public List<ulong> ExtractRaceTimeValues(string filePath, string startsWith)
        {
            List<ulong> timeValues = new List<ulong>();

            string[] lines = File.ReadAllLines(filePath);

            string timeLine = lines.FirstOrDefault(line => line.StartsWith(startsWith));

            if (timeLine != null)
            {
                string[] words = timeLine.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 1; i < words.Length; i++)
                {
                    if (ulong.TryParse(words[i], out ulong timeValue))
                    {
                        timeValues.Add(timeValue);
                    }

                }
            }
            return timeValues;
        }

        public ulong CalculateWaysToBeatRecordForRace(string filePath, int raceNumber)
        {
            List<ulong> times = GetRaceTimesFromFile(filePath);
            List<ulong> distances = GetRaceDistancesFromFile(filePath);

            List<ulong> result = new List<ulong>();

            ulong firstTime = times[raceNumber];
            ulong counter = times[raceNumber];
            ulong firstDistance = distances[raceNumber];

            for (ulong i = 0; i < firstTime; i++)
            {
                if (i * counter > firstDistance)
                {
                    result.Add(i * counter);
                }
                counter -= 1;
            }
            return (ulong)result.Count();
        }

        public ulong CalculateMarginOfError(string filePath)
        {
            List<ulong> times = GetRaceTimesFromFile(filePath);

            ulong result = 1;

            for (ulong i = 0; i < (ulong)times.Count; i++)
            {
                result *= CalculateWaysToBeatRecordForRace(filePath, (int)i);
            }
            return result;
        }
    }
}