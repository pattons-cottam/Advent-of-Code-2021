PartOne();
PartTwo();

void PartOne()
{
    int depth = 0, position = 0;

    string[] input = File.ReadAllLines("./puzzle_input.txt");

    foreach (var command in input)
    {
        var commands = command.Split(' ');
        var direction = commands[0];
        var distance = int.Parse(commands[1]);

        switch (direction)
        {
            case "forward":
                position += distance;
                break;
            case "up":
                depth -= distance;
                break;
            case "down":
                depth += distance;
                break;
        }
    }

    Console.WriteLine($"Final position: {position}, final depth: {depth} ({depth * position})");
}

void PartTwo()
{
    int depth = 0, position = 0, aim = 0;

    string[] input = File.ReadAllLines("./puzzle_input.txt");

    foreach (var command in input)
    {
        var commands = command.Split(' ');
        var direction = commands[0];
        var distance = int.Parse(commands[1]);

        switch (direction)
        {
            case "forward":
                position += distance;
                depth += aim * distance;
                break;
            case "up":
                aim -= distance;
                break;
            case "down":
                aim += distance;
                break;
        }
    }

    Console.WriteLine($"Final position: {position}, final depth: {depth} ({depth * position})");
}