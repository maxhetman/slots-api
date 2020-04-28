using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
	public class SlotsContext : DbContext
	{
		public DbSet<Slot> Slots { get; set; }

		public SlotsContext(DbContextOptions options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(SlotsContext).Assembly);
		}
	}
}
