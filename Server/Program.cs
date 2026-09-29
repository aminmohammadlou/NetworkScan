while (true)
{
    Console.WriteLine("Enter your choice number: ");
    Console.WriteLine("1: Network scan   2: Systems differentials");
    var choice = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(choice) || !int.TryParse(choice, out var choiceNumber) || choiceNumber is not (1 or 2))
        Console.WriteLine("Wrong input.Please try again. \n");
    else
        break;
}







