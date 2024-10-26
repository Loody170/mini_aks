using Microsoft.EntityFrameworkCore;
using MiniAKS_Database.Models;

namespace MiniAKS_Database.Database;

public class Seed
{
    public static void SeedData(MiniAKSDbContext context)
    {
        if (!context.Stations.Any())
        {
            // Seeding stations
            var station1 = new Station
            {
                Id = Guid.NewGuid(),
                Name = "Pressured Fried Chicken",
                DisplayName = "PFC"
            };

            var station2 = new Station
            {
                Id = Guid.NewGuid(),
                Name = "NuggetSeaFood",
                DisplayName = "NSF"
            };

            var station3 = new Station
            {
                Id = Guid.NewGuid(),
                Name = "Vegetables",
                DisplayName = "Veg"
            };

            context.Stations.AddRange(station1, station2, station3);
            context.SaveChanges();

            // Seeding items
            var item1 = new Item
            {
                Id = Guid.NewGuid(),
                Name = "Bone Chicken",
                CreatedDate = DateTime.Now,
                HoldingTimeAfterCooking = 4,
                DrainageTime = 1,
                PreparationTime = 1,
                StationId = station1.Id
            };

            var item2 = new Item
            {
                Id = Guid.NewGuid(),
                Name = "Chicken Fillet Regular",
                CreatedDate = DateTime.Now,
                HoldingTimeAfterCooking = 3,
                DrainageTime = 1,
                PreparationTime = 1,
                StationId = station2.Id
            };

            var item3 = new Item
            {
                Id = Guid.NewGuid(),
                Name = "French Fries",
                CreatedDate = DateTime.Now,
                HoldingTimeAfterCooking = 5,
                DrainageTime = 0,
                PreparationTime = 1,
                StationId = station3.Id
            };

            context.Items.AddRange(item1, item2, item3);
            context.SaveChanges();

            // Seeding products
            var product1 = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Fried Chicken Regular 4pc Meal",
                CreatedDate = DateTime.Now,
            };

            var product2 = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Chicken Fillet Regular 7pc Meal",
                CreatedDate = DateTime.Now,
            };

            context.Products.AddRange(product1, product2);
            context.SaveChanges();

            // Seeding ProductItem (many-to-many)
            var productItem1 = new ProductItem
            {
                ProductId = product1.Id,
                ItemId = item1.Id,
                Quantity = 4

            };

            var productItem2 = new ProductItem
            {
                ProductId = product2.Id,
                ItemId = item2.Id,
                Quantity = 7
            };

            var productItem3 = new ProductItem
            {
                ProductId = product1.Id,
                ItemId = item3.Id,
                Quantity = 1
            };

            var productItem4 = new ProductItem
            {
                ProductId = product2.Id,
                ItemId = item3.Id,
                Quantity = 1
            };

            context.Set<ProductItem>().AddRange(productItem1, productItem2, productItem3, productItem4);
            context.SaveChanges();

            // Seeding customizations
            var customization1 = new Customization
            {
                Id = Guid.NewGuid(),
                Value = "No Salt fries",
                Code = 101,
                CreatedDate = DateTime.Now
            };

            var customization2 = new Customization
            {
                Id = Guid.NewGuid(),
                Value = "Seasoned Fries",
                Code = 102,
                CreatedDate = DateTime.Now
            };

            context.Customizations.AddRange(customization1, customization2);
            context.SaveChanges();

            // Seeding sales channels
            var salesChannel1 = new SalesChannel
            {
                Id = Guid.NewGuid(),
                Name = "Dine In",
                IsActive = true
            };

            var salesChannel2 = new SalesChannel
            {
                Id = Guid.NewGuid(),
                Name = "Pickup",
                IsActive = true
            };

            var salesChannel3 = new SalesChannel
            {
                Id = Guid.NewGuid(),
                Name = "Online",
                IsActive = false
            };

            context.SalesChannels.AddRange(salesChannel1, salesChannel2, salesChannel3);
            context.SaveChanges();

            // Seeding orders
            var order1 = new Order
            {
                Id = Guid.NewGuid(),
                OrderNumber = "01",
                PlacedOn = DateTime.Now,
                PrintedOn = DateTime.Now.AddMinutes(1),
                CompletedOn = DateTime.Now.AddMinutes(3),
            };

            var order2 = new Order
            {
                Id = Guid.NewGuid(),
                OrderNumber = "02",
                PlacedOn = DateTime.Now,
                PrintedOn = DateTime.Now.AddMinutes(1),
                CompletedOn = DateTime.Now.AddMinutes(5),
            };

            context.Orders.AddRange(order1, order2);
            context.SaveChanges();

            // Seeding OrderProduct (Order + Product relationship)
            var orderProduct1 = new OrderProduct
            {
                OrderId = order1.Id,
                ProductId = product1.Id,
                Quantity = 2
            };

            var orderProduct2 = new OrderProduct
            {
                OrderId = order2.Id,
                ProductId = product1.Id,
                Quantity = 1
            };

            var orderProduct3 = new OrderProduct
            {
                OrderId = order2.Id,
                ProductId = product2.Id,
                Quantity = 1
            };

            context.Set<OrderProduct>().AddRange(orderProduct1, orderProduct2, orderProduct3);
            context.SaveChanges();

            // Seeding OrderProductCustomization (many-to-many between OrderProduct and Customization)
            var orderProductCustomization1 = new OrderProductCustomization
            {
                OrderId = order2.Id,
                ProductId = product1.Id,
                CustomizationId = customization1.Id
            };

            var orderProductCustomization2 = new OrderProductCustomization
            {
                OrderId = order2.Id,
                ProductId = product2.Id,
                CustomizationId = customization2.Id
            };

