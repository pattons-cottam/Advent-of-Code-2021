var input = File.ReadAllLines("./puzzle_input.txt");

PartOne(input);
PartTwo(input);

void PartOne(string[] input)
{
    var byteSize = input[0].Length;
    var inputAsArray = string.Join("", input).ToCharArray();
    var gammaValues = new int[byteSize];
    var bitPosition = 0;

    for (int i = 0; i < inputAsArray.Length; i++)
    {
        // '0' has a numerical value of 48, so I can do this to find the 
        // numerical value of the input without casting to a string and 
        // using int.Parse() which would be slower
        gammaValues[bitPosition] += (inputAsArray[i] - '0');

        bitPosition = i > 0 && (i + 1) % byteSize == 0
            ? 0
            : bitPosition + 1;
    }

    var gammaRateAsString = "";
    var epsilonRateAsString = "";
    var numberOfInputs = input.Length;

    foreach (var value in gammaValues)
    {
        // what happens if there is an equal number?
        if (value > numberOfInputs / 2)
        {
            gammaRateAsString += '1';
            epsilonRateAsString += '0';
        }
        else
        {
            gammaRateAsString += '0';
            epsilonRateAsString += '1';
        }
    }

    var gammaRate = Convert.ToInt64(gammaRateAsString, 2);
    var epsilonRate = Convert.ToInt64(epsilonRateAsString, 2);

    Console.WriteLine($"Gamma rate: {gammaRateAsString} ({gammaRate})");
    Console.WriteLine($"Epsilon rate: {epsilonRateAsString} ({epsilonRate})");
    Console.WriteLine($"Power consumption: {gammaRate * epsilonRate}");
}

void PartTwo(string[] input)
{
    var rO2Generator = CalculateRating(input, true);
    var rO2GeneratorValue = Convert.ToInt32(rO2Generator, 2);

    Console.WriteLine($"Oxygen generator rating: {rO2Generator} ({rO2GeneratorValue})");

    var rCO2Scrubber = CalculateRating(input, false);
    var rCO2ScrubberValue = Convert.ToInt32(rCO2Scrubber, 2);

    Console.WriteLine($"CO2 scrubber rating: {rCO2Scrubber} ({rCO2ScrubberValue})");

    Console.WriteLine($"Submarine life support rating: {rCO2ScrubberValue * rO2GeneratorValue}");
}

string CalculateRating(string[] input, bool findMostCommon)
{
    var byteSize = input[0].Length;
    var rating = new int[byteSize];
    var tempInput = input.ToList();

    for (int i = 1; i <= byteSize; i++)
    {
        if (tempInput.Count() == 1) return tempInput.Single();

        var commonValue = FindMostCommonValue(tempInput, i, findMostCommon);
        tempInput = tempInput
            .Where(input => input.ToCharArray()[i - 1] == commonValue)
            .ToList();
    }

    return tempInput.Single();
}

char FindMostCommonValue(List<string> input, int bitPosition, bool findMostCommon)
{
    var values = new List<int>();

    foreach (var item in input)
    {
        values.Add(item.ToCharArray()[bitPosition - 1] - '0');
    }

    if (findMostCommon)
    {
        return values.Sum() >= (double)input.Count / 2 ? '1' : '0';
    }

    return values.Sum() >= (double)input.Count / 2 ? '0' : '1';
}