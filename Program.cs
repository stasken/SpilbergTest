using SpilbergTest;

// Get words
InputFile input = new InputFile("input.txt");

// Get parameters:
// - words needed for a combination
// - length result
int wordsNeeded = 2;
int lengthResult = 6;

Console.WriteLine("Started.");
// Calculate results
CalculateCombinations calcs = new CalculateCombinations(input, lengthResult, wordsNeeded);

// Write results
foreach (var combination in calcs.combinations)
{
    Console.WriteLine(combination.ToString());
}

Console.WriteLine($"Total of {calcs.combinations.Count} combinations found.");
Console.WriteLine("Finished.");
