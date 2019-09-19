using System;
using DddCoreExample.Domain.Models.Customers;

namespace DddCoreExample.Domain.Models.Products
{
    public class Return
    {
        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ReturnReason Reason { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual string Note { get; set; }
    }
}
