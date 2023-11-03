using API.ApplicationCore.DTOs;
using API.ApplicationCore.Entities;
using AutoMapper;

namespace API.ApplicationCore.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile() 
        {
            CreateMap<CreateUserRequest, User>()
                .ForMember(dest => dest.Uid, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
            CreateMap<User, UserResponse>();

            CreateMap<CreateProductRequest, Product>()
                .ForMember(dest => dest.Pid, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.Ignore())
                .ForMember(dest => dest.Price, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
            CreateMap<Product, ProductResponse>();

            CreateMap<CreateOrderRequest, Order>()
                .ForMember(dest => dest.Oid, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
            CreateMap<Order, OrderResponse>();
        }
    }
}
