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
    public class SearchDAL : RepoBase<YesilEvDbContext, Search>
    {
        public List<SearchDTO> GetAllSearches()
        {
            List<SearchDTO> dto = new List<SearchDTO>();
            try
            {
                dto = MyMapper.ListSearchToListSearchDTO(new SearchDAL().GetAll());
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: GetAllSearches");
            }
            return dto;
        }
        public SearchDTO GetSearchFromID(object ID)
        {
            SearchDTO gonderilecek = new SearchDTO();
            try
            {
                gonderilecek = MyMapper.SearchToSearchDTO(new SearchDAL().GetByID(ID));
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: GetSearchFromID");
            }
            return gonderilecek;
        }
        public List<SearchDTO> GetSearchesFromUserID(object ID)
        {
            List<SearchDTO> dto = new List<SearchDTO>();
            try
            {
                SearchDAL dal = new SearchDAL();
                dto = MyMapper.ListSearchToListSearchDTO(dal.GetBy(a => a.UserID == (int)ID).Where(a => a.IsDeleted == false).ToList());
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: GetSearchesFromUserID");
            }
            return dto;
        }  
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
                Console.WriteLine("Hata: AddNewSearch");
            }
            return false;
        }
        public void UpdateSearch(SearchDTO dto)
        {
            try
            {
                SearchDAL dal = new SearchDAL();
                dal.Update(MyMapper.SearchDTOToSearch(dto));
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: UpdateSearch");
            }
        }
        public void SoftDeleteSearch(SearchDTO dto)
        {
            try
            {
                SearchDAL dal = new SearchDAL();
                dto.IsDeleted = true;
                dal.Update(MyMapper.SearchDTOToSearch(dto));
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: SoftDeleteSearch");
            }
        }
        public void RevertSoftDeleteBrand(SearchDTO dto)
        {
            try
            {
                SearchDAL dal = new SearchDAL();
                dto.IsDeleted = false;
                dal.Update(MyMapper.SearchDTOToSearch(dto));
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: RevertSoftDeleteBrand");
            }
        }
        public bool HardDeleteSearch(SearchDTO dto)
        {
            try
            {
                SearchDAL dal = new SearchDAL();
                dal.Delete(MyMapper.SearchDTOToSearch(dto));
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: HardDeleteSearch");
            }
            return false;
        }
    }
}
