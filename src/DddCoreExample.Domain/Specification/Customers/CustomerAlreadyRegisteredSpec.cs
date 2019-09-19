using System;
using System.Linq.Expressions;

namespace DddCoreExample.Domain.Specification.Customers
{
    public class CustomerAlreadyRegisteredSpec : SpecificationBase<Models.Customers.Customer>
    {
        readonly string _email;

        public CustomerAlreadyRegisteredSpec(string email)
        {
            this._email = email;
        }

        public override Expression<Func<Models.Customers.Customer, bool>> SpecExpression
        {
            get
            {
                return customer => customer.Email == this._email;
            }
        }
    }
}
