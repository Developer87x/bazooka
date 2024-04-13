using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bazooka.Customers.Api.Infrastructure.Repositories;
using Bazooka.Customers.Api.Models;

namespace Bazooka.Customers.Api.Infrastructure.Services
{
    public interface ICustomerService
    {
        Task<bool> CreateNewCustomer(Customer newCustomer);
        bool IsExistUser(string email);
        Customer? GetCustomer(int CustomerId);
    }
    public class CustomerService : ICustomerService
    {
        private readonly ILogger<CustomerService> _customerServiceLogger;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository,ILogger<CustomerService> customerServiceLogger)
        {
            _customerRepository = customerRepository;
            _customerServiceLogger=customerServiceLogger;
        }
        public async Task<bool> CreateNewCustomer(Customer newCustomer)
        {
            try
            {
                Customer customer = _customerRepository.Add(newCustomer);
                int result = await _customerRepository.UnitOfWork.SaveChangesAsync();
                if (result > 0)
                    return true;
                return false;
            }
            catch (Exception exception)
            {
                _customerServiceLogger.Log(LogLevel.Error, exception,exception.Message);
               throw new Exception(exception.Message);
            }
        }
        public Customer? GetCustomer(int CustomerId)
        {
            try
            {
                Customer? customer = _customerRepository.GetCustomerById(CustomerId);

                return customer ?? null;
            }
            catch (System.Exception ex)
            {
                // TODO
                throw;
            }
        }

        public bool IsExistUser(string email)
        {
            try
            {
                Customer? existingCustomer = _customerRepository.GetCustomerByEmail(email);
                return existingCustomer is null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}