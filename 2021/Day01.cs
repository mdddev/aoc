namespace aoc2021;

public class Day01
{
    public static async Task Part1()
    {
        var readings = await _getReadings();
        var countIncreases = Enumerable.Zip(readings, readings.Skip(1)).Sum(s => s.Second > s.First ? 1 : 0);
        WriteLine($"There are {countIncreases} increases in the readings");
    }

    public static async Task Part2()
    {
        var readings = await _getReadings();
        int i = 0;
        List<IEnumerable<int>> listOfThrees = new();
        do
        {
            var threes = readings.Skip(i).Take(3);
            if (threes.Count() != 3) break;
            listOfThrees.Add(threes);
            i++;
        } while (true);

        var countIncreases = Enumerable.Zip(listOfThrees, listOfThrees.Skip(1)).Sum(s => s.Second.Sum() > s.First.Sum() ? 1 : 0);
        WriteLine($"There are {countIncreases} increases in the 3-measurement-sliding-window readings");
    }

    private static async Task<IEnumerable<int>> _getReadings()
    {
        var input = await Files.ReadAsync("Input/day01.txt");
        var readings = input.Split(Environment.NewLine).Select(s => int.Parse(s));
        return readings;
    }
}
