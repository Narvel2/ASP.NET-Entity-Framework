using System.Data.Entity;
using AdrianPiecykLab6.Models;

namespace AdrianPiecykLab6.DataAccess
{
    public class ContactDbContext : DbContext
    {

        public ContactDbContext() : base("Context")
        {
        }

        public DbSet<Course>Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        

    }
}