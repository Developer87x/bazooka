using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bazooka.Customers.Api.Models;
using Bazooka.Customers.Api.Models.Dto;

namespace Bazooka.Customers.Api.Applications.Mappings
{
    public class ApplicationProfile :Profile
    {
        public ApplicationProfile()
        {
            this.CreateMap<Customer,CustomerDto>().ReverseMap();
        }
    }
}