using BaseLibrary.Models;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class GeneralDepartmentRepository(ApplicationDbContext applicationDbContext) : IGenericRepositoryInterface<GeneralDepartment>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var department = await applicationDbContext.GeneralDepartments.FindAsync(id);
            if (department is null)
            {
                return NotFound();
            }

            applicationDbContext.GeneralDepartments.Remove(department);
            await Commit();
            return Success();
        }

        public async Task<List<GeneralDepartment>> GetAll() => await applicationDbContext.GeneralDepartments.ToListAsync();

        public async Task<GeneralDepartment> GetById(int id)
        {
            return await applicationDbContext.GeneralDepartments.FindAsync(id);
        }

        public async Task<GeneralResponse> Insert(GeneralDepartment item)
        {
            if (!await CheckName(item.Name!))
            {
                return new GeneralResponse(false, "Sorry Department already exists");
            }
            applicationDbContext.GeneralDepartments.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(GeneralDepartment item)
        {
            var department = await applicationDbContext.GeneralDepartments.FindAsync(item.Id);
            if (department is null)
            {
                return NotFound();
            }
            department.Name = item.Name;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry Department not found");

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