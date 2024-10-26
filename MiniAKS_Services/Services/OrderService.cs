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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ISalesChannelService _salesChannelService;
        private readonly ICustomizationService _customizationService;
        private readonly IStationQueueService _stationQueueService;
        private readonly IProductService _productService;
        public OrderService(IOrderRepository orderRepository, ISalesChannelService salesChannelService,
            ICustomizationService customizationService,
            IStationQueueService stationQueueService,
            IProductService productService ,IMapper mapper)
        {
            _orderRepository = orderRepository;
            _salesChannelService = salesChannelService;
            _customizationService = customizationService;
            _stationQueueService = stationQueueService;
            _productService = productService;
            _mapper = mapper;
        }

        public bool CreateOrder(OrderDto orderDto)
        {
            SalesChannel salesChannel = _salesChannelService.GetSalesCannelByName(orderDto.SalesChannel);
            if (!salesChannel.IsActive)
            {
                return false;
            }
            Order order = MapDtoToModel(orderDto);
            _orderRepository.CreateOrder(order);
            foreach(var orderProductDto in orderDto.OrderProducts)
            {
                var productItems = _productService.GetProductItems(orderProductDto.ProductId);
                foreach (var productItem in productItems)
                {
                    var totalItemQuantity = orderProductDto.Quantity * productItem.Quantity;
                    _stationQueueService.AddOrUpdateStationQueue(productItem.Item.StationId, productItem.ItemId, totalItemQuantity);
                }

            }
            return true;
        }

        public OrderDto GetOrder(Guid id)
        {
           return _mapper.Map<OrderDto>(_orderRepository.GetOrder(id));
        }

        public ICollection<OrderDto> GetOrders()
        {
            return _mapper.Map<ICollection<OrderDto>>(_orderRepository.GetOrders());
        }

        public ICollection<ProductDto> GetProductsForOrder(Guid orderId)
        {
            return _mapper.Map<ICollection<ProductDto>>(_orderRepository.GetProductsForOrder(orderId));
        }

        private Order MapDtoToModel(OrderDto orderDto)
        {
            Guid newOrderId = Guid.NewGuid();
            return new Order
            {
                Id = newOrderId,
                OrderNumber = orderDto.OrderNumber,
                PlacedOn = orderDto.PlacedOn,
                PrintedOn = orderDto.PrintedOn,
                CompletedOn = orderDto.CompletedOn,
                OrderProducts = orderDto.OrderProducts.Select(op => MapOrderProduct(op, newOrderId)).ToList()
            };
        }

        private OrderProduct MapOrderProduct(OrderProductDto orderProductDto, Guid orderId)
        {
            return new OrderProduct
            {
                OrderId = orderId,
                ProductId = orderProductDto.ProductId,
                Quantity = orderProductDto.Quantity,
                OrderProductCustomizations = orderProductDto.Customizations.Select(code => 
                MapOrderProductCustomization(code, orderId,
                orderProductDto.ProductId))
                .ToList()
            };
        }

        private OrderProductCustomization MapOrderProductCustomization(string code, Guid orderId, Guid productId)
        {
            CustomizationDto customizationDto = _customizationService.GetCustomazationByCode(code);

            return new OrderProductCustomization
            {
                OrderId = orderId,
                ProductId = productId,
                CustomizationId = customizationDto.Id,
            };
        }

    }
}




//public Order MapDtoToModel(OrderDto orderDto)
//{
//    Guid newOrderId = Guid.NewGuid();
//   return new Order
//    {
//        Id = newOrderId,
//        OrderNumber = orderDto.OrderNumber,
//        PlacedOn = orderDto.PlacedOn,
//        PrintedOn = orderDto.PrintedOn,
//        CompletedOn = orderDto.CompletedOn,
//        OrderProducts = orderDto.OrderProducts.Select(op => new OrderProduct
//        {
//            OrderId = newOrderId, 
//            ProductId = op.ProductId,
//            Quantity = op.Quantity,
//            OrderProductCustomizations = op.Customizations.Select(code => {
//                CustomizationDto customizationDto = _customizationService.GetCustomazationByCode(code);
//                return new OrderProductCustomization
//                {
//                    OrderId = newOrderId,
//                    ProductId = op.ProductId,
//                    CustomizationId = customizationDto.Id,
//                };
//            }).ToList()
//        }).ToList()
//    };
//}
