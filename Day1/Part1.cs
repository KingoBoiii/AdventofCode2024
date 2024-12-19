namespace AdventofCode2024.Day1;

internal sealed class Part1
{
    internal static int CalculateDistance(IEnumerable<int> leftArray, IEnumerable<int> rightArray, int count)
    {
        var orderedLeftArray = leftArray.OrderBy(x => x).ToArray();
        var orderedRightArray = rightArray.OrderBy(x => x).ToArray();

        var distances = new int[count];

        for (int i = 0; i < count; i++)
        {
            distances[i] = Math.Abs(orderedLeftArray[i] - orderedRightArray[i]);
        }

        return distances.Sum();
    }
}
