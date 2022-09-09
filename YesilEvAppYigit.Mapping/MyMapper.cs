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

        #region Allergen Mapper
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
                .ForMember(dest => dest.ProductAllergen, opt => opt.Ignore());
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
        #endregion        
        
        #region Blacklist Mapper
        public static Blacklist BlacklistDTOToBlacklist(BlacklistDTO dto)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BlacklistDTO, Blacklist>()
                .ForMember(dest => dest.BlacklistAllergens, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore());

                cfg.AllowNullCollections = true;
            });
            var mapper = new Mapper(mapperConfig);
            return mapper.Map<Blacklist>(dto);
        }

        public static BlacklistDTO BlacklistToBlacklistDTO(Blacklist obj)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Blacklist, BlacklistDTO>()
                .ForMember(dest => dest.BlacklistAllergens, opt => opt.Ignore());
                cfg.AllowNullCollections = true;
                cfg.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(mapperConfig);
            return mapper.Map<BlacklistDTO>(obj);
        }

        public static List<Blacklist> ListBlacklistDTOToListBlacklist(List<BlacklistDTO> obj)
        {
            List<Blacklist> dto = new List<Blacklist>();
            obj.ForEach(a => dto.Add(BlacklistDTOToBlacklist(a)));
            return dto;
        }

        public static List<BlacklistDTO> ListBlacklistToListBlacklistDTO(List<Blacklist> obj)
        {
            List<BlacklistDTO> dto = new List<BlacklistDTO>();
            obj.ForEach(a => dto.Add(BlacklistToBlacklistDTO(a)));
            return dto;
        }
        #endregion

        #region Blacklist Allergen Mapper
        public static BlacklistAllergen BlacklistAllergenDTOToBlacklistAllergen(BlacklistAllergenDTO dto)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BlacklistAllergenDTO, BlacklistAllergen>()
                .ForMember(dest => dest.Allergen, opt => opt.Ignore())
                .ForMember(dest => dest.Blacklist, opt => opt.Ignore());
                cfg.AllowNullCollections = true;
            });
            var mapper = new Mapper(mapperConfig);
            return mapper.Map<BlacklistAllergen>(dto);
        }

        public static BlacklistAllergenDTO BlacklistAllergenToBlacklistAllergenDTO(BlacklistAllergen obj)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BlacklistAllergen, BlacklistAllergenDTO>();
                cfg.AllowNullCollections = true;
            });
            var mapper = new Mapper(mapperConfig);
            return mapper.Map<BlacklistAllergenDTO>(obj);
        }

        public static List<BlacklistAllergen> ListBlacklistAllergenDTOToListBlacklistAllergen(List<BlacklistAllergenDTO> obj)
        {
            List<BlacklistAllergen> dto = new List<BlacklistAllergen>();
            obj.ForEach(a => dto.Add(BlacklistAllergenDTOToBlacklistAllergen(a)));
            return dto;
        }

        public static List<BlacklistAllergenDTO> ListBlacklistAllergenToListBlacklistAllergenDTO(List<BlacklistAllergen> obj)
        {
            List<BlacklistAllergenDTO> dto = new List<BlacklistAllergenDTO>();
            obj.ForEach(a => dto.Add(BlacklistAllergenToBlacklistAllergenDTO(a)));
            return dto;
        }
        #endregion

        #region Brand Mapper
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
        #endregion

        #region Category Mapper
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
        #endregion

        #region Favorite Mapper
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
                .ForMember(dest => dest.FavoriteProduct, opt => opt.Ignore())
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
        #endregion

        #region Favorite Product Mapper
        public static FavoriteProduct FavoriteProductDTOToFavoriteProduct(FavoriteProductDTO dto)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FavoriteProductDTO, FavoriteProduct>();
                cfg.AllowNullCollections = true;
            });
            var mapper = new Mapper(mapperConfig);
            return mapper.Map<FavoriteProduct>(dto);
        }

        public static FavoriteProductDTO FavoriteProductToFavoriteProductDTO(FavoriteProduct obj)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FavoriteProduct, FavoriteProductDTO>()
                .ForMember(dest => dest.Favorite, opt => opt.Ignore())
                .ForMember(dest => dest.Product, opt => opt.Ignore());
                cfg.AllowNullCollections = true;
            });
            var mapper = new Mapper(mapperConfig);
            return mapper.Map<FavoriteProductDTO>(obj);
        }

        public static List<FavoriteProduct> ListFavoriteProductDTOToListFavoriteProduct(List<FavoriteProductDTO> dto)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<List<FavoriteProductDTO>, List<FavoriteProduct>>();
                cfg.AllowNullCollections = true;
            });
            var mapper = new Mapper(mapperConfig);
            return mapper.Map<List<FavoriteProduct>>(dto);
        }

        public static List<FavoriteProductDTO> ListFavoriteProductToListFavoriteProductDTO(List<FavoriteProduct> obj)
        {
            List<FavoriteProductDTO> dto = new List<FavoriteProductDTO>();
            obj.ForEach(a => dto.Add(FavoriteProductToFavoriteProductDTO(a)));
            return dto;
        }
        #endregion

        #region Manufacturer Mapper
        public static Manufacturer ManufacturerDTOToManufacturer(ManufacturerDTO dto)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ManufacturerDTO, Manufacturer>()
                .ForMember(dest => dest.Brands, opt => opt.Ignore());
                cfg.AllowNullCollections = true;
            });
            var mapper = new Mapper(mapperConfig);
            return mapper.Map<Manufacturer>(dto);
        }

        public static ManufacturerDTO ManufacturerToManufacturerDTO(Manufacturer obj)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Manufacturer, ManufacturerDTO>();
                cfg.AllowNullCollections = true;
            });
            var mapper = new Mapper(mapperConfig);
            return mapper.Map<ManufacturerDTO>(obj);
        }

        public static List<Manufacturer> ListManufacturerDTOToListManufacturer(List<ManufacturerDTO> obj)
        {
            List<Manufacturer> dto = new List<Manufacturer>();
            obj.ForEach(a => dto.Add(ManufacturerDTOToManufacturer(a)));
            return dto;
        }

        public static List<ManufacturerDTO> ListManufacturerToListManufacturerDTO(List<Manufacturer> obj)
        {
            List<ManufacturerDTO> dto = new List<ManufacturerDTO>();
            obj.ForEach(a => dto.Add(ManufacturerToManufacturerDTO(a)));
            return dto;
        }
        #endregion

        #region Product Allergen Mapper
        public static ProductAllergen ProductAllergenDTOToProductAllergen(ProductAllergenDTO dto)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductAllergenDTO, ProductAllergen>()
                .ForMember(dest => dest.Allergen, opt => opt.Ignore())
                .ForMember(dest => dest.Product, opt => opt.Ignore());
                cfg.AllowNullCollections = true;
            });
            var mapper = new Mapper(mapperConfig);
            return mapper.Map<ProductAllergen>(dto);
        }

        public static ProductAllergenDTO ProductAllergenToProductAllergenDTO(ProductAllergen obj)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductAllergen, ProductAllergenDTO>()
                .ForMember(dest => dest.Allergen, opt => opt.Ignore())
                .ForMember(dest => dest.Product, opt => opt.Ignore());
                cfg.AllowNullCollections = true;
            });
            var mapper = new Mapper(mapperConfig);
            return mapper.Map<ProductAllergenDTO>(obj);
        }

        public static List<ProductAllergen> ListProductAllergenDTOToListProductAllergen(List<ProductAllergenDTO> obj)
        {
            List<ProductAllergen> dto = new List<ProductAllergen>();
            obj.ForEach(a => dto.Add(ProductAllergenDTOToProductAllergen(a)));
            return dto;
        }

        public static List<ProductAllergenDTO> ListProductAllergenToListProductAllergenDTO(List<ProductAllergen> obj)
        {
            List<ProductAllergenDTO> dto = new List<ProductAllergenDTO>();
            obj.ForEach(a => dto.Add(ProductAllergenToProductAllergenDTO(a)));
            return dto;
        }
        #endregion

        #region Product Mapper
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
                .ForMember(dest => dest.FavoriteProducts, opt => opt.Ignore())
                .ForMember(dest => dest.ProductAllergens, opt => opt.Ignore());
                cfg.AllowNullCollections = true;

            });
            var mapper = new Mapper(mapperConfig);
            return mapper.Map<ProductDTO>(obj);
        }

        public static List<Product> ListProductDTOToListProduct(List<ProductDTO> obj)
        {
            List<Product> dto = new List<Product>();
            obj.ForEach(a => dto.Add(ProductDTOToProduct(a)));
            return dto;
        }

        public static List<ProductDTO> ListProductToListProductDTO(List<Product> obj)
        {
            List<ProductDTO> dto = new List<ProductDTO>();
            obj.ForEach(a => dto.Add(ProductToProductDTO(a)));
            return dto;
        }

        public static ProductUserPageDTO ProductDTOToProductUserPageDTO(ProductDTO dto)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductDTO, ProductUserPageDTO>();
                cfg.AllowNullCollections = true;
            });
            var mapper = new Mapper(mapperConfig);
            return mapper.Map<ProductUserPageDTO>(dto);
        }

        public static ProductDTO ProductUserPageDTOToProductDTO(ProductUserPageDTO obj)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductUserPageDTO, ProductDTO>()
                .ForMember(dest => dest.FavoriteProducts, opt => opt.Ignore())
                .ForMember(dest => dest.ProductAllergens, opt => opt.Ignore());
                cfg.AllowNullCollections = true;

            });
            var mapper = new Mapper(mapperConfig);
            return mapper.Map<ProductDTO>(obj);
        }

        public static List<ProductUserPageDTO> ListProductDTOToListProductUserPageDTO(List<ProductDTO> obj)
        {
            List<ProductUserPageDTO> dto = new List<ProductUserPageDTO>();
            obj.ForEach(a => dto.Add(ProductDTOToProductUserPageDTO(a)));
            return dto;
        }

        public static List<ProductDTO> ListProductUserPageDTOToListProductDTO(List<ProductUserPageDTO> obj)
        {
            List<ProductDTO> dto = new List<ProductDTO>();
            obj.ForEach(a => dto.Add(ProductUserPageDTOToProductDTO(a)));
            return dto;
        }

        #endregion

        #region Search Mapper
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
        #endregion

        #region User Mapper
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

        #endregion
    }
}
