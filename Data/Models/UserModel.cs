namespace Data.Models;

public class UserModel
{
    public int UserId { get; init; }
    public required int EmployeeCode { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedTime { get; init; }
    public DateTime UpdatedTime { get; set; }

}
