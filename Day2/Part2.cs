namespace AdventofCode2024.Day2;

internal static class Part2
{
    internal static IEnumerable<string> GetSafeReportsWithProblemDampener(string filepath)
    {
        using var streamReader = new StreamReader(filepath);

        var line = streamReader.ReadLine();

        while (line != null)
        {
            var levelValues = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var levels = levelValues.Select(int.Parse).ToArray();

            if (!CheckSequenceOrder(levels))
            {
                line = streamReader.ReadLine();
                continue;
            }

            if (!levels.Select((t, i) => levels.Where((_, index) => index != i).ToArray()).Any(IsSafe))
            {
                line = streamReader.ReadLine();
                continue;
            }

            if (!IsSafe(levels))
            {
                line = streamReader.ReadLine();
                continue;
            }

            yield return line;

            line = streamReader.ReadLine();
        }

        streamReader.Close();

        yield break;
    }

    private static bool IsSafe(int[] levels)
    {
        var differences = new int[levels.Length];

        for (int i = 0; i < levels.Length - 1; i++)
        {
            var diff = levels[i] - levels[i + 1];
            var abs = Math.Abs(diff);

            differences[i] = abs;

        }

        return differences.SkipLast(1).All(x => x >= 1 && x <= 3);
    }

    private static bool CheckSequenceOrder(int[] levels)
    {
        if (levels.Length < 2)
            return false;

        bool isIncreasing = false;
        bool isDecreasing = false;

        for (int i = 0; i < levels.Length - 1; i++)
        {
            if (levels[i] < levels[i + 1])
            {
                isIncreasing = true;
            }
            else if (levels[i] > levels[i + 1])
            {
                isDecreasing = true;
            }
            else
            {
                return false;
            }
        }

        if (isIncreasing && !isDecreasing)
        {
            return true;
        }
        else if (!isIncreasing && isDecreasing)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
