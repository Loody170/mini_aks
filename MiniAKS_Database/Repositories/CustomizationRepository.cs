using Microsoft.EntityFrameworkCore;
using MiniAKS_Database.Database;
using MiniAKS_Database.Models;
using MiniAKS_Database.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAKS_Database.Repositories
{
    public class CustomizationRepository : ICustomizationRepository
    {
        private readonly MiniAKSDbContext _context;
        public CustomizationRepository(MiniAKSDbContext context)
        {
            _context = context;
        }
        public ICollection<Customization> GetCustomizations()
        {
            return _context.Customizations.ToList();
        }
        public Customization GetCustomization(Guid id)
        {
            return _context.Customizations.Find(id);
        }

        public ICollection<Customization> GetCustomizationForAProductInAnOrder(Guid orderId, Guid productId)
        {
            return _context.OrderProductCustomizations.Where(opc => opc.OrderId == orderId && opc.ProductId == productId)
                .Include(opc => opc.Customization)
                .Select(opc => opc.Customization)
                .ToList();
        }

        public Customization GetCustomazationByCode(int code)
        {
            return _context.Customizations.Where(c => c.Code == code).FirstOrDefault();
        }
    }
}
