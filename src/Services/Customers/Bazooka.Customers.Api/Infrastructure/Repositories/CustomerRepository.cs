using Bazooka.Customers.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Bazooka.Customers.Api.Infrastructure.Repositories;

public class CustomerRepository:ICustomerRepository
{
     private readonly CustomersContext _customersContext;
     public CustomerRepository(CustomersContext customersContext )
     {
        _customersContext =customersContext;
     }
    public IUnitOfWork UnitOfWork => _customersContext;
    public Customer? GetCustomerById(int id)
    {
        return _customersContext.Customers.AsNoTracking().FirstOrDefault(s=>s.Id==id);
    }

    public Customer? GetCustomerByEmail(string emailAddress)
    {
        return _customersContext.Customers.AsNoTracking().Where(s => s.EmailAddress == emailAddress)!.FirstOrDefault()?? null;
    }

    public Customer Add(Customer customer)
    {
        return _customersContext.Customers.Add(customer).Entity;
    }
}
