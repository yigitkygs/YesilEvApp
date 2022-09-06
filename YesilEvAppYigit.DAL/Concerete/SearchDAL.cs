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
    public class SearchDAL : RepoBase<YesilEvDbContext, Search>
    {
        public bool AddNewSearch(SearchDTO dto)
        {
            try
            {
                SearchDAL dal = new SearchDAL();
                dal.Add(MyMapper.SearchDTOToSearch(dto));
                dal.MySaveChanges();
                return true;
            }

            catch (Exception e)
            {
                Console.WriteLine("Hata: UrunEkle");
            }
            return false;
        }

        public List<SearchDTO> GetSearchesFromUserID(object ID)
        {
            List<SearchDTO> dto = new List<SearchDTO>();
            try
            {
                SearchDAL dal = new SearchDAL();
                dto = MyMapper.ListSearchToListSearchDTO(dal.GetBy(a=>a.UserID==(int)ID).Where(a=>a.IsDeleted==false).ToList());
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: GetSearchesFromUserID");
            }
            return dto;
        }
    }
}
