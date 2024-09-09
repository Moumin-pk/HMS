using HMS.Abstraction;
using HMS.Data.Models;
using HMS.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HMS.Controllers
{
    public class DoctoreController : Controller
    {
        private readonly IDoctoreServices _doctoreServices;

        // Controller 
        public DoctoreController(IDoctoreServices doctoreServices)
        {
            _doctoreServices = doctoreServices;
        }

        //  Doctore Index Page
        public async Task<IActionResult> Index()
        {
            var doctore = await _doctoreServices.GetAllDoctorsAsync();
            return View(doctore);
        }



        public IActionResult Create()
        {
            var specialtyList = _doctoreServices.GetDoctorSpecialties();
            ViewBag.SpecialtyList = specialtyList;
            return View();
        }


        public async Task<IActionResult> CreateDoctore(Doctor doctore)
        {
            if (doctore != null)
            {
                doctore.Id = GuidExtensions.NewGuid();
                await _doctoreServices.AddDoctore(doctore);
                return RedirectToAction("Index");
            }

            return View(doctore);
        }

        // Doctore Edit Page
        public async Task<IActionResult> Edit(Guid id)
        {
            var specialtyList = _doctoreServices.GetDoctorSpecialties();
            ViewBag.SpecialtyList = specialtyList;

            var doctore = await _doctoreServices.GetDoctoreById(id);
            if (doctore == null)
            {
                return NotFound();
            }
            return View(doctore);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _doctoreServices.UpdateDoctore(doctor);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Handle exceptions (e.g., logging)
                    ModelState.AddModelError(string.Empty, "Unable to save changes.");
                }
            }

            return View(doctor);
        }

        // Details
        public async Task<IActionResult> Details(Guid id)
        {
            var doctoreDetail = await _doctoreServices.GetDoctoreById(id);
            if(doctoreDetail == null)
            {
                return null;
            }
            return View(doctoreDetail);
        }

        // Delete
        public async Task<IActionResult> Delete(Guid Id)
        {
            var doctore = await _doctoreServices.GetDoctoreById(Id);
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
            await _doctoreServices.softDelete(id);
            return RedirectToAction(nameof(Index));
        }



        

    }
}
