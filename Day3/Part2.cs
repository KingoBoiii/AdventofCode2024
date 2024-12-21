using System.Text.RegularExpressions;

namespace AdventofCode2024.Day2;

internal static partial class Part2
{
    [GeneratedRegex("don't\\(.*?\\)do\\(\\)", RegexOptions.Singleline)]
    private static partial Regex GetDoDontRegex();

    internal static int SumEnabledMultiplications(string text, Regex mulRegex)
    {
        var enabledMulMatches = GetEnabledMultiplicationMatches(text, mulRegex);

        return enabledMulMatches.Select(match =>
        {
            var valuesGroup = match.Groups[^1].Value;

            var valueStrings = valuesGroup.Split([',', ' '], StringSplitOptions.RemoveEmptyEntries);

            var values = valueStrings.Select(int.Parse).ToArray();

            return values[0] * values[1];
        }).Sum();
    }

    private static IEnumerable<Match> GetEnabledMultiplicationMatches(string text, Regex mulRegex)
    {
        var mulMatches = mulRegex.Matches(text).ToArray();
        var doDontMatches = GetDoDontRegex().Matches(text).ToArray();

        foreach (var mulMatch in mulMatches)
        {
            if(mulMatch.Index < doDontMatches.First().Index)
            {
                yield return mulMatch;
                continue;
            }

            if (mulMatch.Index > doDontMatches.Last().Index + doDontMatches.Last().Length)
            {
                yield return mulMatch;
                continue;
            }

            var isBetweenDontDo = false;
            foreach (var doDontMatch in doDontMatches)
            {
                if (mulMatch.Index < doDontMatch.Index) 
                {
                    continue;
                }

                if (mulMatch.Index + mulMatch.Length > doDontMatch.Index + doDontMatch.Length)
                {
                    continue;
                }

                isBetweenDontDo = true;
            }

            if (isBetweenDontDo)
            {
                Console.WriteLine($"'{mulMatch.Value}' is between don't() and do()");
                continue;
            }

            yield return mulMatch;
        }
    }
}
