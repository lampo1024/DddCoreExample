using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DddCoreExample.Domain.Specification.Customers
{
    public class CustomerBulkIdFindSpec : SpecificationBase<Models.Customers.Customer>
    {
        readonly IEnumerable<Guid> _customerIds;

        public CustomerBulkIdFindSpec(IEnumerable<Guid> customerIds)
        {
            this._customerIds = customerIds;
        }

        public override Expression<Func<Models.Customers.Customer, bool>> SpecExpression
        {
            get
            {
                return customer => this._customerIds.Contains(customer.Id);
            }
        }
    }
}
