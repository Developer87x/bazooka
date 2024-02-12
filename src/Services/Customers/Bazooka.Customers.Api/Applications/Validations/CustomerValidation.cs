using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bazooka.Customers.Api.Models;
using FluentValidation;

namespace Bazooka.Customers.Api.Applications.Validations
{
    public class CustomerValidation :AbstractValidator<Customer>
    {
        public CustomerValidation()
        {
            RuleFor(s=>s.EmailAddress).NotNull().EmailAddress();
        }
    }
}