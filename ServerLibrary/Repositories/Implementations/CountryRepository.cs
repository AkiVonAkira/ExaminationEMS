using BaseLibrary.Models;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class CountryRepository(ApplicationDbContext applicationDbContext) : IGenericRepositoryInterface<Country>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var department = await applicationDbContext.Countries.FindAsync(id);
            if (department is null)
            {
                return NotFound();
            }

            applicationDbContext.Countries.Remove(department);
            await Commit();
            return Success();
        }

        public async Task<List<Country>> GetAll() => await applicationDbContext.Countries.ToListAsync();

        public async Task<Country> GetById(int id)
        {
            return await applicationDbContext.Countries.FindAsync(id);
        }

        public async Task<GeneralResponse> Insert(Country item)
        {
            if (!await CheckName(item.Name!))
            {
                return new GeneralResponse(false, "Sorry Department already exists");
            }
            applicationDbContext.Countries.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Country item)
        {
            var department = await applicationDbContext.Countries.FindAsync(item.Id);
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
            var nameItem = await applicationDbContext.Countries.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return nameItem is null;
        }
    }
}