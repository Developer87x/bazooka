namespace Bazooka.Customers.Api.Models.Dto;

public record CustomerDto
{
    public string? EmailAddress { get; set; }
    public int CustomerType { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int Gender { get; set; }
    public DateTime Birthdate { get; set; }
    public AddressDto? Address { get; set; }
    public JobInformationDto? JobInformation { get; set; }
    public PersonalInformation? PersonalInformation { get; set; }
}

public record AddressDto
{
    public string? Country { get; set; }
    public string? City { get; set; }
    public string? Location { get; set; }
    public string? Street { get; set; }
    public string? BuildingNo { get; set; }
    public string? PostalCode { get; set; }
}

public record PersonalInformationDto
{
    public string? Nationality { get; set; }
    public string? IDNumber { get;  set; }
}

public record JobInformationDto
{
    public string? Occuption { get; set; }
    public string? Employeer { get; set; }
    public decimal BasicSalary { get; set; } = 0M;
    public decimal Allownace  { get; set; } =0M;
}

public record PersonalInfromationDto
{
    public string? Nationality { get; set; }
    public string? IDNumber { get; set; }
}