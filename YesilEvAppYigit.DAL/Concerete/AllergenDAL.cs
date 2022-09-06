using AutoMapper;
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
    public class AllergenDAL : RepoBase<YesilEvDbContext, Allergen>
    {
        public AllergenDAL()
        {

        }

        public AllergenDAL(YesilEvDbContext db) : base(db)
        {

        }

        public List<Allergen> AlerjenleriGetir()
        {
            List<Allergen> dto = new List<Allergen>();
            try
            {
                dto = new AllergenDAL().GetAll();
            }

            catch (Exception e)
            {
                Console.WriteLine("Hata: AlerjenleriGetir");
            }
            return dto;
        }
        public AllergenDTO AlerjenGetir(object ID)
        {
            AllergenDTO gonderilecek = new AllergenDTO();
            try
            {
                gonderilecek = MyMapper.AllergenToAllergenDTO(new AllergenDAL().GetByID(ID));
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: AlerjenGetir");
            }
            return gonderilecek;
        }
        public bool AlerjenEkle(AllergenDTO dto)
        {
            try
            {
                AllergenDAL dal = new AllergenDAL();
                var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<AllergenDTO, Allergen>()
                );
                var mapper = new Mapper(config);
                dal.Add(mapper.Map<Allergen>(dto));
                dal.MySaveChanges();
                return true;
            }

            catch (Exception e)
            {
                Console.WriteLine("Hata: AlerjenEkle");
            }
            return false;
        }
        public void AlerjenGuncelle(AllergenDTO dto)
        {
            try
            {
                AllergenDAL dal = new AllergenDAL();
                var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<AllergenDTO, Allergen>()
                );
                var mapper = new Mapper(config);
                dal.Update(mapper.Map<Allergen>(dto));
                dal.MySaveChanges();
            }

            catch (Exception e)
            {
                Console.WriteLine("Hata: AlerjenGuncelle");
            }
        }
        public bool AlerjenSil(AllergenDTO dto)
        {
            try
            {
                AllergenDAL dal = new AllergenDAL();
                var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<AllergenDTO, Allergen>()
                );
                var mapper = new Mapper(config);
                dal.Delete(mapper.Map<Allergen>(dto));
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: AlerjenSil");
            }
            return false;
        }
    }
}
