using Microsoft.EntityFrameworkCore;
using SwapnaliTask.Models;

namespace SwapnaliTask.Data
{
	public class ApplicationDbContext:DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

		public DbSet<User> users { get; set; }
		public DbSet<Entry> entries { get; set; }
		public DbSet<Audit> audits { get; set; }
	}
}
