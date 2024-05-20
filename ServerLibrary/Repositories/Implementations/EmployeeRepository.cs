using BaseLibrary.Models;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class EmployeeRepository(ApplicationDbContext applicationDbContext) : IGenericRepositoryInterface<Employee>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var item = await applicationDbContext.Employees.FindAsync(id);
            if (item == null) return NotFound();

            applicationDbContext.Employees.Remove(item);
            await Commit();
            return Success();
        }

        public async Task<List<Employee>> GetAll()
        {
            var employees = await applicationDbContext
            .Employees
            .AsNoTracking()
            .Include(s => s.Town)
            .ThenInclude(ci => ci.City)
            .ThenInclude(c => c.Country)
            .Include(s => s.Section)
            .ThenInclude(d => d.Department)
            .ThenInclude(gd => gd.GeneralDepartment)
            .ToListAsync();

            return employees;
        }

        public async Task<Employee> GetById(int id)
        {
            var employee = await applicationDbContext
            .Employees
            .Include(s => s.Town)
            .ThenInclude(ci => ci.City)
            .ThenInclude(c => c.Country)
            .Include(s => s.Section)
            .ThenInclude(d => d.Department)
            .ThenInclude(gd => gd.GeneralDepartment).FirstOrDefaultAsync(ei => ei.Id == id)!;

            return employee;
        }

        public async Task<GeneralResponse> Insert(Employee item)
        {
            if (!await CheckName(item.Name!)) return new GeneralResponse(false, "Employee already added");

            applicationDbContext.Employees.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Employee item)
        {
            var findUser = await applicationDbContext.Employees.FirstOrDefaultAsync(e => e.Id == item.Id);
            if (findUser == null) return new GeneralResponse(false, "Employee doesn't exist!");

            findUser.Name = item.Name;
            findUser.Description = item.Description;
            findUser.Address = item.Address;
            findUser.PhoneNumber = item.PhoneNumber;
            findUser.SectionId = item.SectionId;
            findUser.TownId = item.TownId;
            findUser.SocialSecurityNumber = item.SocialSecurityNumber;
            findUser.JobTitle = item.JobTitle;
            findUser.Photo = item.Photo;
            findUser.FileNumber = item.FileNumber;

            applicationDbContext.Employees.Update(item);
            await applicationDbContext.SaveChangesAsync();
            await Commit();
            return Success();
        }

        private async Task Commit() => await applicationDbContext.SaveChangesAsync();

        private static GeneralResponse NotFound() => new(false, "Sorry Employee not found");

        private static GeneralResponse Success() => new(true, "Success, Process completed");

        private async Task<bool> CheckName(string name)
        {
            var nameItem = await applicationDbContext.Employees.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return nameItem is null;
        }
    }
}