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
            var section = await applicationDbContext.Sections.FindAsync(id);
            if (section is null)
            {
                return NotFound();
            }

            applicationDbContext.Sections.Remove(section);
            await Commit();
            return Success();
        }

        public async Task<List<Section>> GetAll() => await applicationDbContext
            .Sections
            .AsNoTracking()
            .Include(d=>d.Department)
            .ToListAsync();

        public async Task<Section> GetById(int id)
        {
            return await applicationDbContext.Sections.FindAsync(id);
        }

        public async Task<GeneralResponse> Insert(Section item)
        {
            var checkIfNull = await CheckName(item.Name);
            if (!checkIfNull)
            {
                return new GeneralResponse(false, "Sorry Section already exists");
            }
            applicationDbContext.Sections.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Section item)
        {
            var section = await applicationDbContext.Sections.FindAsync(item.Id);
            if (section is null)
            {
                return NotFound();
            }
            section.Name = item.Name;
            section.DepartmentId = item.DepartmentId;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry Section not found");

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