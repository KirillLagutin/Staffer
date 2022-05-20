namespace Staffer.BackEnd;

public record Staffer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Department { get; set; }
    public string Position { get; set; }
}