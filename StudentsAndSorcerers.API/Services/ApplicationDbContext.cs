using Microsoft.EntityFrameworkCore;
using StudentsAndSorcerers.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsAndSorcerers.API.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}
