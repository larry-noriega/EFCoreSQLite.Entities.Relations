// Ignore Spelling: Db

using Microsoft.EntityFrameworkCore;

namespace EFCollections
{
	public class TrainingContext : DbContext
	{
		public DbSet<Classroom> Classrooms { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<Teacher> Teachers { get; set; }

		public string DbPath { get; }

		public TrainingContext()
		{
			var folder = Environment.SpecialFolder.LocalApplicationData;
			var path = Environment.GetFolderPath(folder);
			DbPath = Path.Join(path, "training.db");
		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		=> options.UseSqlite($"Data Source={DbPath}");

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Course>().HasOne(c => c.Editor).WithMany(t => t.CoursesEdited);
			modelBuilder.Entity<Course>().HasOne(c => c.Author).WithMany(t => t.CoursesWritten);
		}
	}
}
	