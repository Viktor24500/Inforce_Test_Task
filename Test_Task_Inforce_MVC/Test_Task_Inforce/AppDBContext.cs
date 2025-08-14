using Microsoft.EntityFrameworkCore;
using Test_Task_Inforce.DTO;

namespace Test_Task_Inforce
{
	public class AppDBContext : DbContext
	{
		public DbSet<UserDTO> User { get; set; }
		public DbSet<RoleDTO> Role { get; set; }

		public DbSet<DescriptionDTO> Description { get; set; }

		public DbSet<ShortUrlDTO> ShortUrl { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=DESKTOP-TKSFTUA;Database=EfSimpleDb;Trusted_Connection=True;TrustServerCertificate=True");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<UserDTO>().HasKey(u => u.Id);
			modelBuilder.Entity<RoleDTO>().HasKey(r => r.Id);
			modelBuilder.Entity<DescriptionDTO>().HasKey(d => d.DescriptionID);
			modelBuilder.Entity<ShortUrlDTO>().HasKey(s => s.Id);

			modelBuilder.Entity<UserDTO>()
				.HasOne(r => r.Role)
				.WithMany(u => u.Users)
				.HasForeignKey(r => r.RoleId);

			modelBuilder.Entity<ShortUrlDTO>()
				.HasOne(u => u.User)
				.WithMany(s => s.ShortUrls)
				.HasForeignKey(u => u.CreatedBy);
		}
	}
}
