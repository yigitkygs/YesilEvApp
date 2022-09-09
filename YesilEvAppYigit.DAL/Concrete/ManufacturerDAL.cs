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

namespace YesilEvAppYigit.DAL.Concrete
{
    public class ManufacturerDAL : RepoBase<YesilEvDbContext, Manufacturer>
    {
        public List<ManufacturerDTO> GetAllManufacturers()
        {
            List<ManufacturerDTO> dto = new List<ManufacturerDTO>();
            try
            {
                dto = MyMapper.ListManufacturerToListManufacturerDTO(new ManufacturerDAL().GetAll().Where(a => a.IsActive == true).ToList());
            }

            catch (Exception e)
            {
                Console.WriteLine("Hata: GetAllManufacturers");
            }
            return dto;
        }
        public List<ManufacturerDTO> GetAllManufacturersAdmin()
        {
            List<ManufacturerDTO> dto = new List<ManufacturerDTO>();
            try
            {
                dto = MyMapper.ListManufacturerToListManufacturerDTO(new ManufacturerDAL().GetAll());
            }

            catch (Exception e)
            {
                Console.WriteLine("Hata: GetAllManufacturersAdmin");
            }
            return dto;
        }
        public ManufacturerDTO GetManufacturerFromID(object ID)
        {
            ManufacturerDTO gonderilecek = new ManufacturerDTO();
            try
            {
                gonderilecek = MyMapper.ManufacturerToManufacturerDTO(new ManufacturerDAL().GetByID(ID));
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: GetManufacturerFromID");
            }
            return gonderilecek;
        }
        public bool AddNewManufacturer(ManufacturerDTO dto)
        {
            try
            {
                ManufacturerDAL dal = new ManufacturerDAL();
                dal.Add(MyMapper.ManufacturerDTOToManufacturer(dto));
                dal.MySaveChanges();
                return true;
            }

            catch (Exception e)
            {
                Console.WriteLine("Hata: AddNewManufacturer");
            }
            return false;
        }
        public void UpdateManufacturer(ManufacturerDTO dto)
        {
            try
            {
                ManufacturerDAL dal = new ManufacturerDAL();
                dal.Update(MyMapper.ManufacturerDTOToManufacturer(dto),dto.ManufacturerID);
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: UpdateManufacturer");
            }
        }
        public void SoftDeleteManufacturer(ManufacturerDTO dto)
        {
            try
            {
                ManufacturerDAL dal = new ManufacturerDAL();
                dto.IsActive = false;
                dal.Update(MyMapper.ManufacturerDTOToManufacturer(dto), dto.ManufacturerID);
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: SoftDeleteManufacturer");
            }
        }
        public void RevertSoftDeleteManufacturer(ManufacturerDTO dto)
        {
            try
            {
                ManufacturerDAL dal = new ManufacturerDAL();
                dto.IsActive = true;
                dal.Update(MyMapper.ManufacturerDTOToManufacturer(dto), dto.ManufacturerID);
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: RevertSoftDeleteManufacturer");
            }
        }
        public bool DeleteManufacturer(ManufacturerDTO dto)
        {
            try
            {
                ManufacturerDAL dal = new ManufacturerDAL();
                dal.Delete(MyMapper.ManufacturerDTOToManufacturer(dto));
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: DeleteManufacturer");
            }
            return false;
        }
    }
}
