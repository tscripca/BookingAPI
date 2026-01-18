namespace WebApplication1.Dtos
{
    public class BookingCreateDto
    {
        public int ResourceId { get; set; }
        public DateTime StartTime { get; set; } 
        public DateTime EndTime { get; set; }
    }
}
