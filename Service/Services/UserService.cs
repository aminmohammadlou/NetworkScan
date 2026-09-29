namespace Service.Services;

public class UserService(ExcelService excelService)
{
    public async Task SyncUsers(string usersFileAddress)
    {
        var users = excelService.ReadUsers(usersFileAddress);

        // Get usees from db
        

        // Update users that are in both file and db

        // Create users that are in file but are not in db

        // Deactivate users that are in db and are not in file
    }
}