using AutoMapper;
using Bazooka.Customers.Api.Models;
using Bazooka.Customers.Api.Models.Dto;

namespace Bazooka.Customers.Api.Applications.Mappings;

public class ApplicationProfile : Profile
{
    public ApplicationProfile()
    {
        CreateMap<Customer, CustomerDto>().ReverseMap();
        CreateMap<Address, AddressDto>().ReverseMap();
        CreateMap<PersonalInformation, PersonalInformationDto>().ReverseMap();
        CreateMap<JobInformation, JobInformationDto>().ReverseMap();
    }

}
