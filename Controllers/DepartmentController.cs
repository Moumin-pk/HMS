using HMS.Data;
using HMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    public class DepartmentController : Controller
    {
        public static List<Department> _Department = Seeds.SeedDepartment();


        /*public IActionResult Index(string searchTerm)
        {
            var appointment = _Appointment.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                appointment = appointment.Where(d => d.Purpose.Contains(searchTerm));
            }

            ViewData["CurrentFilter"] = searchTerm;
            return View(appointment.ToList());
        }*/

        public IActionResult Index()
        {
            return View(_Department);
        }

        // Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateDepartment(Department department)
        {
            _Department.Add(department);
            return RedirectToAction("Index");
        }

        // Edit

        public IActionResult Edit(Guid id)
        {

            var department = _Department.FirstOrDefault(x => x.Id == id);

            return View(department);
        }



        [HttpPost]
        public IActionResult Edit(Department department)
        {


            foreach (var item in _Department)
            {
                if (department.Id == item.Id)
                {
                    item.Id = department.Id;
                   item.ContactNumber = department.ContactNumber;
                    item.HeadOfDepartment = department.HeadOfDepartment;
                    item.Name = department.Name;

                }
            }
            return RedirectToAction("Index");
        }


        public IActionResult Details(Guid id)
        {

            var department = _Department.FirstOrDefault(p => p.Id == id);

            return View(department);
        }





        public IActionResult Delete(Guid id)
        {

            var department = _Department.FirstOrDefault(x => x.Id == id);

            return View(department);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(Guid id)
        {
            var removeDepartment = _Department.FirstOrDefault(d => d.Id == id);
            _Department.Remove(removeDepartment);
            return RedirectToAction("Index");
        }



    }
}
