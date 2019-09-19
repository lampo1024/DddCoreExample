using System;
using System.Linq.Expressions;

namespace DddCoreExample.Domain.Specification.Customers
{
    public class CustomerRegisteredSpec : SpecificationBase<Models.Customers.Customer>
    {
        private readonly Guid _id;

        public CustomerRegisteredSpec(Guid id)
        {
            _id = id;
        }

        public override Expression<Func<Models.Customers.Customer, bool>> SpecExpression
        {
            get
            {
                return customer => customer.Id == this._id;
            }
        }
    }
}
