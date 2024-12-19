namespace AdventofCode2024.Day1;

internal sealed class Part2
{
    internal static int CalculateTotalSimilarity(IEnumerable<int> leftArray, IEnumerable<int> rightArray, int count)
    {
        var similarities = new int[count];

        for (int i = 0; i < count; i++)
        {
            var leftValue = leftArray.ElementAt(i);

            var rightArrayCount = rightArray.Count(x => x == leftValue);

            similarities[i] = leftValue * rightArrayCount;
        }

        return similarities.Sum(x => x);
    }
}