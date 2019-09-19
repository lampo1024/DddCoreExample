using System;
using AutoMapper;
using DddCoreExample.Domain.Models.Carts;
using DddCoreExample.Domain.Models.Customers;
using DddCoreExample.Domain.Models.Products;
using DddCoreExample.Domain.Models.Purchases;
using DddCoreExample.Domain.Repository;
using DddCoreExample.Domain.Services;
using DddCoreExample.Domain.Specification.Carts;

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
        private IMapper _mapper;

        public CartService(IRepository<Customer> customerRepository, IRepository<Product> productRepository, IRepository<Cart> cartRepository, IUnitOfWork unitOfWork, TaxService taxService, CheckoutService checkoutDomainService, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _cartRepository = cartRepository;
            _unitOfWork = unitOfWork;
            _taxService = taxService;
            _checkoutDomainService = checkoutDomainService;
            _mapper = mapper;
        }

        #region Implementation of ICartService

        public CartDto Add(Guid customerId, CartProductDto productDto)
        {
            CartDto cartDto = null;
            var customre = _customerRepository.FindById(customerId);
            if (customre == null)
            {
                throw new Exception(String.Format("Customer was not found with this Id: {0}", customerId));
            }

            var cart = _cartRepository.FindOne(new CustomerCartSpec(customerId));
            if (cart == null)
            {
                cart = Cart.Create(customre);
                _cartRepository.Add(cart);
            }

            var product = _productRepository.FindById(productDto.ProductId);
            validateProduct(product.Id, product);

            cart.Add(CartProduct.Create(customre, cart, product, productDto.Quantity, _taxService));
            cartDto = _mapper.Map<Cart, CartDto>(cart);
            _unitOfWork.Commit();
            return cartDto;
        }

        public CartDto Remove(Guid customerId, Guid productId)
        {
            CartDto cartDto = null;
            var cart = _cartRepository.FindOne(new CustomerCartSpec(customerId));
            validateCart(customerId, cart);

            var product = _productRepository.FindById(productId);
            validateProduct(productId, product);

            cart.Remove(product);

            cartDto = _mapper.Map<Cart, CartDto>(cart);

            _unitOfWork.Commit();
            return cartDto;
        }

        public CartDto Get(Guid customerId)
        {
            var cart = _cartRepository.FindOne(new CustomerCartSpec(customerId));
            validateCart(customerId, cart);

            return _mapper.Map<Cart, CartDto>(cart);
        }

        public CheckOutResultDto CheckOut(Guid customerId)
        {
            var checkOutResultDto = new CheckOutResultDto();

            var cart = _cartRepository.FindOne(new CustomerCartSpec(customerId));
            validateCart(customerId, cart);

            var customer = _customerRepository.FindById(customerId);

            var checkOutIssue = _checkoutDomainService.CanCheckOut(customer, cart);

            if (!checkOutIssue.HasValue)
            {
                var purchase = _checkoutDomainService.Checkout(customer, cart);
                checkOutResultDto = _mapper.Map<Purchase, CheckOutResultDto>(purchase);
                _unitOfWork.Commit();
            }
            else
            {
                checkOutResultDto.CheckOutIssue = checkOutIssue;
            }

            return checkOutResultDto;
        }

        #endregion

        private void validateCart(Guid customerId, Cart cart)
        {
            if (cart == null)
                throw new Exception(String.Format("Customer was not found with this Id: {0}", customerId));
        }

        private void validateProduct(Guid productId, Product product)
        {
            if (product == null)
                throw new Exception(String.Format("Product was not found with this Id: {0}", productId));
        }
    }
}
