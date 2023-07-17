using EFCoreAssignment.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace EFCoreAssignment.Data.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            // TODO get products
            var product = await _context.Products
                .Select(p => new ProductDto(p.Id, p.Name, p.ShopId))
                .ToListAsync();
            return product;
        }

        public async Task<ProductDto> GetProduct(int id)
        {
            // TODO get product
            var product = await _context.Products
                .Where(p => p.Id == id)
                .Select(p => new ProductDto(p.Id, p.Name, p.ShopId))
                .FirstOrDefaultAsync();
            return product;
        }

        public async Task<int> CreateProduct(CreateProductDto productForCreation)
        {
            // TODO create a product
            var product = new Product
            {
                Name = productForCreation.Name,
                ShopId = productForCreation.ShopId
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }

        public async Task UpdateProduct(UpdateProductDto productForUpdate)
        {
            //TODO update a product
            var product = await _context.Products.FindAsync(productForUpdate.Id);
            product.Name = productForUpdate.Name;
            product.ShopId = productForUpdate.ShopId;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            //TODO delete a product
            var product = await _context.Products.FindAsync(id);

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

    }

    public interface IProductService
    {
        Task<List<ProductDto>> GetProducts();
        Task<ProductDto> GetProduct(int id);
        Task<int> CreateProduct(CreateProductDto productForCreation);
        Task UpdateProduct(UpdateProductDto productForUpdate);
        Task DeleteProduct(int id);
    }

    public record ProductDto(int Id, string Name, int ShopId);
    public record CreateProductDto(string Name, int ShopId);
    public record UpdateProductDto(int Id, string Name, int ShopId);
}