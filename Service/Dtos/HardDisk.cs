namespace Service.Dtos;

public sealed record HardDisk
{
    public required string Name { get; set; }
    public required int Capacity { get; set; }
    public required string SerialNumber { get; set; }
}