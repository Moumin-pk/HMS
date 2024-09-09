using HMS.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HMS.Abstraction
{
    public interface IDepartmentServices
    {
        // get all list
        Task<IEnumerable<Department>> GetAllDepartmentAsync();

        //  Add doctore
        Task AddDepartment(Department department);

        // GetDoctoreById 
        Task<Department> GetDepartmentById(Guid id);

        // Update Doctore
        void UpdateDepartment(Department department);

        // Delete Doctore
        void DeleteProduct(Guid id);

        // Soft Delete
        Task softDelete(Guid id);


       
    }
}
