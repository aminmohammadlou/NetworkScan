namespace Service.Dtos;

public sealed record User
{
    public int EmployeeCode { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}
