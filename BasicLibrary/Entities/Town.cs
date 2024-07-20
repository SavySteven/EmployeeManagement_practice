

using System.Text.Json.Serialization;

namespace BasicLibrary.Entities
{
    public class Town : BaseEntity
    {
        //Relationship : One to many with Employee
        [JsonIgnore]
        public List<Employee>? Employees { get; set; }
        //Many to one relationship with city
        public City? City { get; set; }
        public int CityId { get; set; }
    }
}
