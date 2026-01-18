namespace WebApplication1.Dtos
{
    public class BookingReadDto
    {
        //Only what clients are allowed to see
        //No UserId
        //No navigation properties
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
