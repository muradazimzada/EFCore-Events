using EFCore_Events.Context;
using EFCore_Events.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Events
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // First Unit-of-Work showing Add operation
            AddStudents();

            // Second Unit-of-Work showing Update and Remove operations
            await ModifyStudents();
        }

        static void AddStudents()
        {
            using var context = BuildUniversityContext();
            context.Add(
                new Student
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Address = "4 Privet Drive",
                });

            context.Add(
                new Student
                {
                    FirstName = "Jane",
                    LastName = "Doe",
                    Address = "4 Privet Drive",
                });
            context.SaveChanges();
        }

        static async Task ModifyStudents()
        {
            using var context = BuildUniversityContext();
            var student = await context.Students.Where(x => x.Id == 1).FirstOrDefaultAsync();
            student.FirstName = "Harry";
            student.LastName = "Potter";
            context.Update(student);

            var anotherStudent = await context.Students.Where(x => x.FirstName == "Jane").FirstOrDefaultAsync();
            context.Remove(anotherStudent);
            await context.SaveChangesAsync();
        }

        static UniversityContext BuildUniversityContext()
        {
            var dbContextBuilder = new DbContextOptionsBuilder<UniversityContext>();

            // HARDCODED - For this demo.  In real world apps, this should come from some kind of secrets manager
            var connectionString = "Data Source=FCNT332;Initial Catalog=University; Integrated Security=True;TrustServerCertificate=True;";

            dbContextBuilder.UseSqlServer(connectionString);
            return new UniversityContext(dbContextBuilder.Options);
        }
    }
}