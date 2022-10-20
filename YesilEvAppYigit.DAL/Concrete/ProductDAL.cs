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
using YesilEvAppYigit.Validation;

namespace YesilEvAppYigit.DAL
{
    public class ProductDAL : RepoBase<YesilEvDbContext, Product>
    {
        public List<ProductDTO> GetAllProducts()
        {
            List<ProductDTO> dto = new List<ProductDTO>();
            try
            {
                dto = MyMapper.ListProductToListProductDTO(new ProductDAL().GetAll().Where(a => a.IsActive == true).ToList());
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: GetAllProducts");
            }
            return dto;
        }
        public List<ProductDTO> GetAllProductsAdmin()
        {
            List<ProductDTO> dto = new List<ProductDTO>();
            try
            {
                dto = MyMapper.ListProductToListProductDTO(new ProductDAL().GetAll());
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: GetAllProductsAdmin");
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
                NewProductValidation validation = new NewProductValidation(dto);

                if (!validation.IsValid)
                {
                    throw new Exception(validation.ValidationMessages[0]);
                }
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
        public bool UpdateProduct(ProductDTO dto)
        {
            try
            {
                ProductDAL dal = new ProductDAL();
                dal.Update(MyMapper.ProductDTOToProduct(dto),dto.ProductID);
                dal.MySaveChanges();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: UpdateProduct");
            }
            return false;
        }
        public void ApproveProduct(object ID)
        {
            try
            {
                ProductDAL dal = new ProductDAL();
                ProductDTO productDTO= GetProductByID(ID);
                productDTO.IsApproved = true;
                dal.Update(MyMapper.ProductDTOToProduct(productDTO), (int)ID);
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: ApproveProduct");
            }
        }
        public void UnapproveProduct(object ID)
        {
            try
            {
                ProductDAL dal = new ProductDAL();
                ProductDTO productDTO = GetProductByID(ID);
                productDTO.IsApproved = false;
                dal.Update(MyMapper.ProductDTOToProduct(productDTO), (int)ID);
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: UnapproveProduct");
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
