using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GamesCatalogV.Entities
{
	public class Ganre
	{
		[Key]
		public int Id { get; set; }

		[Display(Name = "Ganre")]
		[Required]
		public string ganreValue { get; set; }

		public string Description { get; set; }


		public virtual ICollection<Game> Game { get; set; }
		public object UserName { get; internal set; }
	}
}