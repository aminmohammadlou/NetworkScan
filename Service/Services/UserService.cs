using Data.Models;
using Microsoft.EntityFrameworkCore;
using Service.Repository;

namespace Service.Services;

public class UserService(ExcelService excelService, Repo repo)
{
    public async Task SyncUsers(string usersFileAddress)
    {
        var users = excelService.ReadUsers(usersFileAddress);

        var userModels = await repo.GetUsers();

        foreach (var userModel in userModels)
        {
            var user = users.SingleOrDefault(x => x.EmployeeCode == userModel.EmployeeCode);
            if (user is null)
            {
                // Deactivate users that are in db and are not in file
                userModel.IsActive = false;
            }
            else
            {
                // Update users that are in both file and db
                userModel.EmployeeCode = user.EmployeeCode;
                userModel.FirstName = user.FirstName;
                userModel.LastName = user.LastName;
                userModel.IsActive = true;
            }

            userModel.UpdatedTime = DateTime.Now;
        }

        // Create users that are in file but are not in db
        foreach (var user in users)
        {
            var userModel = userModels.SingleOrDefault(x => x.EmployeeCode == user.EmployeeCode);
            if (userModel is not null)
                continue;

            userModel = new UserModel
            {
                EmployeeCode = user.EmployeeCode,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsActive = true,
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            };
            await repo.AddEntity(userModel);
        }

        await repo.SaveChanges();
    }
}