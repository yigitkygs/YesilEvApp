using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvAppYigit.Core.Repos;
using YesilEvAppYigit.Core;
using YesilEvAppYigit.DTO;
using YesilEvAppYigit.Mapping;

namespace YesilEvAppYigit.DAL.Concrete
{
    public class FavoriteProductDAL : RepoBase<YesilEvDbContext, FavoriteProduct>
    {
        public List<FavoriteProductDTO> GetAllFavoriteProducts()
        {
            List<FavoriteProductDTO> dto = new List<FavoriteProductDTO>();
            try
            {
                FavoriteProductDAL dal = new FavoriteProductDAL();
                dto = MyMapper.ListFavoriteProductToListFavoriteProductDTO(dal.GetAll().Where(a => a.IsActive == true).ToList());
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: GetAllFavoriteProducts");
            }
            return dto;
        }
        public List<FavoriteProductDTO> GetAllFavoriteProductsAdmin()
        {
            List<FavoriteProductDTO> dto = new List<FavoriteProductDTO>();
            try
            {
                FavoriteProductDAL dal = new FavoriteProductDAL();
                dto = MyMapper.ListFavoriteProductToListFavoriteProductDTO(dal.GetAll());
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: GetAllFavoriteProductsAdmin");
            }
            return dto;
        }
        public List<FavoriteProductDTO> GetAllFavoriteProductsBy(Func<FavoriteProduct, bool> cond)
        {
            List<FavoriteProductDTO> dto = new List<FavoriteProductDTO>();
            try
            {
                dto = MyMapper.ListFavoriteProductToListFavoriteProductDTO(new FavoriteProductDAL().GetBy(cond));
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: GetAllFavoriteProductsBy");
            }
            return dto;
        }
        public FavoriteProductDTO GetFavoriteProduct(int ID)
        {
            FavoriteProductDTO gonderilecek = null;
            try
            {
                gonderilecek = MyMapper.FavoriteProductToFavoriteProductDTO(new FavoriteProductDAL().GetByID(ID));
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: GetFavoriteProduct");
            }
            return gonderilecek;
        }
        public List<FavoriteProductDTO> GetFavoriteProductListsFromFavoriID(object ID)
        {
            List<FavoriteProductDTO> dto = new List<FavoriteProductDTO>();
            try
            {
                FavoriteProductDAL dal = new FavoriteProductDAL();
                dto = MyMapper.ListFavoriteProductToListFavoriteProductDTO(dal.GetBy(a => a.FavoriteID == (int)ID).Where(a => a.IsActive == true).ToList());
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: GetFavoriteProductListsFromFavoriID");
            }
            return dto;
        }
        public bool AddNewFavoriteProduct(FavoriteProductDTO dto)
        {
            try
            {
                FavoriteProductDAL dal = new FavoriteProductDAL();
                dal.Add(MyMapper.FavoriteProductDTOToFavoriteProduct(dto));
                dal.MySaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: AddNewFavoriteProduct");
            }
            return false;
        }
        public void UpdateFavoriteProduct(FavoriteProductDTO dto)
        {
            try
            {
                FavoriteProductDAL dal = new FavoriteProductDAL();
                dal.Update(MyMapper.FavoriteProductDTOToFavoriteProduct(dto), dto.FavoriteProductID);
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: UpdateFavoriteProduct");
            }
        }
        public bool DeleteFavoriteProduct(object ID)
        {
            try
            {
                FavoriteProductDAL dal = new FavoriteProductDAL();
                dal.Delete(new FavoriteProductDAL().GetByID(ID));
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: DeleteFavoriteProduct");
            }
            return false;
        }

        public void RevertSoftDeleteFavoriteProduct(FavoriteProductDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
