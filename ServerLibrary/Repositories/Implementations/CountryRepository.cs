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
            var country = await applicationDbContext.Countries.FindAsync(id);
            if (country is null)
            {
                return NotFound();
            }

            applicationDbContext.Countries.Remove(country);
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
            var checkIfNull = await CheckName(item.Name);
            if (!checkIfNull)
            {
                return new GeneralResponse(false, "Sorry Country already exists");
            }
            applicationDbContext.Countries.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Country item)
        {
            var country = await applicationDbContext.Countries.FindAsync(item.Id);
            if (country is null)
            {
                return NotFound();
            }
            country.Name = item.Name;
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
            var nameItem = await applicationDbContext.Countries.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return nameItem is null;
        }
    }
}