using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventortAppEFCore.Services
{
    public class ProductService : IProductService
    {
        private readonly InventoryAppEfCoreContext inventoryAppEfCoreContext;

        public ProductService(InventoryAppEfCoreContext inventoryAppEfCoreContext)
        {
            this.inventoryAppEfCoreContext = inventoryAppEfCoreContext;
        }

        public async Task<List<Product>> GetProducts()
        {
            var product = await inventoryAppEfCoreContext.Product.ToListAsync();

            return product;
        }
    }

    public interface IProductService
    {
        Task<List<Product>> GetProducts();
    }
}
