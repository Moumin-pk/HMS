
using Microsoft.AspNetCore.Mvc;
using HMS.Abstraction;
using HMS.Data.Models;
using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore;
using HMS.Services;
using HMS.Extensions;
using FluentValidation;

namespace HMS.Controllers
{
    public class PatientController : Controller
    {
        // Inject Services
       
        private readonly IPatientServices _patientService;

        // controller
        public PatientController(IPatientServices patientServices)
        {

            _patientService = patientServices;
           
        }


        //  patient index ->  add Search Funcnality


        public async Task<IActionResult> Index(string SearchTerm)
        {
            // Asynchronously retrieve the list of patients
            var patients = await _patientService.GetPatients(); // Assuming GetPatients returns a List<Patient>

            var filteredPatients = patients.AsQueryable();

            if (!string.IsNullOrEmpty(SearchTerm))
            {
                // Search by name, contact number, and email (case-insensitive)
                filteredPatients = filteredPatients.Where(p =>
                    p.Name.ToLower().Contains(SearchTerm.ToLower()) ||
                    p.ContactNumber.Contains(SearchTerm) ||
                    p.Email.ToLower().Contains(SearchTerm.ToLower())
                );
            }

            // Pass the current search term to the view
            ViewData["CurrentFilter"] = SearchTerm;

            // Return the filtered list to the view
            return View(filteredPatients.ToList());
        }


        // Create
        public IActionResult Create()
        {
            var Genderlist = _patientService.GetGender();
            ViewBag.Genderlist = Genderlist;
            return View();
        }

        //  Create new Patient

        [HttpPost]
        public IActionResult CreatePatient(Patient patient)
        {
            patient.Id = GuidExtensions.NewGuid();
            _patientService.AddPatient(patient);
            return RedirectToAction("Index");
        }


        


        public async Task<IActionResult> Edit(Guid id)
        {
            var Genderlist = _patientService.GetGender();
            ViewBag.Genderlist = Genderlist;
            var patient = await _patientService.GetPatientById(id);


            return View(patient);
        }


        // POST: Departments/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Patient patient)
        {
            await _patientService.UpdatePatient(patient);
            return RedirectToAction("Index");
        }











        public async Task<IActionResult> Details(Guid id)
        {
            var patient = await _patientService.GetPatientById(id);

            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

       
        public async Task<IActionResult> Delete(Guid id)
        {
            var patient = await _patientService.GetPatientById(id);

            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SoftDelete(Guid id)
        {
            await _patientService.softDelete(id);
            return RedirectToAction(nameof(Index));
        }


    }
}

