PartOne();
PartTwo();

void PartOne()
{
    var input = File.ReadAllLines("./puzzle_input.txt");
    var previousDepth = int.Parse(input[0]);
    var measurementsIncreased = 0;

    foreach (var depth in input)
    {
        var intDepth = int.Parse(depth);

        if (intDepth > previousDepth)
        {
            measurementsIncreased++;
        }

        previousDepth = intDepth;
    }

    Console.WriteLine($"Depth measurement increased {measurementsIncreased} times");
}

void PartTwo()
{
    var input = new List<int>();

    foreach (var stringDepth in File.ReadAllLines("./puzzle_input.txt"))
    {
        input.Add(int.Parse(stringDepth));
    }

    var previousDepth = input[0] + input[1] + input[2];
    var depthIncreased = 0;

    for (var i = 0; i < input.Count - 2; i++)
    {
        var depth = input[i] + input[i + 1] + input[i + 2];

        if (depth > previousDepth)
        {
            depthIncreased++;
        }

        previousDepth = depth;
    }

    Console.WriteLine($"Depth measurement increased {depthIncreased} times");
}