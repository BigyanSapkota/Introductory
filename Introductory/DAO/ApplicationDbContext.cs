using Introductory.Models;
using Microsoft.EntityFrameworkCore;

namespace Introductory.DAO
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<UserGroup> UserGroup { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<ComplainType> ComplainType { get; set; }
        public DbSet<Complain> Complain { get; set; }

    }
}
