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

        /// <summary>
        /// Get a customer by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // http://localhost:42921/api/customer/find?id=5D5020DA-47DF-4C82-A722-C8DEAF06AE23
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

        /// <summary>
        /// Create a customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        // http://localhost:42921/api/customer/create?FirstName=john2&LastName=smith2&Email=john2.smith2@microsoft.com&CountryId=F3C78DD5-026F-4402-8A19-DAA956ACE593
        public Response<CustomerDto> Create([FromQuery] CustomerDto customer)
        {
            var response = new Response<CustomerDto>();
            try
            {
                response.Object = _customerService.Add(customer);
            }
            catch (Exception ex)
            {
                response.Errored = true;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
    }
}