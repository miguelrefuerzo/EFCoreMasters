using AutoMapper;
using InventoryAppEFCore.API.DTO;
using InventoryAppEFCore.DataLayer.EfClasses;

namespace InventoryAppEFCore.API
{
    public class AutoMapperClass : Profile
    {
        public AutoMapperClass() { 
            CreateMap<Product, ProductDTO>()
                .ForMember(p => p.ProductId, s => s.MapFrom(x => x.ProductId));
            CreateMap<LineItem, LineItemDTO>()
                .ForMember(p => p.LineItemId, s => s.MapFrom(x => x.LineItemId));
            CreateMap<Order, OrderDTO>()
                .ForMember(p => p.OrderId, s => s.MapFrom(x => x.OrderId));
            CreateMap<PriceOffer, PriceOfferDTO>()
                .ForMember(p => p.PriceOfferID, s => s.MapFrom(x => x.PriceOfferId));
            CreateMap<Review, ReviewDTO>()
                .ForMember(p => p.ReviewId, s => s.MapFrom(x => x.ReviewId));
            CreateMap<Supplier, SupplierDTO>()
                .ForMember(p => p.SupplierId, s => s.MapFrom(x => x.SupplierId));
            CreateMap<Tag, TagDTO>()
                .ForMember(p => p.TagId, s => s.MapFrom(x => x.TagId));
        }
    }
}
