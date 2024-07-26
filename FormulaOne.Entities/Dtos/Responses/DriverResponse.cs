namespace FormulaOne.Entities.Dtos.Requests
{
    public class DriverResponse
    {
        public Guid DriverId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public int DriverNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
       
    }
}