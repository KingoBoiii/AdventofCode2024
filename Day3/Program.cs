using AdventofCode2024.Day2;

var content = File.ReadAllText("input.txt");

var summedMultiplications = Part1.SumAllMultiplications(content, Part1.GetMulRegex());

var summedEnabledMultiplications = Part2.SumEnabledMultiplications(content, Part1.GetMulRegex());

Console.WriteLine($"[Part1] Total sum of all multiplications is {summedMultiplications}");
Console.WriteLine($"[Part2] Total sum of enabled multiplications is {summedEnabledMultiplications}");

Console.Read();
