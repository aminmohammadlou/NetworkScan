namespace Data.Models;

public class HardDiskModel
{
    public int HardDiskId { get; init; }
    public required string Name { get; set; }
    public required int Capacity { get; set; }
    public required string SerialNumber { get; set; }
    public required int ComputerId { get; set; }
    public ComputerModel Computer { get; set; }
}