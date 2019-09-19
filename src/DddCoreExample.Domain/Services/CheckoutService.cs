using System;
using DddCoreExample.Domain.Events.CustomerEvents;
using DddCoreExample.Domain.Models.Carts;
using DddCoreExample.Domain.Models.Customers;
using DddCoreExample.Domain.Models.Products;
using DddCoreExample.Domain.Models.Purchases;
using DddCoreExample.Domain.Repository;
using DddCoreExample.Domain.Services.Enums;
using DddCoreExample.Domain.Specification.Product;

namespace DddCoreExample.Domain.Services
{
    public class CheckoutService : IDomainService
    {
        private IRepository<Purchase> _purchaseRepository;
        private IRepository<Product> _productRepository;

        public CheckoutService(IRepository<Purchase> purchaseRepository, IRepository<Product> productRepository)
        {
            _purchaseRepository = purchaseRepository;
            _productRepository = productRepository;
        }

        public PaymentStatus CustomerCanPay(Customer customer)
        {
            if (customer.Balance <= 0)
            {
                return PaymentStatus.UnpaidBalance;
            }
            if (customer.GetCreditCardsAvailable().Count == 0)
                return PaymentStatus.NoActiveCreditCardAvailable;

            return PaymentStatus.OK;
        }

        public ProductState ProductCanBePurchased(Cart cart)
        {
            var faultyProductSpec = new ProductReturnReasonSpec(ReturnReason.Faulty);
            foreach (var cartProduct in cart.Products)
            {
                var product = _productRepository.FindById(cartProduct.ProductId);
                if (product == null)
                    throw new Exception($"Product {cartProduct.ProductId} not found");

                var isInStock = new ProductIsInStockSpec(cartProduct).IsSatisfiedBy(product);

                if (!isInStock)
                    return ProductState.NotInStock;

                var isFaulty = faultyProductSpec.IsSatisfiedBy(product);

                if (isFaulty)
                    return ProductState.IsFaulty;
            }
            return ProductState.OK;
        }

        public CheckOutIssue? CanCheckOut(Customer customer, Cart cart)
        {
            var paymentStatus = this.CustomerCanPay(customer);
            if (paymentStatus != PaymentStatus.OK)
                return (CheckOutIssue)paymentStatus;

            var productState = this.ProductCanBePurchased(cart);
            if (productState != ProductState.OK)
                return (CheckOutIssue)productState;

            return null;
        }

        public Purchase Checkout(Customer customer, Cart cart)
        {
            var checkoutIssue = this.CanCheckOut(customer, cart);
            if (checkoutIssue.HasValue)
                throw new Exception(checkoutIssue.Value.ToString());

            var purchase = Purchase.Create(cart);

            _purchaseRepository.Add(purchase);

            cart.Clear();

            DomainEvents.Raise(new CustomerCheckedOut(purchase));

            return purchase;
        }
    }
}
