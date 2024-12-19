const string SPLIT_SPACE = "   ";
const string SPLIT_NEWLINE = "\n";

var content = File.ReadAllText("input.txt");

var values = content.Split([SPLIT_SPACE, SPLIT_NEWLINE], StringSplitOptions.RemoveEmptyEntries);

var leftArray = new int[values.Length / 2];
var leftIndex = 0;

var rightArray = new int[values.Length / 2];
var rightIndex = 0;

for (int i = 0; i < values.Length; i++)
{
    if(!int.TryParse(values[i], out var value))
    {
        continue;
    }

    if(i % 2 == 0)
    {
        leftArray[leftIndex++] = value;
    }
    else
    {
        rightArray[rightIndex++] = value;
    }
}

var orderedLeftArray = leftArray.OrderBy(x => x).ToArray();
var orderedRightArray = rightArray.OrderBy(x => x).ToArray();

var distances = new int[values.Length / 2];

for (int i = 0; i < values.Length / 2; i++)
{
    distances[i] = Math.Abs(orderedLeftArray[i] - orderedRightArray[i]);
}

var totalDistance = distances.Sum();

Console.WriteLine($"Total distance is {totalDistance}");

Console.Read();