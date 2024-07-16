namespace BasicLibrary.Entities
{
    public class GeneralDepartment : BaseEntity
    {
        //One to relationship with Department
        public List<Department>? Departments { get; set; }


    }
}
