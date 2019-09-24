using System;
using DddCoreExample.Api.Models;
using DddCoreExample.Application.Customers;
using Microsoft.AspNetCore.Mvc;

namespace DddCoreExample.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public Response<CustomerDto> Find(Guid id)
        {
            var response = new Response<CustomerDto>();
            try
            {
                var customer = _customerService.Get(id);
                response.Object = customer;
            }
            catch (Exception e)
            {
                response.Errored = true;
                response.ErrorMessage = e.ToString();
            }

            return response;
        }
    }
}