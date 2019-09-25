using System.Collections.Generic;
using DddCoreExample.Application.Customers;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DddCoreExample.Api.Pages.Customer
{
    public class ListModel : PageModel
    {
        private readonly ICustomerService _customerService;

        public ListModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public List<CustomerDto> Customers { get; set; }
        public void OnGet()
        {
            Customers = _customerService.FindAll();
        }
    }
}