using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicstoreAPI.Infrastructures.Entities
{
	public class Beers
	{
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string nombre {get; set;}
		public string estilo { get; set; }
		public string pais { get; set; }
	}
}

