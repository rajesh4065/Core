using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Portal.ViewModels
{
    public class ListStudentsViewModel
    {
        public ListStudentsViewModel()
        {
            this.StudentsSources = new List<StudentsSourceViewModel>();
        }

        public IList<StudentsSourceViewModel> StudentsSources { get; set; }
    }
}
