using System;
using System.Linq.Expressions;
using DddCoreExample.Domain.Models.Tax;

namespace DddCoreExample.Domain.Specification.Tax
{
    public class CountryTypeOfTaxSpec : SpecificationBase<CountryTax>
    {
        readonly Guid _countryId;
        readonly TaxType _taxType;

        public CountryTypeOfTaxSpec(Guid countryId, TaxType taxType)
        {
            this._countryId = countryId;
            this._taxType = taxType;
        }

        public override Expression<Func<CountryTax, bool>> SpecExpression
        {
            get
            {
                return countryTax => countryTax.Country.Id == this._countryId
                                     && countryTax.Type == this._taxType;
            }
        }

        public override bool Equals(object obj)
        {
            CountryTypeOfTaxSpec countryTypeOfTaxSpecCompare = obj as CountryTypeOfTaxSpec;
            if (countryTypeOfTaxSpecCompare == null)
                throw new InvalidCastException("obj");

            return countryTypeOfTaxSpecCompare._countryId == this._countryId &&
                   countryTypeOfTaxSpecCompare._taxType == this._taxType;
        }
    }
}
