using Microsoft.Identity.Client;

namespace BookingAPI.Dtos
{
    public class BookingResponseDto
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

    }
}
