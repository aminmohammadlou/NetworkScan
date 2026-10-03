using ClosedXML.Excel;
using Service.DtoConverters;
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
            .Select(x => x.ToUser(headers))
            .ToArray();
    }

    public Computer[] ReadComputers(string filePath)
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
            .Select(x => x.ToComputer(headers))
            .ToArray();
    }
}