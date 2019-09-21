using AutoMapper;
using DddCoreExample.Application.Carts;
using DddCoreExample.Application.Customers;
using DddCoreExample.Application.History;
using DddCoreExample.Application.Products;
using DddCoreExample.Domain;
using DddCoreExample.Domain.Models.Carts;
using DddCoreExample.Domain.Models.Customers;
using DddCoreExample.Domain.Models.Products;
using DddCoreExample.Domain.Models.Purchases;

namespace DddCoreExample.Api.Extensions.AutoMapperConfig
{
    public class DddCoreMapperProfile : Profile
    {
        public DddCoreMapperProfile()
        {
            CreateMap<Cart, CartDto>();
            CreateMap<CartProduct, CartProductDto>();

            CreateMap<Purchase, CheckOutResultDto>()
                .ForMember(x => x.PurchaseId, options => options.MapFrom(x => x.Id));

            CreateMap<CreditCard, CreditCardDto>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<CustomerPurchaseHistoryReadModel, CustomerPurchaseHistoryDto>();
            CreateMap<DomainEventRecord, EventDto>();
        }
    }
}
