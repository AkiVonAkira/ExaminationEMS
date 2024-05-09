using BaseLibrary.Models;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class StateRepository(ApplicationDbContext applicationDbContext) : IGenericRepositoryInterface<State>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var state = await applicationDbContext.States.FindAsync(id);
            if (state is null)
            {
                return NotFound();
            }

            applicationDbContext.States.Remove(state);
            await Commit();
            return Success();
        }

        public async Task<List<State>> GetAll() => await applicationDbContext.States.ToListAsync();

        public async Task<State> GetById(int id)
        {
            return await applicationDbContext.States.FindAsync(id);
        }

        public async Task<GeneralResponse> Insert(State item)
        {
            var checkIfNull = await CheckName(item.Name);
            if (!checkIfNull)
            {
                return new GeneralResponse(false, "Sorry State already exists");
            }
            applicationDbContext.States.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(State item)
        {
            var state = await applicationDbContext.States.FindAsync(item.Id);
            if (state is null)
            {
                return NotFound();
            }
            state.Name = item.Name;
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
            var nameItem = await applicationDbContext.States.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return nameItem is null;
        }
    }
}