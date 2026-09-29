using Server;
using Service.Services;

var choiceNumber = Workflows.GetChoiceInput();

var excelService = new ExcelService();
var userService = new UserService(excelService);

switch (choiceNumber)
{
    case 1:
        var usersFileAddress = Workflows.GetUsersFileAddress();

        await userService.SyncUsers(usersFileAddress);

        break;

    case 2:
        break;

    default:
        Console.WriteLine("Internal error.Contact with developer.");
        break;
}





