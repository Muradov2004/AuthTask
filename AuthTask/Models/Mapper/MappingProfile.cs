using AuthTask.Models.ViewModel;
using AutoMapper;

namespace AuthTask.Models.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AddProductViewModel, Product>();
        CreateMap<Product, AddProductViewModel>();
        CreateMap<UpdateProductViewModel, Product>();
        CreateMap<Product, UpdateProductViewModel>();
        CreateMap<Product, OrderedProductViewModel>();
        CreateMap<Cart, OrderedCartViewModel>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));
    }
}
