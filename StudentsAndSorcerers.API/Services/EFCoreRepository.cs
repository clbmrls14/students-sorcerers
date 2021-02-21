using StudentsAndSorcerers.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsAndSorcerers.API.Services
{
    public class EFCoreRepository : IDataService
    {
        private readonly ApplicationDbContext dbContext;
        public EFCoreRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IQueryable<Classroom> Classrooms => dbContext.Classrooms;

        public IQueryable<Student> Students => dbContext.Students;

        public IQueryable<Log> Logs => dbContext.Logs;

        public async Task CreateClassroom(Classroom classroom)
        {
            dbContext.Classrooms.Add(classroom);
            await dbContext.SaveChangesAsync();
        }

        public async Task CreateLog(Log log)
        {
            dbContext.Logs.Add(log);
            await dbContext.SaveChangesAsync();
        }

        public async Task CreateStudent(Student student)
        {
            dbContext.Students.Add(student);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateClassroom(Classroom classroom)
        {
            dbContext.Classrooms.Update(classroom);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateStudent(Student student)
        {
            dbContext.Students.Update(student);
            await dbContext.SaveChangesAsync();
        }
        public async Task DeleteClassroom(Classroom classroom)
        {
            dbContext.Classrooms.Remove(classroom);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteStudent(Student student)
        {
            dbContext.Students.Remove(student);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteLog(Log log)
        {
            dbContext.Logs.Remove(log);
            await dbContext.SaveChangesAsync();
        }
    }
}
