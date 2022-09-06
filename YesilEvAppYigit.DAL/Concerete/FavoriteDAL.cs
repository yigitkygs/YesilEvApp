using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvAppYigit.Core.Repos;
using YesilEvAppYigit.Core;
using YesilEvAppYigit.DTO;
using YesilEvAppYigit.Mapping;

namespace YesilEvAppYigit.DAL.Concerete
{
    public class FavoriteDAL : RepoBase<YesilEvDbContext, Favorite>
    {
        public FavoriteDTO FavoriGetir(int ID)
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
    }
}
