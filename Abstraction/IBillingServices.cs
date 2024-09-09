using HMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HMS.Abstraction
{
    public interface IBillingServices
    {
        // Get all billing records or apply filter to display only active records
        Task<IEnumerable<Billing>> GetAllBillingRecordsAsync();

        // Get a billing record by ID
        Task<Billing> GetBillingById(Guid id);

        // Add a new billing record
        Task AddBillingRecord(Billing billing);

        // Update an existing billing record
        Task UpdateBillingRecord(Billing billing);

        // Soft delete a billing record by its ID
        Task SoftDeleteBillingRecord(Guid id);

        // Additional methods (if needed)
        Task<List<Billing>> GetAllBillingRecords();  // This method seems redundant with the async version
        Task AddBillingRecordAsync(Billing billing); // This method seems redundant with the async version
        void DeleteBillingRecord(Guid id);  // Implement if you need hard delete
    }
}
