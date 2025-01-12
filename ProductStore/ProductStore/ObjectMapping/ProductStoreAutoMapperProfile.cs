using AutoMapper;
using ProductStore.Entities;
using ProductStore.Services.Dtos.CategoriesDtos;
using ProductStore.Services.Dtos.OrderDtos;
using ProductStore.Services.Dtos.ProductDtos;
using ProductStore.Services.Dtos.ReadProductDtos;

namespace ProductStore.ObjectMapping;

public class ProductStoreAutoMapperProfile : Profile
{
    public ProductStoreAutoMapperProfile()
    {
        /* Create your AutoMapper object mappings here */
        
        //product
        CreateMap<CreateProductDto, Product>();
        CreateMap<UpdateProductDto, Product>();
        CreateMap<Product, ReadProductDto>();

        //category
        CreateMap<CreateCategoryDto, Category>();
        CreateMap<UpdateCategoryDto, Category>();
        CreateMap<Category, ReadCategoryDto>();

        //order
        CreateMap<CreateOrderDto, Order>();
        CreateMap<UpdateOrderDto, Order>();
        CreateMap<Order, ReadOrderDto>();



    }
}
