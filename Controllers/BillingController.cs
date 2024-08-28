using HMS.Data;
using HMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    public class BillingController : Controller
    {
        public static List<Billing> _Billing= Seeds.SeedBilling();


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
            return View(_Billing);
        }

        // Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateBilling(Billing billing)
        {
            _Billing.Add(billing);
            return RedirectToAction("Index");
        }

        // Edit

        public IActionResult Edit(Guid id)
        {

            var billing = _Billing.FirstOrDefault(x => x.Id == id);

            return View(billing);
        }



        [HttpPost]
        public IActionResult Edit(Billing billing)
        {


            foreach (var item in _Billing)
            {
                if (billing.Id == item.Id)
                {
                    item.Id = billing.Id;
                    item.PatientId = billing.PatientId;
                    item.DoctoreId = billing.DoctoreId;
                    item.BillingDate = billing.BillingDate; 
                    item.Amount = billing.Amount;
                    item.IsPaid = billing.IsPaid;   
                }
            }
            return RedirectToAction("Index");
        }


        public IActionResult Details(Guid id)
        {

            var billing = _Billing.FirstOrDefault(p => p.Id == id);
            return View(billing);
        }





        public IActionResult Delete(Guid id)
        {

            var billing = _Billing.FirstOrDefault(x => x.Id == id);
            return View(billing);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(Guid id)
        {
            var removeBilling = _Billing.FirstOrDefault(d => d.Id == id);
            _Billing.Remove(removeBilling);
            return RedirectToAction("Index");
        }
    }
}
