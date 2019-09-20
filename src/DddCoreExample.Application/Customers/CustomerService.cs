using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DddCoreExample.Domain.Models.Countries;
using DddCoreExample.Domain.Models.Customers;
using DddCoreExample.Domain.Models.Purchases;
using DddCoreExample.Domain.Repository;
using DddCoreExample.Domain.Specification;
using DddCoreExample.Domain.Specification.Customers;
using DddCoreExample.Domain.Specification.Purchases;

namespace DddCoreExample.Application.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Country> _countryRepository;
        private readonly IRepository<Purchase> _purchaseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(IRepository<Customer> customerRepository, IRepository<Country> countryRepository, IRepository<Purchase> purchaseRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _countryRepository = countryRepository;
            _purchaseRepository = purchaseRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Implementation of ICustomerService

        public bool IsEmailAvailable(string email)
        {
            var alreadyRegisteredSpec = new CustomerAlreadyRegisteredSpec(email);
            var existingCustomer = _customerRepository.FindOne(alreadyRegisteredSpec);
            return existingCustomer == null;
        }

        public CustomerDto Add(CustomerDto customerDto)
        {
            var alreadyRegisteredSpec = new CustomerAlreadyRegisteredSpec(customerDto.Email);
            var existingCustomer = _customerRepository.FindOne(alreadyRegisteredSpec);
            if (existingCustomer != null)
                throw new Exception("Customer with this email already exists");
            var country = _countryRepository.FindById(customerDto.CountryId);
            var customer = Customer.Create(customerDto.FirstName, customerDto.LastName, customerDto.Email, country);
            _customerRepository.Add(customer);
            _unitOfWork.Commit();

            return _mapper.Map<Customer, CustomerDto>(customer);
        }

        public void Update(CustomerDto customerDto)
        {
            if (customerDto.Id == Guid.Empty)
                throw new Exception("Id can't be empty");


            var registeredSpec =
                new CustomerRegisteredSpec(customerDto.Id);

            var customer = _customerRepository.FindOne(registeredSpec);

            if (customer == null)
                throw new Exception("No such customer exists");

            customer.ChangeEmail(customerDto.Email);
            _unitOfWork.Commit();
        }

        public void Remove(Guid customerId)
        {
            ISpecification<Customer> registeredSpec =
                new CustomerRegisteredSpec(customerId);

            var customer = _customerRepository.FindOne(registeredSpec);

            if (customer == null)
                throw new Exception("No such customer exists");

            _customerRepository.Remove(customer);
            _unitOfWork.Commit();
        }

        public CustomerDto Get(Guid customerId)
        {
            ISpecification<Customer> registeredSpec =
                new CustomerRegisteredSpec(customerId);

            var customer = _customerRepository.FindOne(registeredSpec);

            return _mapper.Map<Customer, CustomerDto>(customer);
        }

        public CreditCardDto Add(Guid customerId, CreditCardDto creditCardDto)
        {
            ISpecification<Customer> registeredSpec =
                new CustomerRegisteredSpec(customerId);

            var customer = _customerRepository.FindOne(registeredSpec);

            if (customer == null)
                throw new Exception("No such customer exists");

            var creditCard =
                CreditCard.Create(customer, creditCardDto.NameOnCard,
                    creditCardDto.CardNumber, creditCardDto.Expiry);

            customer.Add(creditCard);

            _unitOfWork.Commit();

            return _mapper.Map<CreditCard, CreditCardDto>(creditCard);
        }

        public List<CustomerPurchaseHistoryDto> GetAllCustomerPurchaseHistoryV1()
        {
            var customersThatHavePurchasedSomething =
                _purchaseRepository.Find(new PurchasedNProductsSpec(1))
                    .Select(purchase => purchase.CustomerId)
                    .Distinct();

            var customers =
                _customerRepository.Find(new CustomerBulkIdFindSpec(customersThatHavePurchasedSomething));

            var customersPurchaseHistory =
                new List<CustomerPurchaseHistoryDto>();

            foreach (var customer in customers)
            {
                var customerPurchases =
                    _purchaseRepository.Find(new CustomerPurchasesSpec(customer.Id));

                var customerPurchaseHistory = new CustomerPurchaseHistoryDto
                {
                    CustomerId = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Email = customer.Email,
                    TotalPurchases = customerPurchases.Count(),
                    TotalProductsPurchased =
                        customerPurchases.Sum(purchase => purchase.Products.Sum(product => product.Quantity)),
                    TotalCost = customerPurchases.Sum(purchase => purchase.TotalCost)
                };
                customersPurchaseHistory.Add(customerPurchaseHistory);

            }
            return customersPurchaseHistory;
        }

        public List<CustomerPurchaseHistoryDto> GetAllCustomerPurchaseHistoryV2()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
