using BasicLibrary.Entities;
using BasicLibrary.Responses;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementation
{
    public class VacationRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<Vacation>
    {
        public Task<GeneralResponse> DeleteById(int id)
        {
            var item = await appDbContext.Vacation.FirstOrDefaultAsync(eid => eid.EmployeeId == id);
            if (item is null) return NotFound();

            appDbContext.Overtime.Remove(item);
            await Commit();
            return Success();
        }

        public Task<List<Vacation>> GetAll() => await appDbContext
            .Overtime
            .AsNoTracking()
            .Include(t => t.VacationType)
            .ToListAsync();

        public async Task<Vacation> GetById(int id) =>
            await appDbContext.Vacation.FirstOrDefaltAsync(eid => eid.EmployeeId == id);

        public Task<GeneralResponse> Insert(Vacation item)
        {
            appDbContext.Overtime.Add(item);
            await Commit();
            return Success();
        }

        public Task<GeneralResponse> Update(Vacation item)
        {
            var obj = await appDbContext.Vacations.FirstOrDefaultAsync(eid => eid.EmployeeId == item.EmployeeId);
            if (obj is null) return NotFound();
            obj.StartDate = item.StartDate;
            obj.NumberOfDays = item.NumberOfDays;
            obj.VacationTypeId = item.VacationTypeId;
            await Commit();
            return Success();
        }

        private async Task Commit() => await appDbContext.SaveChangesAsync();
        private static GeneralResponse NotFound() => new(false, "Sorry data not found");
        private static GeneralResponse Success() => new(true, "Process completed");
    }
}
