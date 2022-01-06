using Demo.Portal.Common.Dtos;

namespace Demo.Portal.ViewModels
{
    public class StudentsSourceViewModel
    {

        public StudentsSourceViewModel(StudentDto dto)
        {
            this.StudentId = dto.StudentId;
            this.Name = dto.Name;

        }
        public int StudentId { get; set; }
        public string Name { get; set; }
    }
}
