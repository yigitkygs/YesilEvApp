using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEvAppYigit.DTO
{
    public class UserDTO
    {
        public int UserID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int RoleID { get; set; }
        public bool? IsActive { get; set; }
        public List<BlacklistDTO> Blacklists { get; set; }
        public List<FavoriteDTO> Favorites { get; set; }
        public List<SearchDTO> Searches { get; set; }

        public override string ToString()
        {
            return Username;
        }
    }
}
