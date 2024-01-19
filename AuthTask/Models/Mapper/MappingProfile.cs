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
    }
}
