using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Portal.Common.Dtos;
using Demo.Portal.Services.Interfaces;
using Demo.Portal.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Demo.Portal.Controllers
{

    /// <summary>The insert controller.</summary>
    [Route("[controller]")]
    public class StudentsController : Controller
    {
        private readonly ILogger<StudentsController> _logger;

        private readonly IStudentService _iStudentService;



        public StudentsController(ILogger<StudentsController> logger, IStudentService iStudentService)
        {
            this._logger = logger;
            this._iStudentService = iStudentService;
        }

        /// <summary>The index/list of insert sources.</summary>
        /// <returns>The index view.</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var listViewModel = new ListStudentsViewModel();
                var result = await this._iStudentService.GetStudents();
                listViewModel.StudentsSources = result.Select(x => new StudentsSourceViewModel(x)).ToList();
                return this.View(listViewModel);

            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Exception: {nameof(StudentsController)}/{nameof(this.Index)}: {ex.Message}");
                throw;
            }
        }


        [HttpGet("add")]
        public IActionResult Add()
        {
            return this.View(new AddStudentViewModel());
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add(AddStudentViewModel model)
        {
            try
            {
                if (this.ModelState.IsValid && model != null)
                {
                    var create = new CreateStudentDto();
                    create.Name = model.Name;
                    var result = await this._iStudentService.AddStudent(create);
                    if (result.StudentId > 0)
                    {
                        return this.RedirectToAction("Index", "Students");
                    }
                }

                return this.View(model);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Exception: {nameof(StudentsController)}/{nameof(this.Add)}: {ex.Message}");
                throw;
            }
        }


    }
}
