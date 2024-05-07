using BaseLibrary.Models;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
     
        public Task<GeneralDepartment> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public  async Task<GeneralResponse> Insert(GeneralDepartment item)
        {
            if(!await CheckName(item.Name!))
            {
                return new GeneralResponse(false, "Sorry Department already exists");
            }
            applicationDbContext.GeneralDepartments.Add(item);
            await Commit();
            return Success();
        }

        public Task<GeneralResponse> Update(GeneralDepartment item)
        {
            throw new NotImplementedException();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry Department not found");

        private static GeneralResponse Success() => new(true, "Success, Process completed");

        private async Task Commit()
        {
            await applicationDbContext.SaveChangesAsync();
        }
    }
}