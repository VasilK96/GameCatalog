namespace GamesCatalogV.Context
{
	using GamesCatalogV.Entities;
	using System;
	using System.Collections;
	using System.Data.Entity;
	using System.Linq;

	public class GameCatalogDbContext : DbContext
	{
		public DbSet<Game> Games { get; set; }
		public DbSet<Rating> Ratings { get; set; }
		public DbSet<Ganre> Gneres { get; set; }
		public IEnumerable Ganres { get; internal set; }
	}
}
