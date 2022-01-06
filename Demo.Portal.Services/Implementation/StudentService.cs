using Demo.Portal.Common.Dtos;
using Demo.Portal.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Portal.Repositories;

namespace Demo.Portal.Services.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly ILogger<StudentService> _logger;

        private readonly IStudentRepository _studentRepository;
        public StudentService(ILogger<StudentService> logger, IStudentRepository studentRepository)
        {
            _logger = logger;
            _studentRepository = studentRepository;
        }

        //public async Task<CourseDto> AddCourse(CreateCourseDto createCourseDto)
        //{
        //    return await _studentRepository.AddCourse(createCourseDto);
        //}

        public async Task<StudentDto> AddStudent(CreateStudentDto studentDto)
        {
            return await _studentRepository.AddStudent(studentDto);
        }

        public async Task<IList<StudentDto>> GetStudents()
        {
            return await _studentRepository.GetStudents();
        }
    }
}
