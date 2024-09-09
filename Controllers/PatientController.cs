using HMS.Abstraction;
using HMS.Data;
using HMS.Extensions;
using HMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    public class PatientController : Controller
    {
        // Inject Services
        private readonly IPatientServices _patientService;
        public PatientController(IPatientServices patientServices)
        {
            _patientService = patientServices;
        }

        public IActionResult Index(string SearchTerm)
        {
            List<Patient> patients = _patientService.GetPatients(); // Assuming GetPatients returns a List<Patient>

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

            ViewData["CurrentFilter"] = SearchTerm;

            return View(filteredPatients.ToList());
        }


        // Create
        public IActionResult Create()
        {
            return View();
        }


        public IActionResult CreatePatient(Patient patient)
        {
            _patientService.AddPatient(patient);
            return RedirectToAction("Index");
        }

        // Edit

        public IActionResult Edit(Guid id)
        {

            var patient = _patientService.GetPatientById(id);

            return View(patient);
        }



        [HttpPost]
        public IActionResult Edit(Patient patient)
        {
            Patient _patients = _patientService.GetPatientById(patient.Id);

            if(_patients != null )
            {
                _patientService.RemovePatient(_patients);
                _patientService.AddPatient(patient);   
            }
            
            return RedirectToAction("Index");
        }


        public IActionResult Details(Guid Id)
        {
           var patient = _patientService.GetPatientById(Id); 
            return View(patient);
        }


        public IActionResult Delete(Patient patient)
        {
            return View(patient);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(Guid Id)
        {
            _patientService.RemovePatient(Id);
            return RedirectToAction("Index");
        }



    }
}
