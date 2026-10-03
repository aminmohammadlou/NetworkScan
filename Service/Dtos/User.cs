namespace Service.Dtos;

public sealed record User
{
    public int EmployeeCode { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string MembershipType { get; set; }
    public required string NationalNumber { get; set; }
    public required string Job { get; set; }
    public required string PhoneNumber { get; set; }
}
