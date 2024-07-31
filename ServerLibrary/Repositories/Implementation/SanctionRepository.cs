using BasicLibrary.Entities;
using BasicLibrary.Responses;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementation
{

    public class SanctionRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<Sanction>
    {
        public Task<GeneralResponse> DeleteById(int id)
        {
            var item = await appDbContext.Sanction.FirstOrDefaultAsync(eid => eid.EmployeeId == id);
            if (item is null) return NotFound();

            appDbContext.Overtime.Remove(item);
            await Commit();
            return Success();
        }

        public Task<List<Sanction>> GetAll() => await appDbContext
            .Sanction
            .AsNoTracking()
            .Include(t => t.SanctionType)
            .ToListAsync();

        public Task<Sanction> GetById(int id) =>
            await appDbContext.Sanction.FirstOrDefaltAsync(eid => eid.EmployeeId == id);

        public Task<GeneralResponse> Insert(Sanction item)
        {
            appDbContext.Sanction.Add(item);
            await Commit();
            return Success();
        }

        public Task<GeneralResponse> Update(Sanction item)
        {
            var obj = await appDbContext.Sanction.FirstOrDefaultAsync(eid => eid.EmployeeId == item.EmployeeId);
            if (obj is null) return NotFound();
            obj.PunishmentDate = item.PunishmentDate;
            obj.Punishment = item.Punishment;
            obj.Date = item.Date;
            obj.SanctionType = item.SanctionType;
            await Commit();
            return Success();
        }


        private async Task Commit() => await appDbContext.SaveChangesAsync();
        private static GeneralResponse NotFound() => new(false, "Sorry data not found");
        private static GeneralResponse Success() => new(true, "Process completed");
    }
}
