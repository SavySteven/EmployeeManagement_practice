using System.Text.Json.Serialization;

namespace BasicLibrary.Entities
{
    public class Department : BaseEntity
    {
        // Many to one relationship with General Department
        public GeneralDepartment? GeneralDepartment { get; set; }

        public int GeneralDepartmentId { get; set; }

        //One to many relationhsip with branch
        [JsonIgnore]
        public List<Branch>? Branches { get; set; }
    }
}
