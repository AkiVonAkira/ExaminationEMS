using BaseLibrary.Models;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class TownRepository(ApplicationDbContext applicationDbContext) : IGenericRepositoryInterface<Town>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var town = await applicationDbContext.Towns.FindAsync(id);
            if (town is null)
            {
                return NotFound();
            }

            applicationDbContext.Towns.Remove(town);
            await Commit();
            return Success();
        }

        public async Task<List<Town>> GetAll() => await applicationDbContext
            .Towns
            .AsNoTracking()
            .Include(c => c.City)
            .ToListAsync();

        public async Task<Town> GetById(int id)
        {
            return await applicationDbContext.Towns.FindAsync(id);
        }

        public async Task<GeneralResponse> Insert(Town item)
        {
            var checkIfNull = await CheckName(item.Name);
            if (!checkIfNull)
            {
                return new GeneralResponse(false, $"Sorry {item.Name} already exists");
            }
            applicationDbContext.Towns.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Town item)
        {
            var town = await applicationDbContext.Towns.FindAsync(item.Id);
            if (town is null)
            {
                return NotFound();
            }
            town.Name = item.Name;
            town.CityId = item.CityId;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry Town not found");

        private static GeneralResponse Success() => new(true, "Success, Process completed");

        private async Task Commit()
        {
            await applicationDbContext.SaveChangesAsync();
        }

        private async Task<bool> CheckName(string name)
        {
            var nameItem = await applicationDbContext.Towns.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return nameItem is null;
        }
    }
}