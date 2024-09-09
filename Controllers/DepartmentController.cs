using HMS.Abstraction;
using HMS.Data.Models;
using HMS.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HMS.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentServices _departmentServices;

        // Controller 
        public DepartmentController(IDepartmentServices departmentServices)
        {
            _departmentServices = departmentServices;
        }

        //  Doctore Index Page
        public async Task<IActionResult> Index()
        {
            var doctore = await _departmentServices.GetAllDepartmentAsync();
            return View(doctore);
        }



        public IActionResult Create()
        {
            return View();
        }


        public async Task<IActionResult> CreateDepartment(Department department)
        {
            if (department != null)
            {
                department.Id = GuidExtensions.NewGuid();
                await _departmentServices.AddDepartment(department);
                return RedirectToAction("Index");
            }

            return View(department);
        }

        // Doctore Edit Page
        public async Task<IActionResult> Edit(Guid id)
        {
            

            var department = await _departmentServices.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, Department department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _departmentServices.UpdateDepartment(department);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Handle exceptions (e.g., logging)
                    ModelState.AddModelError(string.Empty, "Unable to save changes.");
                }
            }

            return View(department);
        }

        // Details
        public async Task<IActionResult> Details(Guid id)
        {
            var doctoreDetail = await _departmentServices.GetDepartmentById(id);
            if (doctoreDetail == null)
            {
                return null;
            }
            return View(doctoreDetail);
        }

        // Delete
        public async Task<IActionResult> Delete(Guid Id)
        {
            var doctore = await _departmentServices.GetDepartmentById(Id);
            if (doctore == null)
            {
                return NotFound();
            }
            return View(doctore);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SoftDelete(Guid id)
        {
            await _departmentServices.softDelete(id);
            return RedirectToAction(nameof(Index));
        }





    }
}
