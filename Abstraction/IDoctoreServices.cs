using HMS.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HMS.Abstraction
{
    public interface IDoctoreServices
    {
        // get all list
        Task<IEnumerable<Doctor>> GetAllDoctorsAsync();

        //  Add doctore
        Task AddDoctore(Doctor doctor);

        // GetDoctoreById 
        Task<Doctor> GetDoctoreById(Guid id);

        // Update Doctore
        void UpdateDoctore(Doctor doctor);

        // Delete Doctore
        void DeleteProduct(Guid id);

        // Soft Delete
        Task softDelete(Guid id);


        //  Enum Specilization list
        List<SelectListItem> GetDoctorSpecialties();

    }
}
