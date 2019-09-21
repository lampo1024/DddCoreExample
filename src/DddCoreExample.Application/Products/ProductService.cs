using System;
using AutoMapper;
using DddCoreExample.Domain.Models.Products;
using DddCoreExample.Domain.Repository;

namespace DddCoreExample.Application.Products
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductCode> _productCodeRepository;
        private readonly IMapper _mapper;

        public ProductService(IRepository<Product> productRepository, IRepository<ProductCode> productCodeRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productRepository = productRepository;
            _productCodeRepository = productCodeRepository;
            _mapper = mapper;
        }

        public ProductDto Get(Guid productId)
        {
            var product = _productRepository.FindById(productId);
            return _mapper.Map<Product, ProductDto>(product);
        }

        public ProductDto Add(ProductDto productDto)
        {
            var productCode = _productCodeRepository.FindById(productDto.ProductCodeId);
            if (productCode == null)
            {
                throw new Exception("Product Code Is Not Valid");
            }

            var product = Product.Create(productDto.Name, productDto.Quantity, productDto.Cost, productCode);

            _productRepository.Add(product);
            return _mapper.Map<Product, ProductDto>(product);
        }

    }
}
