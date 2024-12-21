using System.Text.RegularExpressions;

namespace AdventofCode2024.Day2;

internal static partial class Part1
{
    [GeneratedRegex("mul\\((\\d+,?\\d+)\\)")]
    internal static partial Regex GetMulRegex();

    internal static int SumAllMultiplications(string text, Regex mulRegex)
    {
        var matches = mulRegex.Matches(text);

        var multiplications = new int[matches.Count];

        for (int i = 0; i < matches.Count; i++)
        {
            var match = matches[i];

            if (!match.Success)
            {
                continue;
            }

            if(match.Groups.Count != 2)
            {
                continue;
            }

            var valuesGroup = match.Groups[^1].Value;

            var valueStrings = valuesGroup.Split([',', ' '], StringSplitOptions.RemoveEmptyEntries);

            var values = valueStrings.Select(int.Parse).ToArray();

            multiplications[i] = values[0] * values[1];
        }

        return multiplications.Sum();
    }
}
