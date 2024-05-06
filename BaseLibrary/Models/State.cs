namespace BaseLibrary.Models
{
    public class State : BaseEntity
    {
        // en till många relation med Employee
        public List<Employee>? Employees { get; set; }   
        // många till en relation med City  
        public City? City { get; set; }
        public int CityId { get; set; } 
    }
}