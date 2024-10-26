using AutoMapper;
using MiniAKS_Database.Dtos;
using MiniAKS_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAKS_Database.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<Station, StationDto>();
            CreateMap<Item, ItemDto>();
            CreateMap<Order, OrderDto>();
            CreateMap<Customization, CustomizationDto>();
        }
    }
}
