using System;
using DddCoreExample.Domain.Models.Carts;

namespace DddCoreExample.Application.Carts
{
    public class CheckOutResultDto
    {
        public Guid? PurchaseId { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalTax { get; set; }
        public CheckOutIssue? CheckOutIssue { get; set; }
    }
}
