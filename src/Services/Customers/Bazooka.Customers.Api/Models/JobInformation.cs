namespace Bazooka.Customers.Api.Models;

public class JobInformation
{
    public string? Occuption { get; set; }
    public string? Employeer { get; set; }
    public decimal BasicSalary { get; set; }
    public decimal Allownace  { get; set; }
    public decimal TotalSalary => BasicSalary+ Allownace;
    

}