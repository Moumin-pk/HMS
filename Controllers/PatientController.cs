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

        public IActionResult Index()
        {
            List<Patient> patient = _patientService.GetPatients();
            return View(patient);
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

        /* public IActionResult Edit(Guid id)
         {

             var patient = _patients.FirstOrDefault(x => x.Id == id);

             return View(patient);
         }
 */


        /*[HttpPost]
        public IActionResult Edit(Patient patient)
        {
            

            foreach (var item in _patients)
            {
                if (patient.Id == item.Id)
                {
                    item.Id = patient.Id;
                    item.Name = patient.Name;
                    item.Address = patient.Address;
                    item.Age = patient.Age;
                    item.Gender = patient.Gender;
                    item.DiscahrgeDate = patient.DiscahrgeDate;
                    item.AdmissionDate = patient.AdmissionDate;
                    item.ContactNumber = patient.ContactNumber;
                }
            }
            return RedirectToAction("Index");
        }*/


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
