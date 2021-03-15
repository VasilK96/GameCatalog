using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GamesCatalogV.Entities
{
	public class Rating
	{
		[Key]
		public int Id { get; set; }

		[Display(Name = "Rating")]
		[Required]
		[StringLength(100)]
		public string RatingValue { get; set; }

		[StringLength(400)]
		public string Description { get; set; }

		public virtual ICollection<Game> Game { get; set; }
	}
}