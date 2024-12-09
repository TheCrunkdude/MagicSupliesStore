using System;
using System.ComponentModel.DataAnnotations;

namespace MagicstoreAPI.Infrastructures.DTO
{

    public class UsersDTO
    {
        [Key]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        public string Mail { get; set; }
        public DateTime CreationDate { get; set; }

    }
}

