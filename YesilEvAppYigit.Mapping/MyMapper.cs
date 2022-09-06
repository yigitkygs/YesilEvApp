using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvAppYigit.Core;
using YesilEvAppYigit.DTO;

namespace YesilEvAppYigit.Mapping
{
    public static class MyMapper
    {


        //Product Mapper
        public static Product ProductDTOToProduct(ProductDTO dto)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductDTO, Product>();
                cfg.AllowNullCollections = true;
            });
            var mapper = new Mapper(mapperConfig);
            return mapper.Map<Product>(dto);
        }

        public static ProductDTO ProductToProductDTO(Product obj)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.FavoriUruns, opt => opt.Ignore())
                .ForMember(dest => dest.UrunAllergens, opt => opt.Ignore());
                cfg.AllowNullCollections = true;

            });
            var mapper = new Mapper(mapperConfig);
            return mapper.Map<ProductDTO>(obj);
        }

        public static List<Product> ListProductDTOToListProduct(List<ProductDTO> dto)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<List<ProductDTO>, List<Product>>();
                cfg.AllowNullCollections = true;
            });
            var mapper = new Mapper(mapperConfig);
            return mapper.Map<List<Product>>(dto);
        }

        public static List<ProductDTO> ListProductToListProductDTO(List<Product> obj)
        {
            List<ProductDTO> dto = new List<ProductDTO>();
            obj.ForEach(a => dto.Add(ProductToProductDTO(a)));
            return dto;
        }

        //User Mapper

        public static User UserDTOToUser(UserDTO dto)
        {
            var mapperConfig = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>());
            var mapper = new Mapper(mapperConfig);
            return mapper.Map<User>(dto);
        }

        public static UserDTO UserToUserDTO(User obj)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Searches, opt => opt.Ignore())
                .ForMember(dest => dest.Blacklists, opt => opt.Ignore())
                .ForMember(dest => dest.Favorites, opt => opt.Ignore());
                cfg.AllowNullCollections = true;
            });
            var mapper = new Mapper(mapperConfig);
            return mapper.Map<UserDTO>(obj);
        }

        public static List<User> ListUserDTOToListUser(List<UserDTO> dto)
        {
            var mapperConfig = new MapperConfiguration(cfg => cfg.CreateMap<List<UserDTO>, List<User>>());
            var mapper = new Mapper(mapperConfig);
            return mapper.Map<List<User>>(dto);
        }

        public static List<UserDTO> ListUserToListUserDTO(List<User> obj)
        {
            List<UserDTO> dto = new List<UserDTO>();
            obj.ForEach(a => dto.Add(UserToUserDTO(a)));
            return dto;
        }

        // Favorite Mapper
        public static Favorite FavoriteDTOToFavorite(FavoriteDTO dto)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FavoriteDTO, Favorite>();
                cfg.AllowNullCollections = true;
            });
            var mapper = new Mapper(mapperConfig);
            return mapper.Map<Favorite>(dto);
        }

        public static FavoriteDTO FavoriteToFavoriteDTO(Favorite obj)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Favorite, FavoriteDTO>()
                .ForMember(dest => dest.FavoriUruns, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore());

                cfg.AllowNullCollections = true;

            });
            var mapper = new Mapper(mapperConfig);
            return mapper.Map<FavoriteDTO>(obj);
        }

        public static List<Favorite> ListFavoriteDTOToListFavorite(List<FavoriteDTO> dto)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<List<FavoriteDTO>, List<Favorite>>();
                cfg.AllowNullCollections = true;
            });
            var mapper = new Mapper(mapperConfig);
            return mapper.Map<List<Favorite>>(dto);
        }

        public static List<FavoriteDTO> ListFavoriteToListFavoriteDTO(List<Favorite> obj)
        {
            List<FavoriteDTO> dto = new List<FavoriteDTO>();
            obj.ForEach(a => dto.Add(FavoriteToFavoriteDTO(a)));
            return dto;
        }

        // Allergen Mapper
        public static Allergen AllergenDTOToAllergen(AllergenDTO dto)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AllergenDTO, Allergen>();
                cfg.AllowNullCollections = true;
            });
            var mapper = new Mapper(mapperConfig);
            return mapper.Map<Allergen>(dto);
        }

        public static AllergenDTO AllergenToAllergenDTO(Allergen obj)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Allergen, AllergenDTO>()
                .ForMember(dest => dest.UrunAllergen, opt => opt.Ignore());
                cfg.AllowNullCollections = true;

            });
            var mapper = new Mapper(mapperConfig);
            return mapper.Map<AllergenDTO>(obj);
        }

        public static List<Allergen> ListAllergenDTOToListAllergen(List<AllergenDTO> dto)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<List<AllergenDTO>, List<Allergen>>();
                cfg.AllowNullCollections = true;
            });
            var mapper = new Mapper(mapperConfig);
            return mapper.Map<List<Allergen>>(dto);
        }

        public static List<AllergenDTO> ListAllergenToListAllergenDTO(List<Allergen> obj)
        {
            List<AllergenDTO> dto = new List<AllergenDTO>();
            obj.ForEach(a => dto.Add(AllergenToAllergenDTO(a)));
            return dto;
        }
        //Brand Mapper

        public static Brand BrandDTOToBrand(BrandDTO dto)
        {
            var mapperConfig = new MapperConfiguration(cfg => cfg.CreateMap<BrandDTO, Brand>());
            var mapper = new Mapper(mapperConfig);
            return mapper.Map<Brand>(dto);
        }

        public static BrandDTO BrandToBrandDTO(Brand obj)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Brand, BrandDTO>()
                .ForMember(dest => dest.Manufacturer, opt => opt.Ignore());
                cfg.AllowNullCollections = true;
            });
            var mapper = new Mapper(mapperConfig);
            return mapper.Map<BrandDTO>(obj);
        }

        public static List<Brand> ListBrandDTOToListBrand(List<BrandDTO> dto)
        {
            var mapperConfig = new MapperConfiguration(cfg => cfg.CreateMap<List<BrandDTO>, List<Brand>>());
            var mapper = new Mapper(mapperConfig);
            return mapper.Map<List<Brand>>(dto);
        }

        public static List<BrandDTO> ListBrandToListBrandDTO(List<Brand> obj)
        {
            List<BrandDTO> dto = new List<BrandDTO>();
            obj.ForEach(a => dto.Add(BrandToBrandDTO(a)));
            return dto;
        }

        //Category Mapper

        public static Category CategoryDTOToCategory(CategoryDTO dto)
        {
            var mapperConfig = new MapperConfiguration(cfg => cfg.CreateMap<CategoryDTO, Category>());
            var mapper = new Mapper(mapperConfig);
            return mapper.Map<Category>(dto);
        }

        public static CategoryDTO CategoryToCategoryDTO(Category obj)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, CategoryDTO>();
                cfg.AllowNullCollections = true;
            });
            var mapper = new Mapper(mapperConfig);
            return mapper.Map<CategoryDTO>(obj);
        }

        public static List<Category> ListCategoryDTOToListCategory(List<CategoryDTO> dto)
        {
            var mapperConfig = new MapperConfiguration(cfg => cfg.CreateMap<List<CategoryDTO>, List<Category>>());
            var mapper = new Mapper(mapperConfig);
            return mapper.Map<List<Category>>(dto);
        }

        public static List<CategoryDTO> ListCategoryToListCategoryDTO(List<Category> obj)
        {
            List<CategoryDTO> dto = new List<CategoryDTO>();
            obj.ForEach(a => dto.Add(CategoryToCategoryDTO(a)));
            return dto;
        }

        //Search Mapper
        public static Search SearchDTOToSearch(SearchDTO dto)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            cfg.CreateMap<SearchDTO, Search>()
                .ForMember(dest => dest.User, opt => opt.Ignore()));
            var mapper = new Mapper(mapperConfig);
            return mapper.Map<Search>(dto);
        }

        public static SearchDTO SearchToSearchDTO(Search obj)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Search, SearchDTO>();
                cfg.AllowNullCollections = true;
            });
            var mapper = new Mapper(mapperConfig);
            return mapper.Map<SearchDTO>(obj);
        }

        public static List<Search> ListSearchDTOToListSearch(List<SearchDTO> obj)
        {
            List<Search> dto = new List<Search>();
            obj.ForEach(a => dto.Add(SearchDTOToSearch(a)));
            return dto;
        }

        public static List<SearchDTO> ListSearchToListSearchDTO(List<Search> obj)
        {
            List<SearchDTO> dto = new List<SearchDTO>();
            obj.ForEach(a => dto.Add(SearchToSearchDTO(a)));
            return dto;
        }

    }
}
