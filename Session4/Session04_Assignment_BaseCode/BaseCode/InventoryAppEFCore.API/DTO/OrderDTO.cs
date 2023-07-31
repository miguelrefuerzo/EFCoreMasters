using InventoryAppEFCore.DataLayer.EfClasses;

namespace InventoryAppEFCore.API.DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public DateTime DateOrderedUTC { get; set; }
        public ICollection<LineItemDTO> LineItems { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int ClientId { get; set; }
    }
}
