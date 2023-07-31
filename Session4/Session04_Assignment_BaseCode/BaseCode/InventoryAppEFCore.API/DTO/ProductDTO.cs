using System.ComponentModel.DataAnnotations;

namespace InventoryAppEFCore.API.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public PriceOfferDTO Promotion { get; set; }
        public ICollection<ReviewDTO> Reviews { get; set; }
        public ICollection<TagDTO> Tags { get; set; }
        public bool IsDeleted { get; set; }

    }
}
