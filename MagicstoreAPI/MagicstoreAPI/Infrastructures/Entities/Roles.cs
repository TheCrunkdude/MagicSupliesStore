using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MagicstoreAPI.Infrastructures.Entities
{
	public class Roles
	{
        [Key]
        public int ID { get; set; }
        public int PermissionsID { get; set; }
        public string Role { get; set; }
     
    }
}

