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
            var generalDepartment = await applicationDbContext.GeneralDepartments.FindAsync(id);
            if (generalDepartment is null)
            {
                return NotFound();
            }

            applicationDbContext.GeneralDepartments.Remove(generalDepartment);
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
            var checkIfNull = await CheckName(item.Name);
            if (!checkIfNull)
            {
                return new GeneralResponse(false, "Sorry General Department already exists");
            }
            applicationDbContext.GeneralDepartments.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(GeneralDepartment item)
        {
            var generalDepartment = await applicationDbContext.GeneralDepartments.FindAsync(item.Id);
            if (generalDepartment is null)
            {
                return NotFound();
            }
            generalDepartment.Name = item.Name;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry General Department not found");

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