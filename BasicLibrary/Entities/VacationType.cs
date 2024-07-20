using System.Text.Json.Serialization;

namespace BasicLibrary.Entities
{
    public class VacationType : BaseEntity
    {
        //Many to one relationship with vacation
        [JsonIgnore]
        public List<Vacation>? Vacations { get; set; }
    }
}
