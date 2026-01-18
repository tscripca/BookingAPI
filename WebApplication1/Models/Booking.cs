using Microsoft.Identity.Client;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class Booking
    {
        public int UserId { get; set; }
        public User? User { get; set; }
        public int Id { get; set; }
        //foreign key
        public int ResourceId { get; set; }

        [JsonIgnore]
        //navigation property
        public Resource? Resource { get; set; }

        //we need to store when the booking starts and when the booking ends.
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}