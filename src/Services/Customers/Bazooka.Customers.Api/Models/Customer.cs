namespace Bazooka.Customers.Api.Models;

public class Customer
{
    public int Id { get; set; }
    public string? UserId { get; set; }
    public string?  FirstName { get; set; }
    public string?  MiddleName { get; set; }
    public string? LastName { get; set; }
    public CustomerType CustomerType { get; set; }
    public Gender Gender { get; set; }
    public DateTime Birthdate { get; set; } 
    public string? EmailAddress { get; set; }
    public Address? Address { get; set; }
    public PersonalInformation? PersonalInformation { get; set; }
    public JobInformation? JobInformation { get; set; }
}
