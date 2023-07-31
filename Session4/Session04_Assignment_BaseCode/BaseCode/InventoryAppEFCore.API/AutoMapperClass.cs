using AutoMapper;
using InventoryAppEFCore.API.DTO;
using InventoryAppEFCore.DataLayer.EfClasses;

namespace InventoryAppEFCore.API
{
    public class AutoMapperClass : Profile
    {
        public AutoMapperClass() { 
            CreateMap<Product, ProductDTO>();
            CreateMap<LineItem, LineItemDTO>();
            CreateMap<Order, OrderDTO>();
            CreateMap<PriceOffer, PriceOfferDTO>();
            CreateMap<Review, ReviewDTO>();
            CreateMap<Supplier, SupplierDTO>();
            CreateMap<Tag, TagDTO>();
        }
    }
}
