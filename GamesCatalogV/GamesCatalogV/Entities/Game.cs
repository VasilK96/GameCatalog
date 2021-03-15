using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GamesCatalogV.Entities
{
	public class Game
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(150, MinimumLength = 3)]
		public string Title { get; set; }

		[Display(Name = "Release date")]
		[DataType(DataType.Date)]
		public DateTime? ReleaseDate { get; set; }


		[Display(Name = "Rating")]
		public int? RatingId { get; set; }
		public virtual Rating Rating { get; set; }

		[Display(Name = "Writer")]
		public int? GanreId { get; set; }
		public virtual Ganre Writer { get; set; }
		public object Genre { get; internal set; }
	}
}