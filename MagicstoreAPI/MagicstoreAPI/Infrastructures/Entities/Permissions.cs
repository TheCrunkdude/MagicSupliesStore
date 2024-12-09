using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MagicstoreAPI.Infrastructures.Entities
{
	public class Permissions
	{
        [Key]
        public int ID { get; set; }
        public string Permission { get; set; }
        public string Description { get; set; }

    }
}

