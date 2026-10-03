namespace Service.Dtos;

public sealed record Computer
{
    public string AssetCode { get; set; } = null!;
    public required string ComputerName { get; set; }
    public string MainBoard { get; set; } = null!;
    public required string Cpu { get; set; }
    public required int Ram { get; set; }
    public string Vga { get; set; } = null!;
    public string OpticalDrive { get; set; } = null!;
    public required string MacAddress { get; set; }
    public string SealNumber1 { get; set; } = null!;
    public string SealNumber2 { get; set; } = null!;
    public required string OperatingSystem { get; set; }
    public string LastSecurityUpdate { get; set; } = null!;
    public string[] Programs { get; set; } = null!;
    public HardDisk[] HardDisks { get; set; }
}