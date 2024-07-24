using System.ComponentModel.DataAnnotations;

namespace BasicLibrary.DTOs
{
    public class EmployeeGroup2
    {
        [Required]
        public string JobName { get; set; } = string.Empty;

        [Required, Range(1, 99999, ErrorMessage = "You must select Branch")]
        public int BranchId { get; set; }

        [Required, Range(1, 99999, ErrorMessage = "You must select Town")]
        public string TownId { get; set; } = string.Empty;

        [Required]
        public string Other { get; set; } = string.Empty;

    }
}
