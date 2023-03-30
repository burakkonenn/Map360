using Application.Abstractions.Services.Company;
using Application.Abstractions.Services.CompanyTasks;
using Application.DTOs.Company;
using Application.DTOs.CompanyTasks;
using Application.DTOs.User;
using Domain.Entities.Task;
using Map360.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Map360.Controllers
{
    public class CompanyController : Controller
    {

        private readonly ICompanyService _companyService;
        private readonly ITaskService _taskService;
        public CompanyController(ICompanyService companyService, ITaskService taskService)
        {
            _companyService = companyService;
            _taskService=taskService;
        }


        [HttpGet]
        [Route("/companies")]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var result = await _companyService.GetAll();

            var task =new  TaskCreateDto();
            task.Name = "Yönetici";
        
            await _taskService.CreateAsync(task);

            return View(result.Data);
        }

        [Route("/company/details")]
        public async Task<IActionResult> Details(int id)
        {
            var response = await _companyService.GetCompanyUsers(id);
            return View(response.Data);
        }
        [HttpGet]
        [Route("company/create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [Route("company/create")]
        public async Task<JsonResult> Create(CompanyCreateDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _companyService.CreateAsync(model);
                return Json(response);
            }
            return Json(model);
        }
        [Route("company/edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var company = await _companyService.GetByIdAsync(id);
            return View(company.Data);
        }
        [HttpPut]
        [Route("company/edit")]
        public async Task<JsonResult> Edit(CompanyUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _companyService.UpdateAsync(model);
                return Json(response);
            }
            return Json(model);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _companyService.Remove(id);

            return Ok();
        }

    }
}
