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
                dto = MyMapper.ListUserToListUserDTO(dal.GetAll().Where(a => a.IsActive == true).ToList());
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: GetAllUsers");
            }
            return dto;
        }
        public List<UserDTO> GetAllUsersAdmin()
        {
            List<UserDTO> dto = new List<UserDTO>();
            try
            {
                UserDAL dal = new UserDAL();
                dto = MyMapper.ListUserToListUserDTO(dal.GetAll());
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: GetAllUsers");
            }
            return dto;
        }
        public UserDTO GetUserFromID(object ID)
        {
            UserDTO getirilecekDTO = new UserDTO();
            try
            {
                UserDAL dal = new UserDAL();
                getirilecekDTO = MyMapper.UserToUserDTO(dal.GetByID(ID));
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: GetUserFromID");
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
                Console.WriteLine("Hata: AddNewUser");
            }
            return false;
        }
        public void UpdateUser(UserDTO dto)
        {
            try
            {
                UserDAL dal = new UserDAL();
                dal.Update(MyMapper.UserDTOToUser(dto),dto.UserID);
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: UpdateUser");
            }
        }
        public void SoftDeleteUser(UserDTO dto)
        {
            try
            {
                UserDAL dal = new UserDAL();
                dto.IsActive = false;
                dal.Update(MyMapper.UserDTOToUser(dto), dto.UserID);
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: SoftDeleteUser");
            }
        }
        public void RevertSoftDeleteUser(UserDTO dto)
        {
            try
            {
                UserDAL dal = new UserDAL();
                dto.IsActive = true;
                dal.Update(MyMapper.UserDTOToUser(dto), dto.UserID);
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: RevertSoftDeleteUser");
            }
        }
        public bool HardDeleteUser(object ID)
        {
            try
            {
                UserDAL dal = new UserDAL();
                dal.Delete(new UserDAL().GetByID(ID));
                dal.MySaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: HardDeleteUser");
            }
            return false;
        }
    }
}
