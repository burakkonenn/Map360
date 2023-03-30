
using Application.Abstractions.Services.Company;
using Application.Abstractions.Services.CompanyTasks;
using Application.Abstractions.Services.User;
using Application.DTOs.Company;
using Application.DTOs.User;
using Map360.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;


namespace Map360.Controllers
{
    public class UserController : Controller
    {

        private readonly ITaskService _taskService;
        private readonly ICompanyService _companyService;
        private readonly IUserService _userService;
        public UserController(ITaskService taskService, ICompanyService companyService, IUserService userService)
        {
            _taskService = taskService;
            _companyService = companyService;
            _userService = userService;
        }


        [HttpGet]
        [Route("/users")]
        public async Task<IActionResult> Index()
        {

            var response = await _userService.GetAll();
            return View(response.Data);
        }

        [HttpGet]
        [Route("/users/details")]
        public async Task<IActionResult> Details(int id)
        {
            var response = await _userService.GetByIdUserDetailsAsync(id);
            return View(response.Data);
        }
        [HttpGet]
        [Route("user/create")]
        public async Task<IActionResult> Create()
        {

            ViewBag.Companies = await _userService.Companies();
            ViewBag.Tasks = await _userService.Tasks();
            return View();
        }
        [HttpPost]
        [Route("user/create")]
        public async Task<JsonResult> Create(UserCreateDto model)
         {
            if (ModelState.IsValid)
            {
                var response = await _userService.CreateAsync(model);
                return Json(response);
            }
            return Json(model);
        }
        [Route("user/edit")]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Companies = await _userService.Companies();
            ViewBag.Tasks = await _userService.Tasks();
            var company = await _userService.GetByIdAsync(id);
            return View(company.Data);
        }
        [HttpPut]
        [Route("user/edit")]
        public async Task<JsonResult> Edit(UserUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _userService.UpdateAsync(model);
                return Json(response);
            }
            return Json(model);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Remove(id);

            return Ok();
        }
    }
}
