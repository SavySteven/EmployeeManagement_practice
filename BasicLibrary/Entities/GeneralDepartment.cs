using System.Text.Json.Serialization;

namespace BasicLibrary.Entities
{
    public class GeneralDepartment : BaseEntity
    {
        //One to relationship with Department
        [JsonIgnore]
        public List<Department>? Departments { get; set; }


    }
}
