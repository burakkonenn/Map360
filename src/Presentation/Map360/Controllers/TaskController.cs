using Application.Abstractions.Services.CompanyTasks;
using Application.DTOs.Company;
using Application.DTOs.CompanyTasks;
using Map360.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Persistance.Context;

namespace Map360.Controllers
{
    public class TaskController : Controller
    {

        private readonly ITaskService _taskService;
        private readonly ApplicationDbContext _context;
        public TaskController(ITaskService taskService, ApplicationDbContext context)
        {
            _taskService = taskService;
            _context = context;
        }


        [Route("/task")]
        public async Task<IActionResult> Index()
        {
            var data = await _taskService.GetAll();
            ViewBag.Task = data;
            return View();
        }

        [Route("/task/detail")]
        public async Task<IActionResult> Details(int id)
        {
            var userTaskDetails = await _taskService.UserTasksDetailsUsers(id);
            return View(userTaskDetails.Data);
        }


        //public async Task<IActionResult> Create() => View();

        [HttpPost]
        [Route("task/create")]
        public async Task<JsonResult> Create(TaskCreateDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _taskService.CreateAsync(model);
                return Json(response);
            }
            return Json(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var reponse = await _taskService.GetByIdAsync(id);
            return Json(reponse);
        }

        [HttpPost]
        public async Task<JsonResult> Edit(string name, int id)
        {
            if (ModelState.IsValid)
            {
                var response = await _taskService.UpdateAsync(name, id);
                return Json(response);
            }
            else
            {
                return Json(name);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _taskService.Remove(id);
            return Ok();
        }
    }
}
