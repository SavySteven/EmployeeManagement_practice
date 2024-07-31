using BasicLibrary.Entities;
using BasicLibrary.Responses;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementation
{
    public class OvertimeTypeRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<OvertimeType>
    {
        public Task<GeneralResponse> DeleteById(int id)
        {
            var item = await appDbContext.OvertimeType.FindAsync(id);
            if (item is null) return NotFound();

            appDbContext.OvertimeType.Remove(item);
            await Commit();
            return Success();
        }

        public Task<List<OvertimeType>> GetAll() => await appDbContext
            .OvartimeTypes
            .AsNoTracking()
            .ToListAsync();


        public Task<OvertimeType> GetById(int id) =>
            await appDbContext.OvertimeType.FindAsync(id);

        public async Task<GeneralResponse> Insert(OvertimeType item)
        {
            if (!await CheckName(item.Name!))
                return new GeneralResponse(false, "Overtime Type already added");
            appDbContext.OvertimeType.Add(item);
            await Commit();
            return Success();
        }

        public Task<GeneralResponse> Update(OvertimeType item)
        {
            var obj = await appDbContext.OvertimeType.FindAsync(item.id);
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
            var item = await appDbContext.OvertimeTypes.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
        }
    }
}
