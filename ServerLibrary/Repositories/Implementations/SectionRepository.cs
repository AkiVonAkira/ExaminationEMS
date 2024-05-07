using BaseLibrary.Models;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class SectionRepository(ApplicationDbContext applicationDbContext) : IGenericRepositoryInterface<Section>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var department = await applicationDbContext.Sections.FindAsync(id);
            if (department is null)
            {
                return NotFound();
            }

            applicationDbContext.Sections.Remove(department);
            await Commit();
            return Success();
        }

        public async Task<List<Section>> GetAll() => await applicationDbContext.Sections.ToListAsync();

        public async Task<Section> GetById(int id)
        {
            return await applicationDbContext.Sections.FindAsync(id);
        }

        public async Task<GeneralResponse> Insert(Section item)
        {
            if (!await CheckName(item.Name!))
            {
                return new GeneralResponse(false, "Sorry Department already exists");
            }
            applicationDbContext.Sections.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Section item)
        {
            var department = await applicationDbContext.Sections.FindAsync(item.Id);
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
            var nameItem = await applicationDbContext.Sections.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return nameItem is null;
        }
    }
}