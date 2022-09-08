using AutoMapper;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using YesilEvAppYigit.Core;
using YesilEvAppYigit.Core.Repos;
using YesilEvAppYigit.DAL.Concrete;
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

        public List<ProductDTO> GetAllProducts()
        {
            List<ProductDTO> dto = new List<ProductDTO>();
            try
            {
                dto = MyMapper.ListProductToListProductDTO(new ProductDAL().GetAll());
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: GetAllProducts");
            }
            return dto;
        }
        public List<ProductDTO> GetProductsBy(Func<Product, bool> cond)
        {
            List<ProductDTO> dto = new List<ProductDTO>();
            try
            {
                dto = MyMapper.ListProductToListProductDTO(new ProductDAL().GetBy(cond));
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: GetProductsBy");
            }
            return dto;
        }
        public ProductDTO GetProductByID(object ID)
        {
            ProductDTO gonderilecek = null;
            try
            {
                gonderilecek = MyMapper.ProductToProductDTO(new ProductDAL().GetByID(ID));
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: GetProductByID");
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
                Console.WriteLine("Hata: AddNewProduct");
            }
            return false;
        }
        public void UpdateProduct(ProductDTO dto)
        {
            try
            {
                ProductDAL dal = new ProductDAL();
                dal.Update(MyMapper.ProductDTOToProduct(dto),dto.ProductID);
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: UpdateProduct");
            }
        }
        public void SoftDeleteProduct(ProductDTO dto)
        {
            try
            {
                ProductDAL dal = new ProductDAL();
                dto.IsActive = false;
                dal.Update(MyMapper.ProductDTOToProduct(dto), dto.ProductID);
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: SoftDeleteProduct");
            }
        }
        public void RevertSoftDeleteProduct(ProductDTO dto)
        {
            try
            {
                ProductDAL dal = new ProductDAL();
                dto.IsActive = true;
                dal.Update(MyMapper.ProductDTOToProduct(dto), dto.ProductID);
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: RevertSoftDeleteProduct");
            }
        }
        public bool HardDeleteProduct(ProductDTO dto)
        {
            try
            {
                ProductDAL dal = new ProductDAL();
                dal.Delete(MyMapper.ProductDTOToProduct(dto));
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: HardDeleteProduct");
            }
            return false;
        }
    }
}
