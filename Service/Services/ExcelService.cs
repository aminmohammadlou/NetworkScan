using ClosedXML.Excel;
using Service.Dtos;

namespace Service.Services;

public class ExcelService
{
    public User[] ReadUsers(string filePath)
    {
        using var workbook = new XLWorkbook(filePath);
        var worksheet = workbook.Worksheet(1);

        var headerRow = worksheet.FirstRowUsed();
        ArgumentNullException.ThrowIfNull(headerRow);

        var headers = headerRow
            .CellsUsed()
            .ToDictionary(
                cell => cell.GetString().Trim(),
                cell => cell.Address.ColumnNumber);

        return worksheet.RowsUsed().Skip(1)
            .Select(row => new User
            {
                EmployeeCode = row.Cell(headers["EmployeeCode"]).GetValue<int>(),
                FirstName = row.Cell(headers["FirstName"]).GetValue<string>(),
                LastName = row.Cell(headers["LastName"]).GetValue<string>(),
                MembershipType = row.Cell(headers["MembershipType"]).GetValue<string>(),
                NationalNumber = row.Cell(headers["NationalNumber"]).GetValue<string>(),
                Job = row.Cell(headers["Job"]).GetValue<string>(),
                PhoneNumber = row.Cell(headers["PhoneNumber"]).GetValue<string>()
            }).ToArray();
    }
}