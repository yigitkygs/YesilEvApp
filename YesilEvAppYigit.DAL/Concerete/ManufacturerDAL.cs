using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvAppYigit.Core.Repos;
using YesilEvAppYigit.Core;
using YesilEvAppYigit.DTO;

namespace YesilEvAppYigit.DAL.Concerete
{
    public class ManufacturerDAL : RepoBase<YesilEvDbContext, Manufacturer>
    {
        public ManufacturerDAL()
        {

        }

        public ManufacturerDAL(YesilEvDbContext db) : base(db)
        {

        }

        public List<Manufacturer> UreticileriGetir()
        {
            List<Manufacturer> dto = new List<Manufacturer>();
            try
            {
                dto = new ManufacturerDAL().GetAll();
            }

            catch (Exception e)
            {
                Console.WriteLine("Hata: UreticileriGetir");
            }
            return dto;
        }
        public Manufacturer UreticiGetir(object ID)
        {
            Manufacturer gonderilecek = new Manufacturer();
            try
            {
                gonderilecek = new ManufacturerDAL().GetByID(ID);
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: UreticiGetir");
            }
            return gonderilecek;
        }
        public bool UreticiEkle(ManufacturerDTO dto)
        {
            try
            {
                ManufacturerDAL dal = new ManufacturerDAL();
                var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<ManufacturerDTO, Manufacturer>()
                );
                var mapper = new Mapper(config);
                dal.Add(mapper.Map<Manufacturer>(dto));
                dal.MySaveChanges();
                return true;
            }

            catch (Exception e)
            {
                Console.WriteLine("Hata: UreticiEkle");
            }
            return false;
        }
        public void UreticiGuncelle(ManufacturerDTO dto)
        {
            try
            {
                ManufacturerDAL dal = new ManufacturerDAL();
                var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<ManufacturerDTO, Manufacturer>()
                );
                var mapper = new Mapper(config);
                dal.Update(mapper.Map<Manufacturer>(dto));
                dal.MySaveChanges();
            }

            catch (Exception e)
            {
                Console.WriteLine("Hata: UreticiGuncelle");
            }
        }
        public bool UreticiSil(ManufacturerDTO dto)
        {
            try
            {
                ManufacturerDAL dal = new ManufacturerDAL();
                var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<ManufacturerDTO, Manufacturer>()
                );
                var mapper = new Mapper(config);
                dal.Delete(mapper.Map<Manufacturer>(dto));
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: UreticiSil");
            }
            return false;
        }
    }
}
