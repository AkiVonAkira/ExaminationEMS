using BaseLibrary.Models;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class DepartmentRepository(ApplicationDbContext applicationDbContext) : IGenericRepositoryInterface<Department>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var department = await applicationDbContext.Departments.FindAsync(id);
            if (department is null)
            {
                return NotFound();
            }

            applicationDbContext.Departments.Remove(department);
            await Commit();
            return Success();
        }

        public async Task<List<Department>> GetAll() => await applicationDbContext.Departments.ToListAsync();

        public async Task<Department> GetById(int id)
        {
            return await applicationDbContext.Departments.FindAsync(id);
        }

        public async Task<GeneralResponse> Insert(Department item)
        {
            var checkIfNull = await CheckName(item.Name);
            if (!checkIfNull)
            {
                return new GeneralResponse(false, "Sorry Department already exists");
            }
            applicationDbContext.Departments.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Department item)
        {
            var department = await applicationDbContext.Departments.FindAsync(item.Id);
            if (department is null)
            {
                return NotFound();
            }
            department.Name = item.Name;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry Country not found");

        private static GeneralResponse Success() => new(true, "Success, Process completed");

        private async Task Commit()
        {
            await applicationDbContext.SaveChangesAsync();
        }

        private async Task<bool> CheckName(string name)
        {
            var nameItem = await applicationDbContext.Departments.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return nameItem is null;
        }
    }
}