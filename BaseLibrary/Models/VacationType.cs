namespace BaseLibrary.Models
{
    public class VacationType : BaseModel
    {
        // Många till en relation till vacation
        public List<Vacation>? Vacations { get; set; }
    }
}