using BasicLibrary.Entities;
using BasicLibrary.Responses;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementation
{
    public class VacationTypeRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<VacationType>
    {
        public Task<GeneralResponse> DeleteById(int id)
        {
            var item = await appDbContext.VacationType.FindAsync(id);
            if (item is null) return NotFound();

            appDbContext.VacationType.Remove(item);
            await Commit();
            return Success();
        }

        public Task<List<VacationType>> GetAll() => await appDbContext
            .VacationType
            .AsNoTracking()
            .ToListAsync();

        public Task<VacationType> GetById(int id) =>
            await appDbContext.VacationType.FindAsync(id);

        public Task<GeneralResponse> Insert(VacationType item)
        {
            if (!await CheckName(item.Name!))
                return new GeneralResponse(false, "Overtime Type already added");
            appDbContext.VacationType.Add(item);
            await Commit();
            return Success();
        }

        public Task<GeneralResponse> Update(VacationType item)
        {
            var obj = await appDbContext.VacationType.FindAsync(item.id);
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
            var item = await appDbContext.VacationType
                .FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
        }
    }
}
