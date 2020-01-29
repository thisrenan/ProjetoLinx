using AspNetCoreVueStarter.Model;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreVueStarter.DataAccess
{
	public class ArchDataContext : DbContext
	{
		public DbSet <Cidade> Cidades { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder.UseNpgsql("Host=35.199.85.181;Database=BDTeste;Username=postgres;Password=postgres");
	}
}