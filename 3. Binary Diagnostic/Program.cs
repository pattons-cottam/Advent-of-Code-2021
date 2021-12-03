var input = File.ReadAllLines("./puzzle_input.txt");

PartOne(input);

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