            context.Set<OrderProductCustomization>().AddRange(orderProductCustomization1, orderProductCustomization2);
            context.SaveChanges();
        }
    }
}


//using Microsoft.EntityFrameworkCore;
//using MiniAKS_Database.Models;


//namespace MiniAKS_Database.Database;

//public class Seed
//{
//    public static void SeedData(MiniAKSDbContext context)
//    {
//        if (!context.Stations.Any())
//        {
//            var station1 = new Station
//            {
//                Id = Guid.NewGuid(),
//                Name = "Pressured Fried Chicken",
//                DisplayName = "PFC"
//            };

//            var station2 = new Station
//            {
//                Id = Guid.NewGuid(),
//                Name = "NuggetSeaFood",
//                DisplayName = "NSF"
//            };

//            var station3 = new Station
//            {
//                Id = Guid.NewGuid(),
//                Name = "Vegetables",
//                DisplayName = "Veg"
//            };

//            context.Stations.AddRange(station1, station2, station3);
//            context.SaveChanges();

//            var item1 = new Item
//            {
//                Id = Guid.NewGuid(),
//                Name = "Bone Chicken",
//                CreatedDate = DateTime.Now,
//                HoldingTimeAfterCooking = 4,
//                DrainageTime = 1,
//                PreparationTime = 1,
//                StationId = station1.Id 
//            };

//            var item2 = new Item
//            {
//                Id = Guid.NewGuid(),
//                Name = "Chicken Fillet Regular",
//                CreatedDate = DateTime.Now,
//                HoldingTimeAfterCooking = 3,
//                DrainageTime = 1,
//                PreparationTime = 1,
//                StationId = station2.Id 
//            };

//            var item3 = new Item
//            {
//                Id = Guid.NewGuid(),
//                Name = "French Fries",
//                CreatedDate = DateTime.Now,
//                HoldingTimeAfterCooking = 5,
//                DrainageTime = 0,
//                PreparationTime = 1,
//                StationId = station3.Id
//            };

//            context.Items.AddRange(item1, item2, item3);
//            context.SaveChanges();

//            var product1 = new Product
//            {
//                Id = Guid.NewGuid(),
//                Name = "Fried Chicken Regular 4pc Meal",
//                CreatedDate = DateTime.Now,
//            };

//            var product2 = new Product
//            {
//                Id = Guid.NewGuid(),
//                Name = "Chicken Fillet Regular 7pc Meal",
//                CreatedDate = DateTime.Now,
//            };

//            context.Products.AddRange(product1, product2);
//            context.SaveChanges();

//            var productItem1 = new ProductItem
//            {
//                ProductId = product1.Id,
//                ItemId = item1.Id 
//            };

//            var productItem2 = new ProductItem
//            {
//                ProductId = product2.Id,
//                ItemId = item2.Id 
//            };

//            var productItem3 = new ProductItem
//            {
//                ProductId = product1.Id,
//                ItemId = item3.Id
//            };

//            var productItem4 = new ProductItem
//            {
//                ProductId = product2.Id,
//                ItemId = item3.Id
//            };

//            context.Set<ProductItem>().AddRange(productItem1, productItem2, productItem3, productItem4);
//            context.SaveChanges();

//            var customization1 = new Customization
//            {
//                Id = Guid.NewGuid(),
//                Value = "No Salt fries",
//                Code = 101,
//                CreatedDate = DateTime.Now
//            };

//            var customization2 = new Customization
//            {
//                Id = Guid.NewGuid(),
//                Value = "Seasoned Fries",
//                Code = 102,
//                CreatedDate = DateTime.Now
//            };

//            context.Customizations.AddRange(customization1, customization2);

//            var salesChannel1 = new SalesChannel
//            {
//                Id = Guid.NewGuid(),
//                Name = "Dine In",
//                IsActive = true
//            };

//            var salesChannel2 = new SalesChannel
//            {
//                Id = Guid.NewGuid(),
//                Name = "Pickup",
//                IsActive = true
//            };

//            var salesChannel3 = new SalesChannel
//            {
//                Id = Guid.NewGuid(),
//                Name = "Online",
//                IsActive = false
//            };

//            context.SalesChannels.AddRange(salesChannel1, salesChannel2, salesChannel3);
//            context.SaveChanges();

//            var order1 = new Order
//            {
//                Id = Guid.NewGuid(),
//                OrderNumber = "01",
//                PlacedOn = DateTime.Now,
//                PrintedOn = DateTime.Now.AddMinutes(1),
//                CompletedOn = DateTime.Now.AddMinutes(3),
//            };

//            var order2 = new Order
//            {
//                Id = Guid.NewGuid(),
//                OrderNumber = "02",
//                PlacedOn = DateTime.Now,
//                PrintedOn = DateTime.Now.AddMinutes(1),
//                CompletedOn = DateTime.Now.AddMinutes(5),
//            };
//            context.Orders.AddRange(order1, order2);

//            var orderProduct1 = new OrderProduct
//            {
//                OrderId = order1.Id,
//                ProductId = product1.Id, 
//                Quantity = 2,
//            };

//            var orderProduct2 = new OrderProduct
//            {
//                OrderId = order2.Id,
//                ProductId = product1.Id, 
//                Quantity = 1,

//                //Customizations = new List<Customization> { customization1}
//            };

//            var orderProduct3 = new OrderProduct
//            {
//                OrderId = order2.Id,
//                ProductId = product2.Id,
//                Quantity = 1,
//                //Customizations = new List<Customization> { customization1, customization2 }
//            };

//            context.Set<OrderProduct>().AddRange(orderProduct1, orderProduct2, orderProduct3);
//            context.SaveChanges();


//        }
//    }
//}
