using AutoMapper;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using YesilEvAppYigit.Core;
using YesilEvAppYigit.Core.Repos;
using YesilEvAppYigit.DAL.Concerete;
using YesilEvAppYigit.DTO;
using YesilEvAppYigit.Mapping;

namespace YesilEvAppYigit.DAL
{
    public class ProductDAL : RepoBase<YesilEvDbContext, Product>
    {
        public ProductDAL()
        {
        }

        public ProductDAL(YesilEvDbContext db) : base(db)
        {

        }

        public List<ProductDTO> UrunleriGetir()
        {
            List<ProductDTO> dto = new List<ProductDTO>();
            try
            {
                dto = MyMapper.ListProductToListProductDTO(new ProductDAL().GetAll());
            }

            catch (Exception e)
            {
                Console.WriteLine("Hata: UrunleriGetir");
            }
            return dto;
        }
        public List<ProductDTO> UrunleriGetir(Func<Product, bool> cond)
        {
            List<ProductDTO> dto = new List<ProductDTO>();
            try
            {
                dto = MyMapper.ListProductToListProductDTO(new ProductDAL().GetBy(cond));
            }

            catch (Exception e)
            {
                Console.WriteLine("Hata: UrunleriGetir");
            }
            return dto;
        }
        public ProductDTO UrunGetir(object ID)
        {
            ProductDTO gonderilecek = null;
            try
            {
                gonderilecek = MyMapper.ProductToProductDTO(new ProductDAL().GetByID(ID));
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: UrunGetir");
            }
            return gonderilecek;
        }
        public bool AddNewProduct(ProductDTO dto)
        {
            try
            {
                ProductDAL dal = new ProductDAL();
                dal.Add(MyMapper.ProductDTOToProduct(dto));
                dal.MySaveChanges();
                return true;
            }

            catch (Exception e)
            {
                Console.WriteLine("Hata: UrunEkle");
            }
            return false;
        }
        public void UrunGuncelle(ProductDTO dto)
        {
            try
            {
                ProductDAL dal = new ProductDAL();
                dal.Update(MyMapper.ProductDTOToProduct(dto));
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: UrunGuncelle");
            }
        }
        public bool UrunSil(ProductDTO dto)
        {
            try
            {
                ProductDAL dal = new ProductDAL();
                dal.Delete(MyMapper.ProductDTOToProduct(dto));
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: UrunSil");
            }
            return false;
        }

        
    }
}
