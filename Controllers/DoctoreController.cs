using HMS.Data;
using HMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    public class DoctoreController : Controller
    {
        public static List<Doctore> _Doctore = Seeds.SeedDoctore();


        public IActionResult Index(string SearchTerm)
        {
           /* List<Patient> patients = _patientService.GetPatients(); // Assuming GetPatients returns a List<Patient>*/

            var filteredPatients = _Doctore.AsQueryable();

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

        public IActionResult CreateDoctore(Doctore doctore)
        {
            _Doctore.Add(doctore);
            return RedirectToAction("Index");
        }

        // Edit

        public IActionResult Edit(Guid id)
        {

            var doctore = _Doctore.FirstOrDefault(x => x.Id == id);

            return View(doctore);
        }



        [HttpPost]
        public IActionResult Edit(Doctore doctore)
        {


            foreach (var item in _Doctore)
            {
                if (doctore.Id == item.Id)
                {
                    item.Id = doctore.Id;
                    item.Name = doctore.Name;
                    item.Specialization = doctore.Specialization;
                    item.Experience = doctore.Experience;   
                    item.ContactNumber = doctore.ContactNumber; 
                    item.Email = doctore.Email;
                    item.DepartmentId = doctore.DepartmentId;
                }
            }
            return RedirectToAction("Index");
        }


        public IActionResult Details(Guid id)
        {

            var patient = _Doctore.FirstOrDefault(p => p.Id == id);

            return View(patient);
        }





        public IActionResult Delete(Guid id)
        {

            var patient = _Doctore.FirstOrDefault(x => x.Id == id);

            return View(patient);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(Guid id)
        {
            var removepatient = _Doctore.FirstOrDefault(d => d.Id == id);
            _Doctore.Remove(removepatient);
            return RedirectToAction("Index");
        }



    }
}

