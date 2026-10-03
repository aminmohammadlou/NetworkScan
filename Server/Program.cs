using Data.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Server;
using Service.Repository;
using Service.Services;

// Add db
var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var options = new DbContextOptionsBuilder<NetworkScanDbContext>()
    .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
    .Options;

await using var db = new NetworkScanDbContext(options);

// Register services
var repo = new Repo(db);
var excelService = new ExcelService();
var userService = new UserService(excelService, repo);
var computerService = new ComputerService(excelService, repo);

// Start of app
var choiceNumber = Workflows.GetChoiceInput();

switch (choiceNumber)
{
    case 1:
        var usersFileAddress = Workflows.GetExcelFileAddress();

        Console.WriteLine("Syncing users.Please wait... \n");

        await userService.SyncUsers(usersFileAddress);

        Console.WriteLine("Users synced successfully.");
        break;

    case 2:
        var computersFileAddress = Workflows.GetExcelFileAddress();

        Console.WriteLine("Syncing computers.Please wait... \n");

        await computerService.SyncComputers(computersFileAddress);

        Console.WriteLine("Computers synced successfully.");

        break;

    default:
        Console.WriteLine("Internal error.Contact with developer.");
        break;
}





