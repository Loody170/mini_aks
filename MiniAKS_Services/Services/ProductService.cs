using AutoMapper;
using MiniAKS_Database.Dtos;
using MiniAKS_Database.Models;
using MiniAKS_Database.Repositories.Interfaces;
using MiniAKS_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAKS_Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            
        }
        public ProductDto GetProduct(Guid id)
        {
            return _mapper.Map<ProductDto>(_productRepository.GetProduct(id));
        }

        public ICollection<ProductItem> GetProductItems(Guid id)
        {
            return _productRepository.GetProductItems(id);
        }

        public ICollection<ProductDto> GetProducts()
        {
            return _mapper.Map<ICollection<ProductDto>>(_productRepository.GetProducts());

        }
    }
}
