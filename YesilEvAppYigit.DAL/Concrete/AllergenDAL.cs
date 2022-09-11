﻿using AutoMapper;
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
    public class AllergenDAL : RepoBase<YesilEvDbContext, Allergen>
    {
        public List<AllergenDTO> GetAllAllergens()
        {
            List<AllergenDTO> dto = new List<AllergenDTO>();
            try
            {
                dto = MyMapper.ListAllergenToListAllergenDTO(new AllergenDAL().GetAll().Where(a => a.IsActive == true).ToList());
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: GetAllAllergens");
            }
            return dto;
        }
        public List<AllergenDTO> GetAllAllergensAdmin()
        {
            List<AllergenDTO> dto = new List<AllergenDTO>();
            try
            {
                dto = MyMapper.ListAllergenToListAllergenDTO(new AllergenDAL().GetAll());
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: GetAllAllergensAdmin");
            }
            return dto;
        }
        public AllergenDTO GetAllergen(object ID)
        {
            AllergenDTO gonderilecek = new AllergenDTO();
            try
            {
                gonderilecek = MyMapper.AllergenToAllergenDTO(new AllergenDAL().GetByID(ID));
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: GetAllergen");
            }
            return gonderilecek;
        }
        public bool AddNewAllergen(AllergenDTO dto)
        {
            try
            {
                AllergenDAL dal = new AllergenDAL();
                dal.Add(MyMapper.AllergenDTOToAllergen(dto));
                dal.MySaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: AddNewAllergen");
            }
            return false;
        }
        public void UpdateAllergen(AllergenDTO dto)
        {
            try
            {
                AllergenDAL dal = new AllergenDAL();
                dal.Update(MyMapper.AllergenDTOToAllergen(dto),dto.AllergenID);
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: UpdateAllergen");
            }
        } 
        public void SoftDeleteAllergen(AllergenDTO dto)
        {
            try
            {
                AllergenDAL dal = new AllergenDAL();
                dto.IsActive = false;
                dal.Update(MyMapper.AllergenDTOToAllergen(dto), dto.AllergenID);
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: SoftDeleteAllergen");
            }
        }
        public void RevertSoftDeleteAllergen(AllergenDTO dto)
        {
            try
            {
                AllergenDAL dal = new AllergenDAL();
                dto.IsActive = true;
                dal.Update(MyMapper.AllergenDTOToAllergen(dto), dto.AllergenID);
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: RevertSoftDeleteAllergen");
            }
        }
        public bool HardDeleteAllergen(AllergenDTO dto)
        {
            try
            {
                AllergenDAL dal = new AllergenDAL();
                dal.Delete(MyMapper.AllergenDTOToAllergen(dto));
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: HardDeleteAllergen");
            }
            return false;
        }

       
    }
}
