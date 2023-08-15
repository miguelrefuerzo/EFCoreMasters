namespace InventoryAppEFCore.API.DTO
{
    public class TagDTO
    {
        public string TagId { get; set; }
        public ICollection<ProductDTO> Products { get; set; }
    }
}