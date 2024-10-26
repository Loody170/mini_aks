using AutoMapper;
using MiniAKS_Database.Dtos;
using MiniAKS_Database.Repositories;
using MiniAKS_Database.Repositories.Interfaces;
using MiniAKS_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAKS_Services.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public ItemService(IItemRepository itemRepository, IMapper mapper)
        {              
            _itemRepository = itemRepository;
            _mapper = mapper;
        }
        public ItemDto GetItem(Guid id)
        {
            return _mapper.Map<ItemDto>(_itemRepository.GetItem(id));
        }

        public ICollection<ItemDto> GetItems()
        {
            return _mapper.Map<ICollection<ItemDto>>(_itemRepository.GetItems());
        }

        public ICollection<ProductDto> GetProductsByItemId(Guid id)
        {
            return _mapper.Map<ICollection<ProductDto>>(_itemRepository.GetProductsByItemId(id));
        }
    }
}
