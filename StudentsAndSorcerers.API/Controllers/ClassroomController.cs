using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsAndSorcerers.API.Services;
using StudentsAndSorcerers.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsAndSorcerers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        private readonly IDataService dataService;
        private readonly ValidationService validationService;

        public ClassroomController(IDataService dataService, ValidationService validationService)
        {
            this.dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            this.validationService = validationService ?? throw new ArgumentNullException(nameof(validationService));
        }

        [HttpGet("[action]")]
        public async Task<List<Classroom>> GetClassrooms() => await dataService.Classrooms.ToListAsync();

        [HttpGet("[action]")]
        public async Task<List<Student>> GetStudentsByClassroom(Classroom classroom) => await dataService.Students.Where(s => s.Classroom == classroom).ToListAsync();

        [HttpGet("[action]")]
        public async Task<List<Student>> GetStudents() => await dataService.Students.ToListAsync();

        [HttpGet("[action]")]
        public async Task<List<Log>> GetLogs() => await dataService.Logs.ToListAsync();

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddClassroom(Classroom classroom)
        {
            if (validationService.ValidateClassroom(classroom))
            {
                await dataService.CreateClassroom(classroom);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddStudent(Student student)
        {
            if (validationService.ValidateStudent(student))
            {
                await dataService.CreateStudent(student);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddLog(Log log)
        {
            if (validationService.ValidateLog(log))
            {
                await dataService.CreateLog(log);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateClassroom(Classroom classroom)
        {
            if (validationService.ValidateClassroom(classroom))
            {
                await dataService.UpdateClassroom(classroom);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateStudent(Student student)
        {
            if (validationService.ValidateStudent(student))
            {
                await dataService.UpdateStudent(student);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("[action]")]
        public async Task DeleteClassroom(Classroom classroom)
        {
            await dataService.DeleteClassroom(classroom);
        }

        [HttpPost("[action]")]
        public async Task DeleteStudent(Student student)
        {
            await dataService.DeleteStudent(student);
        }

        [HttpPost("[action]")]
        public async Task DeleteLog(Log log)
        {
            await dataService.DeleteLog(log);
        }
    }
}
