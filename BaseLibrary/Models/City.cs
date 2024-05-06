namespace BaseLibrary.Models
{

    public class City : BaseEntity
    {
        // en till många relation med City
        public Country? Country { get; set; }
        public int CountryId { get; set; }
    }
}
