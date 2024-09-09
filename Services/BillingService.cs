using HMS.Abstraction;
using HMS.Data.Models;
using HMS.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HMS.Services
{
    public class BillingServices : IBillingServices
    {
        private readonly HmsContext _hmscontext;

        public BillingServices(HmsContext hmscontext)
        {
            _hmscontext = hmscontext;
        }

        // Get all billing records or apply filter to display only active records
        public async Task<IEnumerable<Billing>> GetAllBillingRecordsAsync()
        {
            var billingRecords = await _hmscontext.Billings.ToListAsync();
            //return billingRecords.Where(b => b.IsActive == true);
            return billingRecords;
        }

        // Get billing record by ID or return the model
        public async Task<Billing> GetBillingById(Guid id)
        {
            var billing = await _hmscontext.Billings.FirstOrDefaultAsync(b => b.Id == id);
            return billing;
        }

        // Add new billing record
        public async Task AddBillingRecord(Billing billing)
        {
            _hmscontext.Billings.Add(billing);
            await _hmscontext.SaveChangesAsync();
        }

        // Update an existing billing record
        public async Task UpdateBillingRecord(Billing billing)
        {
            _hmscontext.Billings.Update(billing);
            await _hmscontext.SaveChangesAsync();
        }

        // Soft delete a billing record by its ID
        // Soft delete method sets IsActive to false
        public async Task SoftDeleteBillingRecord(Guid id)
        {
            var billing = await GetBillingById(id);
            if (billing != null)
            {
                //billing.IsActive = false;
                _hmscontext.Billings.Update(billing);
                await _hmscontext.SaveChangesAsync();
            }
        }

        // Example methods that are not yet implemented
        public Task<List<Billing>> GetAllBillingRecords()
        {
            throw new NotImplementedException();
        }

        public Task AddBillingRecordAsync(Billing billing)
        {
            throw new NotImplementedException();
        }

        public void DeleteBillingRecord(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
