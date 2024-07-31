using BasicLibrary.Entities;
using BasicLibrary.Responses;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementation
{
    public class OvertimeRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<Overtime>
    {
        public Task<GeneralResponse> DeleteById(int id)
        {
            var item = await appDbContext.Overtime.FirstOrDefaultAsync(eid => eid.EmployeeId == id);
            if (item is null) return NotFound();

            appDbContext.Overtime.Remove(item);
            await Commit();
            return Success();
        }


        public async Task<List<Doctor>> GetAll() => await appDbContext
            .Overtime
            .AsNoTracking()
            .Include(t => t.OvertimeType)
            .ToListAsync();




        public async Task<Overtime> GetById(int id) => await appDbContext.Overtime.FirstOrDefaltAsync(eid => eid.EmployeeId == id);

        public async Task<GeneralResponse> Insert(Overtime item)
        {
            appDbContext.Overtime.Add(item);
            await Commit();
            return Success();
        }

        public Task<GeneralResponse> Update(Overtime item)
        {
            var obj = await appDbContext.Overtime.FirstOrDefaultAsync(eid => eid.EmployeeId == item.EmployeeId);
            if (obj is null) return NotFound();
            obj.StartDate = item.StartDate;
            obj.EndDate = item.EndDate;
            obj.OvertimTypeId = item.OvertimTypeId;
            await Commit();
            return Success();
        }


        private async Task Commit() => await appDbContext.SaveChangesAsync();
        private static GeneralResponse NotFound() => new(false, "Sorry data not found");
        private static GeneralResponse Success() => new(true, "Process completed");

    }
}
