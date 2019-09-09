using AutoMapper;
using UcuzSepet.Application.API.Models;
using UcuzSepet.Data.Domain.Entities;

namespace UcuzSepet.Application.API.Mapping {
    public class ApiMappingProfile : Profile {
        public ApiMappingProfile() {

            CreateMap<Category, CategoryViewModel>()
                .ForMember(cv => cv.CategoryName, c => c.MapFrom(x => x.Name))
                .ReverseMap();

            CreateMap<SubCategory, SubCategoryViewModel>()
                .ForMember(scv => scv.SubCategoryName, sc => sc.MapFrom(x => x.Name))
                .ReverseMap();

            CreateMap<Brand, BrandViewModel>()
                .ForMember(bv => bv.BrandName, b => b.MapFrom(x => x.Name))
                .ReverseMap();

            CreateMap<Product, ProductViewModel>()
                .ForMember(pv => pv.ProductName, p => p.MapFrom(x => x.Name))
                .ForMember(pv => pv.ProductCategory, p => p.MapFrom(x => x.SubCategory))
                .ForMember(pv => pv.ProductBrand, p => p.MapFrom(x => x.Brand))
                .ForMember(pv => pv.ProductPrice, p => p.MapFrom(x => x.Price))
                .ForMember(pv => pv.ProductProperties, p => p.MapFrom(x => x.Properties))
                .ReverseMap();
        }
    }
}
