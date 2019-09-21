using System;
using AutoMapper;
using DddCoreExample.Api.Models;
using DddCoreExample.Application.Customers;
using Microsoft.AspNetCore.Mvc;

namespace DddCoreExample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public Response<CustomerDto> Get(Guid id)
        {
            var response = new Response<CustomerDto>();
            var customer = _customerService.Get(id);
            response.Object = customer;
            return response;
        }
    }
}