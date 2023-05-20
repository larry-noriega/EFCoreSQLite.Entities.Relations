using EFCollections;

namespace EFCollectionsConsole
{
	class Program
	{
		static void CreateData(TrainingContext db)
		{
			Classroom r1 = new() { Number = "R101" };
			Classroom r2 = new() { Number = "R202" };

			Teacher t1 = new() { Name = "Miss Anderson", Classroom = r1 };
			Teacher t2 = new() { Name = "Miss Bingham", Classroom = r2 };

			Course c1 = new() { Title = "Introduction to EF Core", Author = t1, Editor = t2 };
			Course c2 = new() { Title = "Basic Car Maintenance", Author = t2, Editor = t1 };

			Student s1 = new() { Name = "Elpa Drino", Classroom = r1 };
			Student s2 = new() { Name = "Kenny Kent", Classroom = r1 };
			Student s3 = new() { Name = "Elssa Capunta", Classroom = r1 };
			Student s4 = new() { Name = "Micky Most", Classroom = r2 };
			Student s5 = new() { Name = "Armando Cassas", Classroom = r2 };
			Student s6 = new() { Name = "Ozzy Osborne", Classroom = r2 };


			c1.Students = new Student[] { s1, s2, s3, s4 };
			c2.Students = new Student[] { s3, s4, s5, s6 };

			db.Add(c1);
			db.Add(c2);

			db.SaveChangesAsync();
		}

		static void Main()
		{
			using var db = new TrainingContext();

			db.Database.EnsureDeletedAsync();
			db.Database.EnsureCreatedAsync();

			CreateData(db);
		}
	}
}
