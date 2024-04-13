using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bazooka.Customers.Api.Models;

namespace Bazooka.Customers.Api.Infrastructure.Repositories;
public interface ICustomerRepository
{
    IUnitOfWork UnitOfWork {get;}
    Customer? GetCustomerById(int id);
    Customer? GetCustomerByEmail(string emailAddress);
    Customer Add(Customer customer);


}
