using ClosedXML.Excel;
using Service.Dtos;

namespace Service.DtoConverters;

public static class ExcelConverter
{
    public static User ToUser(this IXLRow row, Dictionary<string, int> headers)
    {
        return new User
        {
            EmployeeCode = row.Cell(headers["EmployeeCode"]).GetValue<int>(),
            FirstName = row.Cell(headers["FirstName"]).GetValue<string>(),
            LastName = row.Cell(headers["LastName"]).GetValue<string>(),
            MembershipType = row.Cell(headers["MembershipType"]).GetValue<string>(),
            NationalNumber = row.Cell(headers["NationalNumber"]).GetValue<string>(),
            Job = row.Cell(headers["Job"]).GetValue<string>(),
            PhoneNumber = row.Cell(headers["PhoneNumber"]).GetValue<string>()
        };
    }

    public static Computer ToComputer(this IXLRow row, Dictionary<string, int> headers)
    {
        return new Computer
        {
            AssetCode = row.Cell(headers["AssetCode"]).GetValue<string>(),
            ComputerName = row.Cell(headers["ComputerName"]).GetValue<string>(),
            MainBoard = row.Cell(headers["MainBoard"]).GetValue<string>(),
            Cpu = row.Cell(headers["Cpu"]).GetValue<string>(),
            Ram = row.Cell(headers["Ram"]).GetValue<int>(),
            Vga = row.Cell(headers["Vga"]).GetValue<string>(),
            HardDisks = row.Cell(headers["HardDisks"]).GetValue<string>().Split(';').Select(x => new HardDisk
            {
                Name = x.Split('|')[0],
                Capacity = int.Parse(x.Split('|')[1]),
                SerialNumber = x.Split('|')[2]
            }).ToArray(),
            OpticalDrive = row.Cell(headers["OpticalDrive"]).GetValue<string>(),
            MacAddress = row.Cell(headers["MacAddress"]).GetValue<string>(),
            SealNumber1 = row.Cell(headers["SealNumber1"]).GetValue<string>(),
            SealNumber2 = row.Cell(headers["SealNumber2"]).GetValue<string>(),
            OperatingSystem = row.Cell(headers["OperatingSystem"]).GetValue<string>(),
            LastSecurityUpdate = row.Cell(headers["LastSecurityUpdate"]).GetValue<string>(),
            Programs = row.Cell(headers["Programs"]).GetValue<string>().Split(';')
        };
    }
}
