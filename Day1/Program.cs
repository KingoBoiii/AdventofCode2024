using AdventofCode2024.Day1;

var (leftArray, rightArray, count) = LoadInputFile("input.txt");

var totalDistance = Part1.CalculateTotalDistance(leftArray, rightArray, count);

var totalSimilarity = Part2.CalculateTotalSimilarity(leftArray, rightArray, count);

Console.WriteLine($"Total distance is {totalDistance}");
Console.WriteLine($"Total similarity is {totalSimilarity}");

Console.Read();

static (int[] LeftArray, int[] RightArray, int Count) LoadInputFile(string filepath, bool useIOFile = true)
{
    const string SPLIT_SPACE = "   ";
    const string SPLIT_NEWLINE = "\n";

    if (useIOFile)
    {
        var content = File.ReadAllText(filepath);

        var values = content.Split([SPLIT_SPACE, SPLIT_NEWLINE], StringSplitOptions.RemoveEmptyEntries);

        var leftArray = new int[values.Length / 2];
        var leftIndex = 0;

        var rightArray = new int[values.Length / 2];
        var rightIndex = 0;

        for (int i = 0; i < values.Length; i++)
        {
            if (!int.TryParse(values[i], out var value))
            {
                continue;
            }

            if (i % 2 == 0)
            {
                leftArray[leftIndex++] = value;
            }
            else
            {
                rightArray[rightIndex++] = value;
            }
        }

        return (leftArray, rightArray, values.Length / 2);
    }
    else
    {
        var leftArray = new List<int>();
        var rightArray = new List<int>();

        using var reader = new StreamReader(filepath);

        var line = reader.ReadLine();
        while (line != null)
        {
            var lineValues = line.Split(SPLIT_SPACE);

            leftArray.Add(int.Parse(lineValues[0]));
            rightArray.Add(int.Parse(lineValues[1]));

            line = reader.ReadLine();
        }

        reader.Close();

        return (leftArray.ToArray(), rightArray.ToArray(), leftArray.Count);
    }
}

