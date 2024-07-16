using System.ComponentModel.DataAnnotations;

namespace BasicLibrary.Entities
{
    public class Sanction : OtherBaseEntity
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Punishment { get; set; } = string.Empty;
        [Required]
        public DateTime PunishmentDate { get; set; }

        // Many to one relationship with vacation type
        public SanctionType? SanctionType { get; set; }
    }
}
