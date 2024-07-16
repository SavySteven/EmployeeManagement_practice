using System.ComponentModel.DataAnnotations;

namespace BasicLibrary.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

    }
}
