using AutoMapper;
using Entitiy;
using DTO;


namespace WebApplication_first
    
{
    public class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.Company,
                src => src.MapFrom(p => p.Category.Company)).ReverseMap();
            CreateMap<UserTable, UserDTO>();
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderItem, OrderItemDTO>();
            CreateMap<Category, CategoryDTO>();
        }

    }
}
