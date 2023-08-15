namespace InventoryAppEFCore.API.DTO
{
    public class PriceOfferDTO
    {
        public int PriceOfferID { get; set; }
        public decimal NewPrice { get; set; }
        public string PromotionalText { get; set; }
        public int ProductId { get; set; }
    }
}