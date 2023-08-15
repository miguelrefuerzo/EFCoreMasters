namespace InventoryAppEFCore.API.DTO
{
    public class LineItemDTO
    {
        public int LineItemId { get; set; }
        public short NumOfProducts { get; set; }
        public decimal ProductPrice { get; set; }

        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public ProductDTO Product { get; set; }
    }
}
