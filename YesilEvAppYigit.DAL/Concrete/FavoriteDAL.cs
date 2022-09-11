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
    public class FavoriteDAL : RepoBase<YesilEvDbContext, Favorite>
    {
        public List<FavoriteDTO> GetAllFavorites()
        {
            List<FavoriteDTO> dto = new List<FavoriteDTO>();
            try
            {
                FavoriteDAL dal = new FavoriteDAL();
                dto = MyMapper.ListFavoriteToListFavoriteDTO(dal.GetAll().Where(a => a.IsActive == true).ToList());
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: GetAllFavorites");
            }
            return dto;
        }
        public List<FavoriteDTO> GetAllFavoritesAdmin()
        {
            List<FavoriteDTO> dto = new List<FavoriteDTO>();
            try
            {
                FavoriteDAL dal = new FavoriteDAL();
                dto = MyMapper.ListFavoriteToListFavoriteDTO(dal.GetAll());
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: GetAllFavoritesAdmin");
            }
            return dto;
        }
        public FavoriteDTO GetFavoriteByID(int ID)
        {
            FavoriteDTO gonderilecek = null;
            try
            {
                gonderilecek = MyMapper.FavoriteToFavoriteDTO(new FavoriteDAL().GetByID(ID));
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: UrunGetir");
            }
            return gonderilecek;
        }
        public List<FavoriteDTO> GetFavoriteFromUserID(object ID)
        {
            List<FavoriteDTO> dto = new List<FavoriteDTO>();
            try
            {
                FavoriteDAL dal = new FavoriteDAL();
                dto = MyMapper.ListFavoriteToListFavoriteDTO(dal.GetBy(a => a.UserID == (int)ID).Where(a => a.IsActive == true).ToList());
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: GetSearchesFromUserID");
            }
            return dto;
        }
        public bool AddNewFavorite(FavoriteDTO dto)
        {
            try
            {
                FavoriteDAL dal = new FavoriteDAL();
                dal.Add(MyMapper.FavoriteDTOToFavorite(dto));
                dal.MySaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: AddNewFavoriteList");
            }
            return false;
        }
        public void UpdateFavorite(FavoriteDTO dto)
        {
            try
            {
                FavoriteDAL dal = new FavoriteDAL();
                dal.Update(MyMapper.FavoriteDTOToFavorite(dto), dto.UserID);
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: UpdateFavoriteList");
            }
        }
        public bool DeleteFavorite(object ID)
        {
            try
            {
                FavoriteDAL dal = new FavoriteDAL();
                dal.Delete(new FavoriteDAL().GetByID(ID));
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: DeleteFavoriteList");
            }
            return false;
        }

        public void SoftDeleteFavorite(FavoriteDTO dto)
        {
            try
            {
                FavoriteDAL dal = new FavoriteDAL();
                dto.IsActive = false;
                dal.Update(MyMapper.FavoriteDTOToFavorite(dto), dto.UserID);
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: SoftDeleteFavorite");
            }
        }
        public void RevertSoftDeleteFavorite(FavoriteDTO dto)
        {
            try
            {
                FavoriteDAL dal = new FavoriteDAL();
                dto.IsActive = true;
                dal.Update(MyMapper.FavoriteDTOToFavorite(dto), dto.UserID);
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: RevertSoftDeleteFavorite");
            }
        }
    }
}
