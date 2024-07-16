

namespace BasicLibrary.Entities
{
    public class Country : BaseEntity
    {
        //One to many relationship with city
        public List<City>? Cities { get; set; }
    }
}
