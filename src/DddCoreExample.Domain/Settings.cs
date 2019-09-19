using DddCoreExample.Domain.Models.Countries;

namespace DddCoreExample.Domain
{
    public sealed class Settings
    {
        public Country BusinessCountry { get; }

        public Settings()
        {

        }

        public Settings(Country businessCountry)
        {
            this.BusinessCountry = businessCountry;
        }
    }
}
