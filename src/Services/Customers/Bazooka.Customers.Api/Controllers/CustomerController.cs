using System.Net;
using AutoMapper;
using Bazooka.Customers.Api.Infrastructure.Repositories;
using Bazooka.Customers.Api.Infrastructure.Services;
using Bazooka.Customers.Api.Models;
using Bazooka.Customers.Api.Models.Dto;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Bazooka.Customers.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly IValidator<Customer> _customerValidator;
    private readonly IMapper _mapper;
    private readonly ILogger<CustomerController> _customerLogger;
    
    private readonly ICustomerService _customerService;
    public CustomerController(IValidator<Customer> customerValidator, ILogger<CustomerController> customerLogger, ICustomerService customerService, IMapper mapper)
    {
        _customerValidator = customerValidator;
        _customerService = customerService;
        _customerLogger= customerLogger;
        _mapper = mapper;
    }

    [HttpGet("GetCustomer/{id:int}")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public IActionResult GetCustomer(int id)
    {
        _customerLogger.LogInformation("Service has been started..");
        var result = _customerService.GetCustomer(id);
        if(result is null)
        return NotFound(new ResponseDto()
                        {
                            Success = false,
                            Data = $"user is not existing in our system"
                        });
        
        CustomerDto customer = _mapper.Map<CustomerDto>(result);
        _customerLogger.Log(LogLevel.Information,"reterive data {@cusomer}",customer);
        return Ok(new ResponseDto()
        {
            Success=true,
            Data= customer
        });
    }
    [HttpPost("Create")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public IActionResult Create([FromBody] CustomerDto customerModel)
    {
        Customer customer = _mapper.Map<Customer>(customerModel);
        ValidationResult customerValidation = _customerValidator.Validate(customer);
        switch (customerValidation.IsValid)
        {
            case true:
                {
                    bool isExistingCustomer = _customerService.IsExistUser(customer.EmailAddress!);
                    if (!isExistingCustomer)
                        return NotFound(new ResponseDto()
                        {
                            Success = false,
                            Data = $"{customer.EmailAddress} is existing in our system"
                        });
                    Task<bool> result = _customerService.CreateNewCustomer(customer);
                    return Ok(new ResponseDto()
                    {
                        Success = result.Result,
                        Data = "Customer has been created successfully"
                    });
                }
            default:
                return BadRequest(new ResponseDto()
                {
                    Success = false,
                    Data = $"customer has not been created please contact us through our contact channels"
                });
        }
    }
}

