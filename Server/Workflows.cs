namespace Server;

public static class Workflows
{
    public static int GetChoiceInput()
    {
        int choiceNumber;

        while (true)
        {
            Console.WriteLine("Enter your choice number: ");
            Console.WriteLine("1: Sync users   2: Sync computers   3: Network scan   4: Systems differentials");
            var choice = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(choice) || !int.TryParse(choice, out choiceNumber) || choiceNumber is not (1 or 2 or 3 or 4))
                Console.WriteLine("Wrong input.Please try again. \n");
            else
                break;
        }

        return choiceNumber;
    }

    public static string GetUsersFileAddress()
    {
        string? usersFileAddress;

        while (true)
        {
            Console.WriteLine("Enter user excel file address: ");
            usersFileAddress = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(usersFileAddress))
                Console.WriteLine("Wrong address.Please try again. \n");
            else
                break;
        }

        return usersFileAddress;
    }
}
