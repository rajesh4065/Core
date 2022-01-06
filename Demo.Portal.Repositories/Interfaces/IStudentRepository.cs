using Demo.Portal.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Portal.Repositories
{
    public interface IStudentRepository
    {

        Task<IList<StudentDto>> GetStudents();

        Task<StudentDto> AddStudent(CreateStudentDto studentDto);

        //Task<CourseDto> AddCourse(CreateCourseDto createCourseDto);
    }
}
