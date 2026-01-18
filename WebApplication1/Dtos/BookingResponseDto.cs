using Microsoft.Identity.Client;

namespace WebApplication1.Dtos
{
    public class BookingResponseDto
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

    }
}
