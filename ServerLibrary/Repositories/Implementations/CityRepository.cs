﻿using BaseLibrary.Models;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class CityRepository(ApplicationDbContext applicationDbContext) : IGenericRepositoryInterface<City>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var city = await applicationDbContext.Cities.FindAsync(id);
            if (city is null)
            {
                return NotFound();
            }

            applicationDbContext.Cities.Remove(city);
            await Commit();
            return Success();
        }

        public async Task<List<City>> GetAll() => await applicationDbContext.Cities
            .AsNoTracking()
            .Include(c => c.Country)
            .ToListAsync();

        public async Task<City> GetById(int id)
        {
            return await applicationDbContext.Cities.FindAsync(id);
        }

        public async Task<GeneralResponse> Insert(City item)
        {
            var checkIfNull = await CheckName(item.Name);
            if (!checkIfNull)
            {
                return new GeneralResponse(false, $"Sorry {item.Name} already exists");
            }
            applicationDbContext.Cities.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(City item)
        {
            var city = await applicationDbContext.Cities.FindAsync(item.Id);
            if (city is null)
            {
                return NotFound();
            }
            city.Name = item.Name;
            city.CountryId = item.CountryId;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry City not found");

        private static GeneralResponse Success() => new(true, "Success, Process completed");

        private async Task Commit()
        {
            await applicationDbContext.SaveChangesAsync();
        }

        private async Task<bool> CheckName(string name)
        {
            var nameItem = await applicationDbContext.Cities.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return nameItem is null;
        }
    }
}