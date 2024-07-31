using BasicLibrary.Entities;
using BasicLibrary.Responses;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementation
{
    public class DoctorRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<Doctor>
    {
        public Task<GeneralResponse> DeleteById(int id)
        {

            var item = await appDbContext.Doctor.FirstOrDefaultAsync(eid => eid.EmployeeId == id);
            if (item is null) return NotFound();

            appDbContext.Doctor.Remove(item);
            await Commit();
            return Success();


        }

        public async Task<Doctor> GetById(int id) =>
         await appDbContext.Doctor.FirstOrDefaultAsync(eid => edi.EmployeeId == id);

        public async Task<GeneralResponse> Insert(Doctor item)
        {
            appDbContext.Doctor.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Doctor item)
        {
            var obj = await appDbContext.Doctor.FirstOrDefaultAsync(eid => eid.EmployeeId == item.EmployeeId);
            if (obj is null) return NotFound();
            obj.MedicalRecommendation = item.MedicalRecommendation;
            obj.MedicalDiagnose = item.MedicalDiagnose;
            obj.Date = item.Date;
            await Commit();
            return Success();
        }

        public async Task<List<Doctor>> GetAll() => await appDbContext.Doctor.AsNoTracking().ToListAsync();

        private async Task Commit() => await appDbContext.SaveChangesAsync();
        private static GeneralResponse NotFound() => new(false, "Sorry data not found");
        private static GeneralResponse Success() => new(true, "Process completed");

    }
}
