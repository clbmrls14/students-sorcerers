using StudentsAndSorcerers.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsAndSorcerers.API.Services
{
    public interface IDataService
    {
        Task CreateClassroom(Classroom classroom);
        Task CreateStudent(Student student);
        Task CreateLog(Log log);
        IQueryable<Classroom> Classrooms { get; }
        IQueryable<Student> Students { get; }
        IQueryable<Log> Logs { get; }
        Task UpdateClassroom(Classroom classroom);
        Task UpdateStudent(Student student);
        Task DeleteClassroom(Classroom classroom);
        Task DeleteStudent(Student student);
        Task DeleteLog(Log log);
    }
}
