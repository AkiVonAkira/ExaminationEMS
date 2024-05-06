namespace BaseLibrary.Models
{
    public class OvertimeType : BaseModel
    {
        // Många till en relation till vacation type
        public List<Overtime>? Overtimes { get; set; }
    }
}