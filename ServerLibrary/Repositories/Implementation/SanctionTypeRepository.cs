using BasicLibrary.Entities;
using BasicLibrary.Responses;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementation
{
    public class SanctionTypeRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<SanctionType>
    {
        public Task<GeneralResponse> DeleteById(int id)
        {
            var item = await appDbContext.SanctionType.FindAsync(id);
            if (item is null) return NotFound();

            appDbContext.SanctionType.Remove(item);
            await Commit();
            return Success();
        }

        public Task<List<SanctionType>> GetAll() => await appDbContext
            .SanctionType
            .AsNoTracking()
            .ToListAsync();

        public Task<SanctionType> GetById(int id) =>
            await appDbContext.SanctionType.FindAsync(id);


        public Task<GeneralResponse> Insert(SanctionType item)
        {
            if (!await CheckName(item.Name!))
                return new GeneralResponse(false, "Overtime Type already added");
            appDbContext.SanctionType.Add(item);
            await Commit();
            return Success();
        }

        public Task<GeneralResponse> Update(SanctionType item)
        {
            var obj = await appDbContext.SanctionType.FindAsync(item.id);
            if (obj is null) return NotFound();
            obj.Name = item.Name;

            await Commit();
            return Success();
        }
        private async Task Commit() => await appDbContext.SaveChangesAsync();
        private static GeneralResponse NotFound() => new(false, "Sorry data not found");
        private static GeneralResponse Success() => new(true, "Process completed");

        private async Task<bool> CheckName(string name)
        {
            var item = await appDbContext.SanctionType.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
        }
    }
}
