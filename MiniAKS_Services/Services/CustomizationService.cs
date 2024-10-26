using AutoMapper;
using MiniAKS_Database.Dtos;
using MiniAKS_Database.Repositories.Interfaces;
using MiniAKS_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAKS_Services.Services
{
    public class CustomizationService : ICustomizationService
    {
        private readonly ICustomizationRepository _customizationRepository;
        private readonly IMapper _mapper;
        public CustomizationService(ICustomizationRepository customizationRepository, IMapper mapper)
        {
            _customizationRepository = customizationRepository;
            _mapper = mapper;
            
        }
        public CustomizationDto GetCustomization(Guid id)
        {
            return _mapper.Map<CustomizationDto>(_customizationRepository.GetCustomization(id));
        }

        public ICollection<CustomizationDto> GetCustomizations()
        {
            return _mapper.Map<ICollection<CustomizationDto>>(_customizationRepository.GetCustomizations());
        }

        public ICollection<CustomizationDto> GetCustomizationForAProductInAnOrder(Guid orderId, Guid productId)
        {
           return _mapper.Map<ICollection<CustomizationDto>>(_customizationRepository.GetCustomizationForAProductInAnOrder(orderId, productId));
        }

        public CustomizationDto GetCustomazationByCode(string code)
        {
            int codeInt = int.Parse(code);
            return _mapper.Map<CustomizationDto>(_customizationRepository.GetCustomazationByCode(codeInt));
        }
    }
}
