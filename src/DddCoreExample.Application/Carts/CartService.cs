using System;
using DddCoreExample.Domain.Models.Carts;
using DddCoreExample.Domain.Models.Customers;
using DddCoreExample.Domain.Models.Products;
using DddCoreExample.Domain.Repository;
using DddCoreExample.Domain.Services;

namespace DddCoreExample.Application.Carts
{
    public class CartService : ICartService
    {
        private IRepository<Customer> _customerRepository;
        private IRepository<Product> _productRepository;
        private IRepository<Cart> _cartRepository;
        private IUnitOfWork _unitOfWork;
        private TaxService _taxService;
        CheckoutService _checkoutDomainService;

        public CartService(IRepository<Customer> customerRepository, IRepository<Product> productRepository, IRepository<Cart> cartRepository, IUnitOfWork unitOfWork, TaxService taxService, CheckoutService checkoutDomainService)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _cartRepository = cartRepository;
            _unitOfWork = unitOfWork;
            _taxService = taxService;
            _checkoutDomainService = checkoutDomainService;
        }

        #region Implementation of ICartService

        public CartDto Add(Guid customerId, CartProductDto cartProductDto)
        {
            throw new NotImplementedException();
        }

        public CartDto Remove(Guid customerId, Guid productId)
        {
            throw new NotImplementedException();
        }

        public CartDto Get(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public CheckOutResultDto CheckOut(Guid customerId)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
