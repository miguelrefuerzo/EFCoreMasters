using InventoryAppEFCore.DataLayer.EfClasses;

namespace InventoryAppEFCore.API.DTO
{
    public class SupplierDTO
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set;}
        public string SupplierDescription { get; set;}
        public ExcludeClass ExcludeClass { get; set;}
        public ICollection<ProductDTO> ProductsLink { get; set; }
    }
}
