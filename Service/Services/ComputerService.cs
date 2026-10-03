using Data.Models;
using Service.DtoConverters;
using Service.Dtos;
using Service.Repository;

namespace Service.Services;

public class ComputerService(ExcelService excelService, Repo repo)
{
    public async Task SyncComputers(string computerFileAddress)
    {
        var computers = excelService.ReadComputers(computerFileAddress);

        var computerModels = await repo.GetComputers();

        // Create computers that are in file but are not in db
        foreach (var computer in computers)
        {
            var computerModel = computerModels.SingleOrDefault(x => x.ComputerName == computer.ComputerName);
            if (computerModel is not null)
                continue;

            computerModel = new ComputerModel
            {
                AssetCode = computer.AssetCode,
                ComputerName = computer.ComputerName,
                MainBoard = computer.MainBoard,
                Cpu = computer.Cpu,
                Ram = computer.Ram,
                Vga = computer.Vga,
                OpticalDrive = computer.OpticalDrive,
                MacAddress = computer.MacAddress,
                SealNumber1 = computer.SealNumber1,
                SealNumber2 = computer.SealNumber2,
                OperatingSystem = computer.OperatingSystem,
                LastSecurityUpdate = computer.LastSecurityUpdate,
                Programs = computer.Programs,
                IsActive = true,
                CreatedTime = DateTime.UtcNow,
                UpdatedTime = DateTime.UtcNow
            };

            var hardDisks = computer.HardDisks.Select(x => new HardDiskModel
            {
                Name = x.Name,
                Capacity = x.Capacity,
                SerialNumber = x.SerialNumber,
                ComputerId = computerModel.ComputerId
            }).ToArray();

            computerModel.HardDisks = hardDisks;

            await repo.AddEntity(computerModel);
        }

        await repo.SaveChanges();
    }
}