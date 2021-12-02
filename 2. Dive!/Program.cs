

PartOne();

void PartOne()
{
    int depth = 0, position = 0;

    string[] input = File.ReadAllLines("./puzzle_input.txt");

    foreach (var command in input)
    {
        var direction = command.Split(' ')[0];
        var distance = command.Split(' ')[1];

        switch (direction)
        {
            case "forward":
                position += int.Parse(distance);
                break;
            case "up":
                depth -= int.Parse(distance);
                break;
            case "down":
                depth += int.Parse(distance);
                break;
        }
    }

    Console.WriteLine($"Final position: {position}, final depth: {depth} ({depth * position})");
}