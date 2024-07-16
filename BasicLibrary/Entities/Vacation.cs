using System.ComponentModel.DataAnnotations;

namespace BasicLibrary.Entities
{
    public class Vacation : OtherBaseEntity
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public int NumberOfDays { get; set; }
        public DateTime EndDate => StartDate.AddDays(NumberOfDays);
        //Many to one relationship with vacation type
        public VacationType? VacationType { get; set; }
        [Required]
        public int VacationTypeId { get; set; }
    }
}
