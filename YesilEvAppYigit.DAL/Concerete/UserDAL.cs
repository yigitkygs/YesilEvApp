using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvAppYigit.Core.Repos;
using YesilEvAppYigit.Core;
using AutoMapper;
using YesilEvAppYigit.DTO;
using YesilEvAppYigit.Mapping;

namespace YesilEvAppYigit.DAL
{
    public class UserDAL : RepoBase<YesilEvDbContext, User>
    {
        public List<UserDTO> GetAllUsers()
        {
            List<UserDTO> dto = new List<UserDTO>();
            try
            {
                UserDAL dal = new UserDAL();
                dto = MyMapper.ListUserToListUserDTO(dal.GetAll());
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: KullanicilariGetir");
            }
            return dto;
        }
        public UserDTO KullaniciGetir(object ID)
        {
            UserDTO getirilecekDTO = new UserDTO();
            try
            {
                UserDAL dal = new UserDAL();
                getirilecekDTO = MyMapper.UserToUserDTO(dal.GetByID(ID));
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: KullaniciGetir");
            }
            return getirilecekDTO;
        }
        public bool AddNewUser(UserDTO dto)
        {
            try
            {
                UserDAL dal = new UserDAL();
                dal.Add(MyMapper.UserDTOToUser(dto));
                dal.MySaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: KullaniciEkle");
            }
            return false;
        }
        public void KullaniciGuncelle(UserDTO dto)
        {
            try
            {
                UserDAL dal = new UserDAL();
                dal.Update(MyMapper.UserDTOToUser(dto),dto.UserID);
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: KullaniciGuncelle");
            }
        }
        public bool KullaniciSil(object ID)
        {
            try
            {
                UserDAL dal = new UserDAL();
                dal.Delete(new UserDAL().GetByID(ID));
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: KullaniciSil");
            }
            return false;
        }
    }
}
