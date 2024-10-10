using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MagicstoreAPI.Infrastructures.Entities
{
	public class Users
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

