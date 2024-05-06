namespace BaseLibrary.Models
{
    public class Country : BaseModel
    {
        // en till många relation med City
        public List<City>? Cities { get; set; }
    }
}