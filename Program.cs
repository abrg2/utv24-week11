using System.Text.RegularExpressions;

List<string> validProducts = new List<String> { };

Console.WriteLine("Skriv in produkter. Avsluta med att skriva 'exit'");

while (true)
{
    Console.ResetColor();

    Console.Write("Ange produkt: ");

    string userInput = Console.ReadLine().Trim();

    if (userInput.ToLower() == "exit")
    {
        break;
    }

    // default to error-color
    Console.ForegroundColor = ConsoleColor.Red;

    if (userInput == "")
    {
        Console.WriteLine("Du får inte ange ett tomt värde.");
        continue;
    }

    if (!userInput.Contains("-"))
    {
        Console.WriteLine("Produktnamn måste innehålla bindestreck (-)");
        continue;
    }

    string[] nameSplit = userInput.Split("-");
    string leftSide = nameSplit[0];
    string rightSide = nameSplit[1];

    if (leftSide == "")
    {
        Console.WriteLine("Produktnamn kan ej vara tomt på vänster sida.");
        continue;
    }

    if (rightSide == "")
    {
        Console.WriteLine("Produktnamn kan ej vara tomt på höger sida.");
        continue;
    }

    const string regexPatternLetters = @"^[a-zA-Z]+$";
    const string regexPatternDigits = @"^\d+$";

    if (!Regex.IsMatch(leftSide, regexPatternLetters))
    {
        Console.WriteLine("Produktnamn måste innehålla bokstäver (A-Z) på vänster sida.");
        continue;
    }

    if (!Regex.IsMatch(rightSide, regexPatternDigits))
    {
        Console.WriteLine("Produktnamn måste innehålla siffror (0-9) på höger sida.");
        continue;
    }

    int inum = int.Parse(rightSide);

    if (inum < 200 || inum > 500)
    {
        Console.WriteLine("Produktnamnets högerdel måste vara minst 200 och max 500");
        continue;
    }

    // no errors detected, set text color to green and show result
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Produkten lades till!");
    validProducts.Add($"{leftSide}-{rightSide}");
}

if (validProducts.Count > 0)
{
    Console.WriteLine("Följande giltiga produkter angavs (sorterad ordning):");

    //List<string> sortedValidProducts = validProducts.Slice().Sort();
    validProducts.Sort();

    foreach (string prod in validProducts)
    {
        Console.WriteLine("* " + prod);
    }
}
else
{
    Console.WriteLine("Inga giltiga produkter angavs.");
}


Console.ReadLine(); // pause console window before exiting