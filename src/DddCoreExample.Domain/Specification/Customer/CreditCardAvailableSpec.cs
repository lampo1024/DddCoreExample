using System;
using System.Linq.Expressions;
using DddCoreExample.Domain.Models.Customers;

namespace DddCoreExample.Domain.Specification.Customer
{
    public class CreditCardAvailableSpec : SpecificationBase<CreditCard>
    {
        #region Overrides of SpecificationBase<CreditCard>

        public override Expression<Func<CreditCard, bool>> SpecExpression
        {
            get { return cc => cc.Active && cc.Expiry >= dateTime; }
        }

        #endregion

        private readonly DateTime dateTime;

        public CreditCardAvailableSpec(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }

    }
}
