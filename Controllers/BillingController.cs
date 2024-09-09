using HMS.Abstraction;
using HMS.Data.Models;
using HMS.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HMS.Controllers
{
    public class BillingController : Controller
    {
        private readonly IBillingServices _billingServices;

        // Constructor
        public BillingController(IBillingServices billingServices)
        {
            _billingServices = billingServices;
        }

        // Index Page - List all billing records
        public async Task<IActionResult> Index()
        {
            var billingRecords = await _billingServices.GetAllBillingRecordsAsync();
            return View(billingRecords);
        }

        // Create Page
        public IActionResult Create()
        {
            return View();
        }

        // POST: Billing/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Billing billing)
        {
            if (ModelState.IsValid)
            {
                billing.Id = GuidExtensions.NewGuid(); // Assuming GuidExtensions.NewGuid() generates a new GUID
                await _billingServices.AddBillingRecord(billing);
                return RedirectToAction(nameof(Index));
            }

            return View(billing);
        }

        // Edit Page
        public async Task<IActionResult> Edit(Guid id)
        {
            var billing = await _billingServices.GetBillingById(id);
            if (billing == null)
            {
                return NotFound();
            }
            return View(billing);
        }

        // POST: Billing/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Billing billing)
        {
            if (id != billing.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _billingServices.UpdateBillingRecord(billing);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Handle exceptions (e.g., logging)
                    ModelState.AddModelError(string.Empty, "Unable to save changes.");
                }
            }

            return View(billing);
        }

        // Details Page
        public async Task<IActionResult> Details(Guid id)
        {
            var billing = await _billingServices.GetBillingById(id);
            if (billing == null)
            {
                return NotFound();
            }
            return View(billing);
        }

        // Delete Page
        public async Task<IActionResult> Delete(Guid id)
        {
            var billing = await _billingServices.GetBillingById(id);
            if (billing == null)
            {
                return NotFound();
            }
            return View(billing);
        }

        // POST: Billing/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SoftDelete(Guid id)
        {
            await _billingServices.SoftDeleteBillingRecord(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
