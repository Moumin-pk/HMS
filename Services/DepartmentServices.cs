using HMS.Abstraction;
using HMS.Data.Models;
using HMS.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HMS.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly HmsContext _hmscontext;

        public DepartmentServices(HmsContext hmscontext)
        {
            _hmscontext = hmscontext;
        }

        //  Get all Data or applay filter only display list if IsDeleted =  to False
        public async Task<IEnumerable<Department>> GetAllDepartmentAsync()

        {
            var department = await _hmscontext.Departments.ToListAsync();
            return department.Where(d => d.IsActive == false);
            return department;
        }

        //  Get DoctorebyId or return the model
        public async Task<Department> GetDepartmentById(Guid id)
        {
            var department = await _hmscontext.Departments.FirstOrDefaultAsync(f => f.Id == id);
            return department;
        }

        // Add new
      public async Task AddDepartment(Department department)
        {
            _hmscontext.Departments.Add(department);
            _hmscontext.SaveChanges();
        }

        // update the Doctore throw model 

        public void UpdateDepartment(Department department)
        {
            _hmscontext.Departments.Update(department);
            _hmscontext.SaveChanges();
        }




        // Soft Delete a doctore by its ID
        //  so its softDelete Method  change isDeleted is Equal to True
        public async Task softDelete(Guid id)
        {
            var department = await GetDepartmentById(id);
            if (department != null)
            {
                department.IsActive = true;
                _hmscontext.Departments.Update(department);
                _hmscontext.SaveChanges();
            }
        }

        public Task<List<Department>> GetAllDepartment()
        {
            throw new NotImplementedException();
        }

        

       

        public Task AddDepartmment(Department department)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(Guid id)
        {
            throw new NotImplementedException();
        }

        
    }
}
