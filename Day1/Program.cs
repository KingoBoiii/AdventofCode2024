const string SPLIT_SPACE = "   ";
const string SPLIT_NEWLINE = "\n";

#if false
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

var count = values.Length / 2;
#else
var leftArray = new List<int>();
var rightArray = new List<int>();

using var reader = new StreamReader("input.txt");

var line = reader.ReadLine();
while (line != null)
{
    var lineValues = line.Split(SPLIT_SPACE);

    leftArray.Add(int.Parse(lineValues[0]));
    rightArray.Add(int.Parse(lineValues[1]));

    line = reader.ReadLine();
}

reader.Close();

var count = leftArray.Count;
#endif

var orderedLeftArray = leftArray.OrderBy(x => x).ToArray();
var orderedRightArray = rightArray.OrderBy(x => x).ToArray();

var distances = new int[count];

for (int i = 0; i < count; i++)
{
    distances[i] = Math.Abs(orderedLeftArray[i] - orderedRightArray[i]);
}

var totalDistance = distances.Sum();

Console.WriteLine($"Total distance is {totalDistance}");

Console.Read();