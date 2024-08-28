using HMS.Data;
using HMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    public class AppointmentController : Controller
    {
        public static List<Appointment> _Appointment = Seeds.SeedAppointment();


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
            return View(_Appointment);
        }

        // Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateAppointment(Appointment appointment)
        {
            _Appointment.Add(appointment);
            return RedirectToAction("Index");
        }

        // Edit

        public IActionResult Edit(Guid id)
        {

            var appointment = _Appointment.FirstOrDefault(x => x.Id == id);

            return View(appointment);
        }



        [HttpPost]
        public IActionResult Edit(Appointment appointment)
        {


            foreach (var item in _Appointment)
            {
                if (appointment.Id == item.Id)
                {
                    item.Id = appointment.Id;
                    item.PatientId = appointment.PatientId;
                    item.DoctoreId = appointment.DoctoreId;
                    item.AppointmentDate = appointment.AppointmentDate;
                    item.Purpose = appointment.Purpose;
                    item.IsCompleted = appointment.IsCompleted;
                   
                }
            }
            return RedirectToAction("Index");
        }


        public IActionResult Details(Guid id)
        {

            var appointment = _Appointment.FirstOrDefault(p => p.Id == id);

            return View(appointment);
        }





        public IActionResult Delete(Guid id)
        {

            var appointment = _Appointment.FirstOrDefault(x => x.Id == id);

            return View(appointment);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(Guid id)
        {
            var removeappointment = _Appointment.FirstOrDefault(d => d.Id == id);
            _Appointment.Remove(removeappointment);
            return RedirectToAction("Index");
        }



    }
}
